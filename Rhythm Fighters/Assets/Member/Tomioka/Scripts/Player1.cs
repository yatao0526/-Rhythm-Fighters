using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private Animator animator;

    //移動する距離(Vector3)
    [SerializeField]
    private Vector3 moveX;

    [SerializeField]
    private Vector3 minMove, maxMove;

    //移動時間
    [SerializeField]
    private float stepTime;

    //プレイヤーの向き
    private float way1P = 0;
    private bool wayRight1P;

    //移動後と移動前の場所
    private Vector3 moveAfter;
    private Vector3 moveBeforePos;

    //当たり判定用
    [SerializeField]
    private PlayerCol playercol;
    [SerializeField]
    private EffectScript effectscript;

    [SerializeField]
    private GameObject player2;

    [SerializeField]
    private NegationMode negationMode;

    public static bool negationButton1P = false;

    //プレイヤーの状態
    public enum Player1StateType
    {
        stand,
        leftMove,
        rightMove,
        lightPunch,
        heavyPunch,
        skill1,
        skill2,
        pose,
        miss,
        knockBack1,
        knockBack2,
        knockBack3,
        negationSuccess,
        negationFalse
    }

    public static Player1StateType p1StateType = Player1StateType.stand;

    void Start()
    {
        p1StateType = Player1StateType.stand;
        moveAfter = this.transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Debug.Log("P1は" + p1StateType + "です");
        Player1Way();
        if (this.transform.position == moveAfter)
        {
            SetTargetPosition();
            DebugSetTargetPosition();
        }
        if (p1StateType == Player1StateType.stand)
        {
            Move();
        }
    }

    //移動用の関数
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveAfter, stepTime * 10 * Time.deltaTime);
    }

    //プレイヤーの向き変更
    private void Player1Way()
    {
        float x = this.transform.position.x;
        //右向き
        if (x < player2.transform.position.x)
        {
            way1P = 0;
            wayRight1P = true;
        }
        //左向き
        else if (player2.transform.position.x < x)
        {
            way1P = 180;
            wayRight1P = false;
        }
        this.transform.rotation = new Quaternion(0f, way1P, 0f, 1f);
    }

    //プレイヤーの操作番号
    private void SetTargetPosition()
    {
        //ここは打消しモードのみで判定される
        NegationFunction();

        moveBeforePos = moveAfter;

        //ここは通常モードのみで判定される
        if (NotesController.judge)
        {
            //stand中はこっちのみ
            if (p1StateType == Player1StateType.stand)
            {
                //左移動
                if (Input.GetAxis("LeftRight") > 0.5f && minMove.x < this.transform.position.x)
                {
                    p1StateType = Player1StateType.leftMove;
                }
                //右移動
                if (Input.GetAxis("LeftRight") < -0.5f && this.transform.position.x < maxMove.x)
                {
                    p1StateType = Player1StateType.rightMove;
                }
                //構え
                if (Input.GetAxis("Down") < -0.5f)
                {
                    p1StateType = Player1StateType.pose;
                }
                //弱攻撃
                if (Input.GetButtonDown("Maru"))
                {
                    p1StateType = Player1StateType.lightPunch;
                }
                //強攻撃
                if (Input.GetButtonDown("Batu"))
                {
                    p1StateType = Player1StateType.heavyPunch;
                }
            }

            //構え後はこっち
            if (p1StateType == Player1StateType.pose)
            {
                //スキル1
                if (Input.GetButtonDown("Maru") && Input.GetAxis("LeftRight") != 0f)
                {
                    p1StateType = Player1StateType.skill1;
                }
                //スキル2
                if (Input.GetButtonDown("Batu") && Input.GetAxis("LeftRight") != 0f)
                {
                    p1StateType = Player1StateType.skill2;
                }
            }
        }
        else if (NotesController.judge == false)
        {
            if (Input.GetAxis("LeftRight") != 0 || Input.GetAxis("Down") != 0 || Input.GetButtonDown("Maru") || Input.GetButtonDown("Batu"))
            {
                p1StateType = Player1StateType.miss;
            }
        }
    }

    //デバッグ用
    private void DebugSetTargetPosition()
    {
        NegationFunction();

        moveBeforePos = moveAfter;

        if (NotesController.judge)
        {
            //stand中はこっちのみ
            if (p1StateType == Player1StateType.stand)
            {
                //左移動
                if (Input.GetKeyDown(KeyCode.A) && minMove.x < this.transform.position.x)
                {
                    p1StateType = Player1StateType.leftMove;
                }
                //右移動
                if (Input.GetKeyDown(KeyCode.D) && this.transform.position.x < maxMove.x)
                {
                    p1StateType = Player1StateType.rightMove;
                }
                //構え
                if (Input.GetKeyDown(KeyCode.S))
                {
                    p1StateType = Player1StateType.pose;
                }
                //弱攻撃
                if (p1StateType == Player1StateType.stand && Input.GetKeyDown(KeyCode.J))
                {
                    p1StateType = Player1StateType.lightPunch;
                }
                //強攻撃
                if (p1StateType == Player1StateType.stand && Input.GetKeyDown(KeyCode.K))
                {
                    p1StateType = Player1StateType.heavyPunch;
                }
            }

            //構え後はこっち
            if (p1StateType == Player1StateType.pose)
            {
                //スキル1
                if (Input.GetKeyDown(KeyCode.J) && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
                {
                    p1StateType = Player1StateType.skill1;
                }
                //スキル2
                if (Input.GetKeyDown(KeyCode.K) && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
                {
                    p1StateType = Player1StateType.skill2;
                }
            }
        }
        else if (NotesController.judge == false)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
            {
                p1StateType = Player1StateType.miss;
            }
        }
    }

    //1Pの状態にあった行動をする
    public void Move1PAction()
    {
        switch (p1StateType)
        {
            case Player1StateType.miss:
                animator.SetTrigger("Trigger_Miss");
                effectscript.MissFX();
                Debug.Log("1Pはミス");
                AnimetionEnd1P();
                break;

            case Player1StateType.stand:
                //animator.SetTrigger("Trigger_Stand");
                break;

            //右に移動
            case Player1StateType.rightMove:
                moveAfter = transform.position + moveX;
                animator.SetTrigger("Trigger_r");
                AnimetionEnd1P();
                break;

            //左に移動
            case Player1StateType.leftMove:
                moveAfter = transform.position - moveX;
                animator.SetTrigger("Trigger_l");
                AnimetionEnd1P();
                break;

            //弱攻撃
            case Player1StateType.lightPunch:
                animator.SetTrigger("Trigger_LP");
                playercol.LPCol();
                effectscript.LpFx();
                Debug.Log("弱攻撃呼ばれた");
                AnimetionEnd1P();
                break;

            //強攻撃
            case Player1StateType.heavyPunch:
                animator.SetTrigger("Trigger_HP");
                playercol.HPCol();
                effectscript.HpFx();
                Debug.Log("強攻撃呼ばれた");
                AnimetionEnd1P();
                break;

            //構え
            case Player1StateType.pose:
                animator.SetTrigger("Trigger_Pose");
                effectscript.PoseFx();
                Debug.Log("構え");
                break;

            //スキル1
            case Player1StateType.skill1:
                Debug.Log("スキル1");
                AnimetionEnd1P();
                break;

            //スキル2
            case Player1StateType.skill2:
                Debug.Log("スキル2");
                animator.SetTrigger("Trigger_S2");
                playercol.S2Col();
                effectscript.S2Fx();
                AnimetionEnd1P();
                break;

            //打消しモードで成功
            case Player1StateType.negationSuccess:
                Debug.Log("1P打消し成功");
                animator.SetTrigger("Trigger_ Negate");
                negationMode.Decrease1PGauge();
                negationButton1P = true;
                AnimetionEnd1P();
                break;

            //打消しモードで失敗
            case Player1StateType.negationFalse:
                Debug.Log("1P打消し失敗");
                GameController.modeType = GameController.ModeType.normalMode;
                AnimetionEnd1P();
                break;

            //ノックバック1
            case Player1StateType.knockBack1:
                animator.SetTrigger("Trigger_knock1 ");
                KnockBack1P();
                AnimetionEnd1P();
                break;

            //ノックバック2
            case Player1StateType.knockBack2:
                animator.SetTrigger("Trigger_knock2");
                KnockBack1P();
                AnimetionEnd1P();
                break;

            //ノックバック3
            case Player1StateType.knockBack3:
                animator.SetTrigger("Trigger_knock3");
                KnockBack1P();
                AnimetionEnd1P();
                break;

        }
    }

    //プレイヤーの状態を立ちに戻す
    private void AnimetionEnd1P()
    {
        p1StateType = Player1StateType.stand;
    }

    //攻撃受けた時の下がる挙動
    private void KnockBack1P()
    {
        //右向き
        if (wayRight1P == true && minMove.x < this.transform.position.x)
        {
            moveAfter = transform.position - moveX;
            Debug.Log("1Pは左に下がる");
        }
        //左向き
        if (wayRight1P == false && this.transform.position.x < maxMove.x)
        {
            moveAfter = transform.position + moveX;
            Debug.Log("1Pは右に下がる");
        }
    }

    //打消しモードないでのプレイヤーの挙動
    private void NegationFunction()
    {
        if (GameController.modeType == GameController.ModeType.negationMode)
        {
            //打消しモード中に複数回押せないように
            if ((p1StateType != Player1StateType.negationSuccess && p1StateType != Player1StateType.negationFalse)
                && (Input.GetButtonDown("Batu") || Input.GetButtonDown("Maru")))
            {
                //negation1PFlagは長さが変わるゲージに入っているか
                switch (NotesController.negation1PFlag)
                {
                    case true:
                        //打消しモード中の攻撃
                        p1StateType = Player1StateType.negationSuccess;
                        break;

                    case false:
                        p1StateType = Player1StateType.negationFalse;
                        break;

                }
            }
        }
    }
}