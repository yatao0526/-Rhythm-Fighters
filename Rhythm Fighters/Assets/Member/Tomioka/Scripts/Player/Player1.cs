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

    private int poseCount = 0;

    //プレイヤーの向き
    private float way1P = 0;
    private bool wayRight1P;

    private bool SkillR1P;

    //移動後の場所
    [HideInInspector]
    public Vector3 moveAfter1P;

    [Header("Y軸は-1、Z軸は72")]
    [SerializeField]
    private Vector3 moveNegationPos;

    [Space(10)]

    //当たり判定用
    [SerializeField]
    private PlayerColLP playercolLP;
    [SerializeField]
    private PlayerColHP playercolHP;
    [SerializeField]
    private PlayerColSkill1 playercolS1;
    [SerializeField]
    private PlayerColSkill2 playercolS2;

    [SerializeField]
    private EffectScript effectscript;

    private GameObject player2;

    private Player2 player2cs;

    [SerializeField]
    private NegationMode negationMode;

    public static bool negationButton1P = false;

    public static string myCharName1P;

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
    public static Player1StateType p1BeforeState = Player1StateType.stand;

    private void Awake()
    {
        myCharName1P = null;
        CharacterJudge();
    }

    void Start()
    {
        player2 = PlayerInfoManager.thisGamePlayer2;
        player2cs = player2.GetComponent<Player2>();
        Debug.Log("1Pが使ってるのは" + myCharName1P);
        player2cs = player2.GetComponent<Player2>();
        p1StateType = Player1StateType.stand;
        moveAfter1P = this.transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Debug.Log(player2cs.moveAfter2P);
        //Debug.Log("P1は" + p1StateType + "です");
        Player1Way();
        SetTargetPosition();
        DebugSetTargetPosition();

        if (p1StateType == Player1StateType.stand && GameController.modeType == GameController.ModeType.normalMode)
        {
            NormalModeMove();
        }
        if (GameController.modeType == GameController.ModeType.negationMode)
        {
            NegationModeMove();
        }
        if (GameController.modeType == GameController.ModeType.gameEnd)
        {
            ResultAction1P();
        }
    }

    //移動用の関数
    private void NormalModeMove()
    {
        //transform.position = Vector3.MoveTowards(transform.position, moveAfter1P, stepTime * 10 * Time.deltaTime);
        this.transform.position = moveAfter1P;
    }

    //打消しに入ったときにここに移動
    private void NegationModeMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveNegationPos, stepTime * 10 * Time.deltaTime);
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

        //ここは通常モードのみで判定される
        if (NotesController.judge)
        {
            //stand中はこっちのみ
            if (p1StateType == Player1StateType.stand)
            {
                //左移動
                if (Input.GetAxis("LeftRight") < -0.5f && minMove.x < this.transform.position.x && this.transform.position - moveX != player2cs.moveAfter2P)
                {
                    p1StateType = Player1StateType.leftMove;
                }
                //右移動
                if (Input.GetAxis("LeftRight") > 0.5f && this.transform.position.x < maxMove.x && this.transform.position + moveX != player2cs.moveAfter2P)
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
                //スキル1右
                if (Input.GetButtonDown("Maru") && Input.GetAxis("LeftRight") > 0.5f)
                {
                    SkillR1P = true;
                    p1StateType = Player1StateType.skill1;
                }
                //スキル1左
                if (Input.GetButtonDown("Maru") && Input.GetAxis("LeftRight") < -0.5f)
                {
                    SkillR1P = false;
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

        if (NotesController.judge)
        {
            //stand中はこっちのみ
            if (p1StateType == Player1StateType.stand)
            {
                //左移動
                if (Input.GetKeyDown(KeyCode.A) && minMove.x < this.transform.position.x && this.transform.position - moveX != player2cs.moveAfter2P)
                {
                    p1StateType = Player1StateType.leftMove;
                }
                //右移動
                if (Input.GetKeyDown(KeyCode.D) && this.transform.position.x < maxMove.x && this.transform.position + moveX != player2cs.moveAfter2P)
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
                //スキル1右
                if (Input.GetKeyDown(KeyCode.J) && Input.GetKeyDown(KeyCode.D))
                {
                    SkillR1P = true;
                    p1StateType = Player1StateType.skill1;
                }
                //スキル1左
                if (Input.GetKeyDown(KeyCode.J) && Input.GetKeyDown(KeyCode.A))
                {
                    SkillR1P = false;
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
                moveAfter1P = transform.position + moveX;
                animator.SetTrigger("Trigger_r");
                AnimetionEnd1P();
                break;

            //左に移動
            case Player1StateType.leftMove:
                moveAfter1P = transform.position - moveX;
                animator.SetTrigger("Trigger_l");
                AnimetionEnd1P();
                break;

            //弱攻撃
            case Player1StateType.lightPunch:
                animator.SetTrigger("Trigger_LP");
                playercolLP.LPCol();
                effectscript.LpFx();
                Debug.Log("弱攻撃呼ばれた");
                AnimetionEnd1P();
                break;

            //強攻撃
            case Player1StateType.heavyPunch:
                animator.SetTrigger("Trigger_HP");
                playercolHP.HPCol();
                effectscript.HpFx();
                Debug.Log("強攻撃呼ばれた");
                AnimetionEnd1P();
                break;

            //構え
            case Player1StateType.pose:
                animator.SetTrigger("Trigger_Pose");
                effectscript.PoseFx();
                Pose1P();
                Debug.Log("構え");
                break;

            //スキル1
            case Player1StateType.skill1:
                Debug.Log("スキル1");
                animator.SetTrigger("Trigger_S1");
                SkillOne();
                //playercolS1.S1Col();
                //effectscript.S1Fx();
                AnimetionEnd1P();
                break;

            //スキル2
            case Player1StateType.skill2:
                Debug.Log("スキル2");
                animator.SetTrigger("Trigger_S2");
                playercolS2.S2Col();
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
                animator.SetTrigger("Trigger_knock1");
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
        p1BeforeState = p1StateType;
        p1StateType = Player1StateType.stand;
    }

    private void Pose1P()
    {
        poseCount++;
        if (poseCount % 2 == 0)
        {
            AnimetionEnd1P();
        }
    }

    //攻撃受けた時の下がる挙動
    private void KnockBack1P()
    {
        //右向き
        if (wayRight1P == true && minMove.x < this.transform.position.x)
        {
            moveAfter1P = transform.position - moveX;
            Debug.Log("1Pは左に下がる");
        }
        //左向き
        if (wayRight1P == false && this.transform.position.x < maxMove.x)
        {
            moveAfter1P = transform.position + moveX;
            Debug.Log("1Pは右に下がる");
        }
        //1P画面左端
        if (wayRight1P == true && minMove.x == this.transform.position.x)
        {
            player2cs.Player1LeftEdge();
            Debug.Log("2Pは右に下がる");
        }
        //1P画面右端
        if (wayRight1P == false && this.transform.position.x == maxMove.x)
        {
            player2cs.Player1RightEdge();
            Debug.Log("2Pは左に下がる");
        }
    }

    //相手が画面右端のため自分が左に下がる
    public void Player2RightEdge()
    {
        moveAfter1P = transform.position - moveX;
    }

    //相手が画面左端のため自分が右に下がる
    public void Player2LeftEdge()
    {
        moveAfter1P = transform.position + moveX;
    }

    //打消しモードないでのプレイヤーの挙動
    private void NegationFunction()
    {
        if (GameController.modeType == GameController.ModeType.negationMode　&& NegationMode.checkBeat == true)
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

    //自分のキャラを判別
    private void CharacterJudge()
    {
        if (this.gameObject.name == "Suzuki1P(Clone)" || this.gameObject.name == "Suzuki2P(Clone)")
        {
            myCharName1P = "suzuki";
        }
        if (this.gameObject.name == "Yokoyama1P(Clone)" || this.gameObject.name == "Yokoyama2P(Clone)")
        {
            myCharName1P = "yokoyama";
        }
        if (this.gameObject.name == "Niduma1P" || this.gameObject.name == "Niduma2P")
        {
            myCharName1P = "niduma";
        }
        if (this.gameObject.name == "LUO1P" || this.gameObject.name == "LUO2P")
        {
            myCharName1P = "LUO";
        }
    }

    private void SkillOne()
    {
        switch (myCharName1P)
        {
            case "suzuki":
                if (SkillR1P == true)
                {
                    moveAfter1P = transform.position + moveX * 2;
                }
                else
                {
                    moveAfter1P = transform.position - moveX * 2;
                }
                break;

            case "yokoyama":
                Debug.Log("横山のスキル1");
                animator.SetTrigger("Trigger_S1");
                playercolS1.S1Col();
                effectscript.S1Fx();
                break;

            case "niduma":
                break;

            case "LUO":
                break;
        }
    }

    private void ResultAction1P()
    {
        if (HPManager.clearCheck)
        {
            //リザルトの勝ちアクション
            animator.SetTrigger("Trigger_");
        }
        else
        {
            //リザルトの負けアクション
            animator.SetTrigger("Trigger_");
        }
    }
}