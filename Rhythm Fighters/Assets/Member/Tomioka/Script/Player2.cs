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
                player2ActionNumber = 2;
            }
            //右移動
            if (Input.GetAxis("2PLeftRight") < -0.5f && this.transform.position.x > minMove.x && player2BackNumber == 0)
            {
                player2ActionNumber = 3;
            }
            //構え
            if (Input.GetAxis("2PDown") < -0.5f)
            {
                player2ActionNumber = 6;
                player2BackNumber = 1;
            }
            //弱攻撃
            if (player2BackNumber == 0 && Input.GetButtonDown("2PMaru"))
            {
                player2ActionNumber = 4;
            }
            //強攻撃
            if (player2BackNumber == 0 && Input.GetButtonDown("2PBatu"))
            {
                player2ActionNumber = 5;
            }
            //スキル1
            if (player2BackNumber == 1 && Input.GetButtonDown("2PMaru") && Input.GetAxis("2PLeftRight") != 0f)
            {
                player2ActionNumber = 7;
            }
            //スキル2
            if (player2BackNumber == 1 && Input.GetButtonDown("2PBatu") && Input.GetAxis("2PLeftRight") != 0f)
            {
                player2ActionNumber = 8;
            }
        }
        else if (NotesController.judge == false)
        {
            if (Input.GetAxis("2PLeftRight") != 0 || Input.GetAxis("2PDown") != 0 || Input.GetButtonDown("2PMaru") || Input.GetButtonDown("2PBatu"))
            {
                player2ActionNumber = 0;
                player2BackNumber = 0;
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
            Debug.Log("行動可能");
            //左移動
            if (Input.GetKeyDown(KeyCode.RightArrow) && this.transform.position.x < maxMove.x && player2BackNumber == 0)
            {
                player2ActionNumber = 2;
            }
            //右移動
            if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > minMove.x && player2BackNumber == 0)
            {
                player2ActionNumber = 3;
            }
            //構え
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                player2ActionNumber = 6;
                player2BackNumber = 1;
            }
            //弱攻撃
            if (player2BackNumber == 0 && Input.GetKeyDown(KeyCode.Keypad1))
            {
                player2ActionNumber = 4;
            }
            //強攻撃
            if (player2BackNumber == 0 && Input.GetKeyDown(KeyCode.Keypad2))
            {
                player2ActionNumber = 5;
            }
            //スキル1
            if ((player2BackNumber == 1 && Input.GetKeyDown(KeyCode.Keypad1)) && ((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.LeftArrow))))
            {
                player2ActionNumber = 7;
            }
            //スキル2
            if ((player2BackNumber == 1 && Input.GetKey(KeyCode.Keypad2)) && ((Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.LeftArrow))))
            {
                player2ActionNumber = 8;
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
        //Debug.Log(player2ActionNumber);
        switch (player2ActionNumber)
        {
            case 0:
                animator.SetTrigger("Trigger_Miss");
                Debug.Log("ミス");
                player2ActionNumber = 1;
                break;

            case 1:
                //animator.SetTrigger("Trigger_Pause");
                break;

            //右に移動
            case 2:
                moveAfter = transform.position + moveX;
                animator.SetTrigger("Trigger_r");
                player2ActionNumber = 1;
                break;

            //左に移動
            case 3:
                moveAfter = transform.position - moveX;
                animator.SetTrigger("Trigger_l");
                player2ActionNumber = 1;
                break;

            //弱攻撃
            case 4:
                animator.SetTrigger("Trigger_LP");
                playercolLP.LPCol();
                player2ActionNumber = 1;
                break;

            //強攻撃
            case 5:
                animator.SetTrigger("Trigger_HP");
                playercolHP.HPCol();
                player2ActionNumber = 1;
                break;

            //構え
            case 6:
                animator.SetTrigger("Trigger_Pose");
                Debug.Log("構え");
                player2ActionNumber = 1;
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
                player2ActionNumber = 1;
                break;
        }
    }
}