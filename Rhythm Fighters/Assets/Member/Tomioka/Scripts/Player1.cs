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
    [SerializeField]
    private EffectScript effectscript;

    public static int player1ActionNumber = 1;
    private int player1BackNumber = 0;

    [SerializeField]
    private GameObject player2;

    [SerializeField]
    private NegationMode negationMode;

    public static bool negationButton1P = false;

    private enum Player1StateType
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

    private Player1StateType p1StateType = Player1StateType.stand;

    void Start()
    {
        player1ActionNumber = 1;
        moveAfter = this.transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Debug.Log(player1BackNumber);
        Debug.Log("P1は" + p1StateType + "です");
        Player1Way();
        if (this.transform.position == moveAfter)
        {
            //SetTargetPosition();
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
                p1StateType = Player1StateType.leftMove;
            }
            //右移動
            if (Input.GetAxis("LeftRight") < -0.5f && this.transform.position.x > minMove.x && player1BackNumber == 0)
            {
                p1StateType = Player1StateType.rightMove;
            }
            //構え
            if (Input.GetAxis("Down") < -0.5f)
            {
                p1StateType = Player1StateType.pose;
                player1BackNumber = 1;
            }
            //弱攻撃
            if (p1StateType == Player1StateType.stand && Input.GetButtonDown("Maru"))
            {
                p1StateType = Player1StateType.lightPunch;
            }
            //強攻撃
            if (p1StateType == Player1StateType.stand && Input.GetButtonDown("Batu"))
            {
                p1StateType = Player1StateType.heavyPunch;
            }
            //スキル1
            if (player1BackNumber == 1 && Input.GetButtonDown("Maru") && Input.GetAxis("LeftRight") != 0f)
            {
                p1StateType = Player1StateType.skill1;
            }
            //スキル2
            if (player1BackNumber == 1 && Input.GetButtonDown("Batu") && Input.GetAxis("LeftRight") != 0f)
            {
                p1StateType = Player1StateType.skill2;
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
            if (Input.GetKeyDown(KeyCode.A) && this.transform.position.x < maxMove.x && player1BackNumber == 0)
            {
                p1StateType = Player1StateType.leftMove;
            }
            //右移動
            if (Input.GetKeyDown(KeyCode.D) && transform.position.x > minMove.x && player1BackNumber == 0)
            {
                p1StateType = Player1StateType.rightMove;
            }
            //構え
            if (Input.GetKeyDown(KeyCode.S))
            {
                p1StateType = Player1StateType.pose;
                player1BackNumber = 1;
            }
            //弱攻撃
            if (player1BackNumber == 0 && Input.GetKeyDown(KeyCode.J))
            {
                p1StateType = Player1StateType.lightPunch;
            }
            //強攻撃
            if (player1BackNumber == 0 && Input.GetKeyDown(KeyCode.K))
            {
                p1StateType = Player1StateType.heavyPunch;
            }
            //スキル1
            if ((player1BackNumber == 1 && Input.GetKeyDown(KeyCode.J)) && ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.D))))
            {
                p1StateType = Player1StateType.skill1;
            }
            //スキル2
            if ((player1BackNumber == 1 && Input.GetKeyDown(KeyCode.K)) && ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.D))))
            {
                p1StateType = Player1StateType.skill2;
            }
            //コンボ弱から強
            if (player1ActionNumber == 4 && player1BackNumber == 0 && Input.GetKey(KeyCode.J))
            {
                p1StateType = Player1StateType.heavyPunch;
            }
            //コンボ強から構え
            if (player1ActionNumber == 5 && player1BackNumber == 0 && Input.GetKey(KeyCode.S))
            {
                p1StateType = Player1StateType.pose;
                player1BackNumber = 1;
            }
            ////構えをした後に何も押さなかった時、構え処理をなくす
            //if (player1BackNumber == 0 && !Input.GetKeyDown(KeyCode.A) && (!Input.GetKeyDown(KeyCode.D) && (!Input.GetKeyDown(KeyCode.J) && (!Input.GetKeyDown(KeyCode.K)))))
            //{
            //    player1BackNumber = 0;
            //}
        }
        else if (NotesController.judge == false)
        {
            if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K)))
            {
                Debug.Log("データ初期化");
                p1StateType = Player1StateType.stand;
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
        switch (p1StateType)
        {
            case Player1StateType.miss:
                animator.SetTrigger("Trigger_Miss");
                Debug.Log("ミス");
                //ここでAnimetionEnd1P();を呼んでその中でp1StateTypeをstandに戻す
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
                AnimetionEnd1P();
                break;

            //強攻撃
            case Player1StateType.heavyPunch:
                animator.SetTrigger("Trigger_HP");
                playercolHP.HPCol();
                AnimetionEnd1P();
                break;

            //構え
            case Player1StateType.pose:
                animator.SetTrigger("Trigger_Pose");
                Debug.Log("構え");
                AnimetionEnd1P();
                break;

            //スキル1
            case Player1StateType.skill1:
                Debug.Log("スキル1");
                break;

            //スキル2
            case Player1StateType.skill2:
                Debug.Log("スキル2");
                animator.SetTrigger("Trigger_S2");
                playercolSkill2.S2Col();
                player1BackNumber = 0;
                AnimetionEnd1P();
                break;
        }
    }

    private void AnimetionEnd1P()
    {
        p1StateType = Player1StateType.stand;
    }
}