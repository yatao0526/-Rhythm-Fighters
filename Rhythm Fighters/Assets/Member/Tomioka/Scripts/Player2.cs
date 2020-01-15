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

    [SerializeField]
    private PlayerColLP playercolLP;
    [SerializeField]
    private PlayerColHP playercolHP;
    [SerializeField]
    private PlayerColSkill2 playercolSkill2;

    public static int player2ActionNumber;
    private int player2BackNumber = 0;

    [SerializeField]
    private GameObject player1;

    [SerializeField]
    private NegationMode negationMode;

    public static bool negationButton2P = false;

    private enum Player2StateType
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
        knockBack
    }

    private Player2StateType p2StateType = Player2StateType.stand;

    void Start()
    {
        player2ActionNumber = 1;
        moveAfter = this.transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Debug.Log(player2BackNumber);
        Player2Way();
        if (this.transform.position == moveAfter)
        {
            //SetTargetPosition();
            DebugSetTargetPosition();
        }
        if (player2BackNumber == 0)
        {
            Move();
        }
    }

    //プレイヤーの操作番号
    private void SetTargetPosition()
    {
        if (GameController.modeType == GameController.ModeType.negationMode)
        {
            //弱攻撃
            if (Input.GetButtonDown("2PBatu") || Input.GetButtonDown("2PMaru"))
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
        moveBeforePos = moveAfter;
        if (NotesController.judge)
        {
            //左移動
            if (Input.GetAxis("2PLeftRight") > 0.5f && this.transform.position.x < maxMove.x && player2BackNumber == 0)
            {
                p2StateType = Player2StateType.leftMove;
            }
            //右移動
            if (Input.GetAxis("2PLeftRight") < -0.5f && this.transform.position.x > minMove.x && player2BackNumber == 0)
            {
                p2StateType = Player2StateType.rightMove;
            }
            //構え
            if (Input.GetAxis("2PDown") < -0.5f)
            {
                p2StateType = Player2StateType.pose;
                player2BackNumber = 1;
            }
            //弱攻撃
            if (player2BackNumber == 0 && Input.GetButtonDown("2PMaru"))
            {
                p2StateType = Player2StateType.lightPunch;
            }
            //強攻撃
            if (player2BackNumber == 0 && Input.GetButtonDown("2PBatu"))
            {
                p2StateType = Player2StateType.heavyPunch;
            }
            //スキル1
            if (player2BackNumber == 1 && Input.GetButtonDown("2PMaru") && Input.GetAxis("2PLeftRight") != 0f)
            {
                p2StateType = Player2StateType.skill1;
            }
            //スキル2
            if (player2BackNumber == 1 && Input.GetButtonDown("2PBatu") && Input.GetAxis("2PLeftRight") != 0f)
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

    //デバッグ用
    private void DebugSetTargetPosition()
    {
        if (GameController.modeType == GameController.ModeType.negationMode)
        {
            //弱攻撃
            if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
            {
                switch (NotesController.negation2PFlag)
                {
                    case true:
                        animator.SetTrigger("Trigger_ Negate");
                        negationMode.Decrease2PGauge();
                        negationButton2P = true;
                        break;
                    case false:
                        Debug.Log("打消し終わり");
                        GameController.modeType = GameController.ModeType.normalMode;
                        break;
                }
            }
        }

        moveBeforePos = moveAfter;

        if (NotesController.judge)
        {
            //Debug.Log("行動可能");
            //左移動
            if (Input.GetKeyDown(KeyCode.RightArrow) && this.transform.position.x < maxMove.x && player2BackNumber == 0)
            {
                p2StateType = Player2StateType.leftMove;
            }
            //右移動
            if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > minMove.x && player2BackNumber == 0)
            {
                p2StateType = Player2StateType.rightMove;
            }
            //構え
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                p2StateType = Player2StateType.leftMove;
                player2BackNumber = 1;
            }
            //弱攻撃
            if (p2StateType == Player2StateType.stand && Input.GetKeyDown(KeyCode.M))
            {
                p2StateType = Player2StateType.lightPunch;
            }
            //強攻撃
            if (p2StateType == Player2StateType.stand && Input.GetKeyDown(KeyCode.Keypad2))
            {
                p2StateType = Player2StateType.heavyPunch;
            }
            //スキル1
            if ((player2BackNumber == 1 && Input.GetKeyDown(KeyCode.Keypad1)) && ((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.LeftArrow))))
            {
                p2StateType = Player2StateType.skill1;
            }
            //スキル2
            if ((player2BackNumber == 1 && Input.GetKey(KeyCode.Keypad2)) && ((Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.LeftArrow))))
            {
                p2StateType = Player2StateType.skill2;
            }
            //コンボ弱から強
            if (player2ActionNumber == 4 && player2BackNumber == 0 && Input.GetKey(KeyCode.Keypad2))
            {
                p2StateType = Player2StateType.heavyPunch;
            }
            //コンボ強から構え
            if (player2ActionNumber == 5 && player2BackNumber == 0 && Input.GetKey(KeyCode.DownArrow))
            {
                p2StateType = Player2StateType.pose;
                player2BackNumber = 1;
            }
            //構えをした後に何も押さなかった時、構え処理をなくす
            //if (!Input.GetKeyDown(KeyCode.RightArrow) && (!Input.GetKeyDown(KeyCode.LeftArrow) && (!Input.GetKeyDown(KeyCode.Keypad1) && (!Input.GetKeyDown(KeyCode.Keypad2)))))
            //{
            //    player2BackNumber = 0;
            //}
        }
        else if (NotesController.judge == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2)))
            {
                Debug.Log("データ初期化");
                player2ActionNumber = 0;
                player2BackNumber = 0;
            }
        }
    }

    //移動用の関数
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveAfter, stepTime * 10 * Time.deltaTime);
        Player2Way();
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

    //アクションナンバーの数によって2Pの行動をする
    public void Move2PAction()
    {
        switch (player2ActionNumber)
        {
            case 0:
                animator.SetTrigger("Trigger_Miss");
                Debug.Log("ミス");
                AnimetionEnd2P();
                break;

            case 1:
                //animator.SetTrigger("Trigger_Pause");
                break;

            //右に移動
            case 2:
                moveAfter = transform.position + moveX;
                animator.SetTrigger("Trigger_r");
                AnimetionEnd2P();
                break;

            //左に移動
            case 3:
                moveAfter = transform.position - moveX;
                animator.SetTrigger("Trigger_l");
                AnimetionEnd2P();
                break;

            //弱攻撃
            case 4:
                animator.SetTrigger("Trigger_LP");
                playercolLP.LPCol();
                AnimetionEnd2P();
                break;

            //強攻撃
            case 5:
                animator.SetTrigger("Trigger_HP");
                playercolHP.HPCol();
                AnimetionEnd2P();
                break;

            //構え
            case 6:
                animator.SetTrigger("Trigger_Pose");
                Debug.Log("構え");
                AnimetionEnd2P();
                break;

            //スキル1
            case 7:
                Debug.Log("スキル1");
                break;

            //スキル2
            case 8:
                Debug.Log("スキル2");
                animator.SetTrigger("Trigger_S2");
                playercolSkill2.S2Col();
                player2BackNumber = 0;
                AnimetionEnd2P();
                break;
        }

    }

    private void AnimetionEnd2P()
    {
        p2StateType = Player2StateType.stand;
    }
}