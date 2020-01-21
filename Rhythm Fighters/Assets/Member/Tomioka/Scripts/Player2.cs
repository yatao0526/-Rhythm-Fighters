using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
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

    private float way2P = 0;

    //移動後と移動前の場所
    private Vector3 moveAfter;
    private Vector3 moveBeforePos;

    //当たり判定用
    [SerializeField]
    private PlayerCol playercol;
    [SerializeField]
    private EffectScript effectscript;

    [SerializeField]
    private GameObject player1;

    [SerializeField]
    private NegationMode negationMode;

    public static bool negationButton2P = false;

    //プレイヤーの状態
    public enum Player2StateType
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

    public static Player2StateType p2StateType = Player2StateType.stand;

    void Start()
    {
        p2StateType = Player2StateType.stand;
        moveAfter = this.transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Debug.Log("P2は" + p2StateType + "です");
        Player2Way();
        if (this.transform.position == moveAfter)
        {
            SetTargetPosition();
            DebugSetTargetPosition();
        }
        if (p2StateType == Player2StateType.stand)
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
    private void Player2Way()
    {
        float x = this.transform.position.x;
        if (this.transform.position.x < player1.transform.position.x)
        {
            way2P = 0;
        }
        else if (player1.transform.position.x < this.transform.position.x)
        {
            way2P = 180;
        }
        this.transform.rotation = new Quaternion(0f, way2P, 0f, 1f);
    }

    //プレイヤーの操作番号
    private void SetTargetPosition()
    {
        NegationFunction();

        moveBeforePos = moveAfter;

        if (NotesController.judge)
        {
            //stand中はこっちのみ
            if (p2StateType == Player2StateType.stand)
            {
                //左移動
                if (Input.GetAxis("2PLeftRight") > 0.5f && this.transform.position.x < maxMove.x)
                {
                    p2StateType = Player2StateType.leftMove;
                }
                //右移動
                if (Input.GetAxis("2PLeftRight") < -0.5f && this.transform.position.x > minMove.x)
                {
                    p2StateType = Player2StateType.rightMove;
                }
                //構え
                if (Input.GetAxis("2PDown") < -0.5f)
                {
                    p2StateType = Player2StateType.pose;
                }
                //弱攻撃
                if (Input.GetButtonDown("2PMaru"))
                {
                    p2StateType = Player2StateType.lightPunch;
                }
                //強攻撃
                if (Input.GetButtonDown("2PBatu"))
                {
                    p2StateType = Player2StateType.heavyPunch;
                }
            }

            //構え後はこっち
            if (p2StateType == Player2StateType.pose)
            {
                //スキル1
                if (Input.GetButtonDown("2PMaru") && Input.GetAxis("2PLeftRight") != 0f)
                {
                    p2StateType = Player2StateType.skill1;
                }
                //スキル2
                if (Input.GetButtonDown("2PBatu") && Input.GetAxis("2PLeftRight") != 0f)
                {
                    p2StateType = Player2StateType.skill2;
                }
            }
            else if (NotesController.judge == false)
            {
                if (Input.GetAxis("2PLeftRight") != 0 || Input.GetAxis("2PDown") != 0 || Input.GetButtonDown("2PMaru") || Input.GetButtonDown("2PBatu"))
                {
                    p2StateType = Player2StateType.miss;
                }
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
            if (p2StateType == Player2StateType.stand)
            {
                //左移動
                if (Input.GetKeyDown(KeyCode.LeftArrow) && this.transform.position.x < maxMove.x)
                {
                    p2StateType = Player2StateType.leftMove;
                }
                //右移動
                if (Input.GetKeyDown(KeyCode.RightArrow) && this.transform.position.x > minMove.x)
                {
                    p2StateType = Player2StateType.rightMove;
                }
                //構え
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    p2StateType = Player2StateType.pose;
                }
                //弱攻撃
                if (Input.GetKeyDown(KeyCode.Keypad1))
                {
                    p2StateType = Player2StateType.lightPunch;
                }
                //強攻撃
                if (Input.GetKeyDown(KeyCode.Keypad2))
                {
                    p2StateType = Player2StateType.heavyPunch;
                }
            }

            //構え後はこっち
            if (p2StateType == Player2StateType.pose)
            {
                //スキル1
                if (Input.GetKeyDown(KeyCode.Keypad1) && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    p2StateType = Player2StateType.skill1;
                }
                //スキル2
                if (Input.GetKeyDown(KeyCode.Keypad2) && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    p2StateType = Player2StateType.skill2;
                }
            }
            else if (NotesController.judge == false)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
                {
                    p2StateType = Player2StateType.miss;
                }
            }
        }
    }

    //アクションナンバーの数によって2Pの行動をする
    public void Move2PAction()
    {
        switch (p2StateType)
        {
            case Player2StateType.miss:
                animator.SetTrigger("Trigger_Miss");
                Debug.Log("2Pはミス");
                AnimetionEnd2P();
                break;

            case Player2StateType.stand:
                //animator.SetTrigger("Trigger_Pause");
                break;

            //右に移動
            case Player2StateType.rightMove:
                moveAfter = transform.position + moveX;
                animator.SetTrigger("Trigger_r");
                AnimetionEnd2P();
                break;

            //左に移動
            case Player2StateType.leftMove:
                moveAfter = transform.position - moveX;
                animator.SetTrigger("Trigger_l");
                AnimetionEnd2P();
                break;

            //弱攻撃
            case Player2StateType.lightPunch:
                animator.SetTrigger("Trigger_LP");
                playercol.LPCol();
                Debug.Log("弱攻撃呼ばれた");
                AnimetionEnd2P();
                break;

            //強攻撃
            case Player2StateType.heavyPunch:
                animator.SetTrigger("Trigger_HP");
                playercol.HPCol();
                Debug.Log("強攻撃呼ばれた");
                AnimetionEnd2P();
                break;

            //構え
            case Player2StateType.pose:
                animator.SetTrigger("Trigger_Pose");
                Debug.Log("構え");
                AnimetionEnd2P();
                break;

            //スキル1
            case Player2StateType.skill1:
                Debug.Log("スキル1");
                AnimetionEnd2P();
                break;

            //スキル2
            case Player2StateType.skill2:
                Debug.Log("スキル2");
                animator.SetTrigger("Trigger_S2");
                playercol.S2Col();
                AnimetionEnd2P();
                break;

            //打消しモードで成功
            case Player2StateType.negationSuccess:
                Debug.Log("2P打消し成功");
                animator.SetTrigger("Trigger_ Negate");
                negationMode.Decrease1PGauge();
                negationButton2P = true;
                AnimetionEnd2P();
                break;

            //打消しモードで失敗
            case Player2StateType.negationFalse:
                Debug.Log("2P打消し失敗");
                GameController.modeType = GameController.ModeType.normalMode;
                AnimetionEnd2P();
                break;

            //ノックバック1
            case Player2StateType.knockBack1:
                animator.SetTrigger("Trigger_knock1 ");
                AnimetionEnd2P();
                break;

            //ノックバック2
            case Player2StateType.knockBack2:
                animator.SetTrigger("Trigger_knock2");
                AnimetionEnd2P();
                break;

            //ノックバック3
            case Player2StateType.knockBack3:
                animator.SetTrigger("Trigger_knock3");
                AnimetionEnd2P();
                break;
        }

    }

    //プレイヤーの状態を立ちに戻す
    private void AnimetionEnd2P()
    {
        p2StateType = Player2StateType.stand;
    }

    private void KnockBack2P()
    {

    }

    //打消しモード
    private void NegationFunction()
    {
        if (GameController.modeType == GameController.ModeType.negationMode)
        {
            //弱攻撃
            if ((p2StateType != Player2StateType.negationSuccess && p2StateType != Player2StateType.negationFalse)
                && (Input.GetButtonDown("2PBatu") || Input.GetButtonDown("2PMaru")))

            {
                switch (NotesController.negation2PFlag)
                {
                    case true:
                        animator.SetTrigger("Trigger_ Negate");
                        negationMode.Decrease1PGauge();
                        negationButton2P = true;
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