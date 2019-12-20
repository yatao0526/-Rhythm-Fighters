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

    [SerializeField]
    private PlayerColLP playercolLP;
    [SerializeField]
    private PlayerColHP playercolHP;
    [SerializeField]
    private PlayerColSkill2 playercolSkill2;

    public static int player1ActionNumber = 1;
    private int player1BackNumber = 0;

    [SerializeField]
    private GameObject player2;

    [SerializeField]
    private NegationMode negationMode;

    public static bool negationButton1P = false;

    void Start()
    {
        player1ActionNumber = 1;
        moveAfter = this.transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Player1Way();
        if (this.transform.position == moveAfter)
        {
            SetTargetPosition();
            DebugSetTargetPosition();
        }
        if (player1BackNumber == 0)
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
        moveBeforePos = moveAfter;
        if (NotesController.judge)
        {
            //左移動
            if (Input.GetAxis("LeftRight") > 0.5f && this.transform.position.x < maxMove.x && player1BackNumber == 0)
            {
                player1ActionNumber = 2;
            }
            //右移動
            if (Input.GetAxis("LeftRight") < -0.5f && this.transform.position.x > minMove.x && player1BackNumber == 0)
            {
                player1ActionNumber = 3;
            }
            //構え
            if (Input.GetAxis("Down") < -0.5f)
            {
                player1ActionNumber = 6;
                player1BackNumber = 1;
            }
            //弱攻撃
            if (player1BackNumber == 0 && Input.GetButtonDown("Maru"))
            {
                player1ActionNumber = 4;
            }
            //強攻撃
            if (player1BackNumber == 0 && Input.GetButtonDown("Batu"))
            {
                player1ActionNumber = 5;
            }
            //スキル1
            if (player1BackNumber == 1 && Input.GetButtonDown("Maru") && Input.GetAxis("LeftRight") != 0f)
            {
                player1ActionNumber = 7;
            }
            //スキル2
            if (player1BackNumber == 1 && Input.GetButtonDown("Batu") && Input.GetAxis("LeftRight") != 0f)
            {
                player1ActionNumber = 8;
            }
        }
        else if (NotesController.judge == false)
        {
            if (Input.GetAxis("LeftRight") != 0 || Input.GetAxis("Down") != 0 || Input.GetButtonDown("Maru") || Input.GetButtonDown("Batu"))
            {
                player1ActionNumber = 0;
                player1BackNumber = 0;
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

        moveBeforePos = moveAfter;
        if (NotesController.judge)
        {
            Debug.Log("行動可能");
            //左移動
            if (Input.GetKeyDown(KeyCode.D) && this.transform.position.x < maxMove.x && player1BackNumber == 0)
            {
                player1ActionNumber = 2;
            }
            //右移動
            if (Input.GetKeyDown(KeyCode.A) && transform.position.x > minMove.x && player1BackNumber == 0)
            {
                player1ActionNumber = 3;
            }
            //構え
            if (Input.GetKeyDown(KeyCode.S))
            {
                player1ActionNumber = 6;
                player1BackNumber = 1;
            }
            //弱攻撃
            if (player1BackNumber == 0 && Input.GetKeyDown(KeyCode.J))
            {
                player1ActionNumber = 4;
            }
            //強攻撃
            if (player1BackNumber == 0 && Input.GetKeyDown(KeyCode.K))
            {
                player1ActionNumber = 5;
            }
            //スキル1
            if ((player1BackNumber == 1 && Input.GetKeyDown(KeyCode.J)) && ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.D))))
            {
                player1ActionNumber = 7;
            }
            //スキル2
            if ((player1BackNumber == 1 && Input.GetKeyDown(KeyCode.K)) && ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.D))))
            {
                player1ActionNumber = 8;
            }
        }
        else if (NotesController.judge == false)
        {
            if (! Input.GetKeyDown(KeyCode.A) || (!Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
            {
                //player1ActionNumber = 0;
                player1BackNumber = 0;
            }
        }
    }

    //移動用の関数
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveAfter, stepTime * 10 * Time.deltaTime);
        Player1Way();
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


    //アクションナンバーの数によって1Pの行動をする
    public void Move1PAction()
    {
        //Debug.Log(player1ActionNumber);
        switch (player1ActionNumber)
        {
            //ミス
            case 0:
                animator.SetTrigger("Trigger_Miss");
                Debug.Log("ミス");
                player1ActionNumber = 1;
                break;

            //立ちのポーズ
            case 1:
                //animator.SetTrigger("Trigger_Stand");
                break;

            //右に移動
            case 2:
                moveAfter = transform.position + moveX;
                animator.SetTrigger("Trigger_r");
                player1ActionNumber = 1;
                break;

            //左に移動
            case 3:
                moveAfter = transform.position - moveX;
                animator.SetTrigger("Trigger_l");
                player1ActionNumber = 1;
                break;

            //弱攻撃
            case 4:
                animator.SetTrigger("Trigger_LP");
                playercolLP.LPCol();
                player1ActionNumber = 1;
                break;

            //強攻撃
            case 5:
                animator.SetTrigger("Trigger_HP");
                playercolHP.HPCol();
                player1ActionNumber = 1;
                break;

            //構え
            case 6:
                animator.SetTrigger("Trigger_Pose");
                Debug.Log("構え");
                player1ActionNumber = 1;
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
                player1ActionNumber = 1;
                break;

            case 9:


                break;

            case 10:
                break;

            case 11:
                break;

            default:
                break;
        }
    }
}
