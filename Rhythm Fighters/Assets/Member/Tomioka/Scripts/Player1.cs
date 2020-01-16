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

    // 移動時間
    [SerializeField]
    private float stepTime;

    private float way1P = 0;

    //移動後と移動前の場所
    private Vector3 moveAfter;
    private Vector3 moveBeforePos;

    //当たり判定用
    [SerializeField]
    private PlayerColLP playercolLP;
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
        knockBack3
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
        if (x < player2.transform.position.x)
        {
            way1P = 0;
        }
        else if (player2.transform.position.x < x)
        {
            way1P = 180;
        }
        this.transform.rotation = new Quaternion(0f, way1P, 0f, 1f);
    }

    //プレイヤーの操作番号
    private void SetTargetPosition()
    {
        NegationFunction();

        moveBeforePos = moveAfter;

        if (NotesController.judge)
        {
            //stand中はこっちのみ
            if (p1StateType == Player1StateType.stand)
            {
                //左移動
                if (Input.GetAxis("LeftRight") > 0.5f && this.transform.position.x < maxMove.x)
                {
                    p1StateType = Player1StateType.leftMove;
                }
                //右移動
                if (Input.GetAxis("LeftRight") < -0.5f && this.transform.position.x > minMove.x)
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
                if (Input.GetKeyDown(KeyCode.A) && this.transform.position.x < maxMove.x)
                {
                    p1StateType = Player1StateType.leftMove;
                }
                //右移動
                if (Input.GetKeyDown(KeyCode.D) && this.transform.position.x > minMove.x)
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
                Debug.Log("ミス");
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
                playercolLP.LPCol();
                Debug.Log("弱攻撃呼ばれた");
                AnimetionEnd1P();
                break;

            //強攻撃
            case Player1StateType.heavyPunch:
                animator.SetTrigger("Trigger_HP");
                playercolLP.HPCol();
                Debug.Log("強攻撃呼ばれた");
                AnimetionEnd1P();
                break;

            //構え
            case Player1StateType.pose:
                animator.SetTrigger("Trigger_Pose");
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
                playercolLP.S2Col();
                AnimetionEnd1P();
                break;
        }
    }

    //プレイヤーの状態を立ちに戻す
    private void AnimetionEnd1P()
    {
        p1StateType = Player1StateType.stand;
    }

    private void KnockBack1P()
    {

    }

    //打消しモード
    private void NegationFunction()
    {
        if (GameController.modeType == GameController.ModeType.negationMode)
        {
            //弱攻撃
            if (Input.GetButtonDown("Batu") || Input.GetButtonDown("Maru"))
            {
                switch (NotesController.negation1PFlag)
                {
                    case true:
                        animator.SetTrigger("Trigger_ Negate");
                        negationMode.Decrease1PGauge();
                        negationButton1P = true;
                        break;
                    case false:
                        Debug.Log("打消し終わり");
                        GameController.modeType = GameController.ModeType.normalMode;
                        break;
                }
            }
        }
    }
}