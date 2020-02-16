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

    //移動時間
    [SerializeField]
    private float stepTime;

    private int poseCount = 0;

    //プレイヤーの向き
    private float way2P = 0;
    private bool wayLeft2P;

    private bool SkillR2P;

    //移動後の場所
    [HideInInspector]
    public Vector3 moveAfter2P;

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

    //[SerializeField]
    private GameObject player1;

    private Player1 player1cs;

    [SerializeField]
    private NegationMode negationMode;

    public static bool negationButton2P = false;

    public static string myCharName2P;

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
        negationFalse,
        animeNow
    }

    public static Player2StateType p2StateType = Player2StateType.stand;
    public static Player2StateType p2BeforeState = Player2StateType.stand;

    private void Awake()
    {
        myCharName2P = null;
        CharacterJudge();
    }

    void Start()
    {
        player1 = PlayerInfoManager.thisGamePlayer1;
        player1cs = player1.GetComponent<Player1>();
        //Debug.Log("2Pが使ってるのは" + myCharName2P);
        p2StateType = Player2StateType.stand;
        moveAfter2P = this.transform.position;
        animator = GetComponent<Animator>();
        animator.SetFloat("Speed", 1.7f);
    }

    void Update()
    {
        Debug.Log("P2は" + p2StateType + "です");
        Player2Way();
        SetTargetPosition();
        DebugSetTargetPosition();

        if (GameController.modeType == GameController.ModeType.normalMode)
        {
            Move();
        }
        if (GameController.modeType == GameController.ModeType.negationMode)
        {
            //NegationModeMove();
        }
        if (GameController.modeType == GameController.ModeType.gameEnd)
        {
            ResultAction2P();
        }
    }

    //移動用の関数
    private void Move()
    {
        //transform.position = Vector3.MoveTowards(transform.position, moveAfter2P, stepTime * 10 * Time.deltaTime);
        this.transform.position = moveAfter2P;
    }

    //打消しに入ったときにここに移動
    private void NegationModeMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveNegationPos, stepTime * 10 * Time.deltaTime);
    }

    //プレイヤーの向き変更
    private void Player2Way()
    {
        float x = this.transform.position.x;
        //右向き
        if (x < player1.transform.position.x)
        {
            way2P = 0;
            wayLeft2P = false;
        }
        //左向き
        else if (player1.transform.position.x < this.transform.position.x)
        {
            way2P = 180;
            wayLeft2P = true;
        }
        this.transform.rotation = new Quaternion(0f, way2P, 0f, 1f);
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
            if (p2StateType == Player2StateType.stand)
            {
                //左移動
                if (Input.GetAxis("2PLeftRight") < -0.5 && minMove.x < this.transform.position.x && this.transform.position - moveX != player1cs.moveAfter1P)
                {
                    p2StateType = Player2StateType.leftMove;
                }
                //右移動
                if (Input.GetAxis("2PLeftRight") > 0.5f && this.transform.position.x < maxMove.x && this.transform.position + moveX != player1cs.moveAfter1P)
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
                //スキル1右
                if (Input.GetButton("2PMaru") && Input.GetAxis("2PLeftRight") > 0.5f)
                {
                    SkillR2P = true;
                    p2StateType = Player2StateType.skill1;
                }
                //スキル1左
                if (Input.GetButton("2PMaru") && Input.GetAxis("2PLeftRight") < -0.5f)
                {
                    SkillR2P = false;
                    p2StateType = Player2StateType.skill1;
                }
                //スキル2
                if (Input.GetButton("2PBatu") && Input.GetAxis("2PLeftRight") != 0f)
                {
                    p2StateType = Player2StateType.skill2;
                }
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
        NegationFunction();

        if (NotesController.judge)
        {
            //stand中はこっちのみ
            if (p2StateType == Player2StateType.stand)
            {
                //左移動
                if (Input.GetKeyDown(KeyCode.LeftArrow) && minMove.x < this.transform.position.x && this.transform.position - moveX != player1cs.moveAfter1P)
                {
                    p2StateType = Player2StateType.leftMove;
                }
                //右移動
                if (Input.GetKeyDown(KeyCode.RightArrow) && this.transform.position.x < maxMove.x && this.transform.position + moveX != player1cs.moveAfter1P)
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
                //スキル1右
                if (Input.GetKeyDown(KeyCode.Keypad1) && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    SkillR2P = true;
                    p2StateType = Player2StateType.skill1;
                }
                //スキル1左
                if (Input.GetKeyDown(KeyCode.Keypad1) && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    SkillR2P = false;
                    p2StateType = Player2StateType.skill1;
                }
                //スキル2
                if (Input.GetKeyDown(KeyCode.Keypad2) && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    p2StateType = Player2StateType.skill2;
                }
            }
        }
        else if (NotesController.judge == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                p2StateType = Player2StateType.miss;
            }
        }
    }

    //2Pの状態にあった行動をする
    public void Move2PAction()
    {
        switch (p2StateType)
        {
            case Player2StateType.miss:
                animator.SetTrigger("Trigger_Miss");
                effectscript.MissFX();
                //Debug.Log("2Pはミス");
                AnimetionEnd2P();
                break;

            case Player2StateType.stand:
                //animator.SetTrigger("Trigger_Pause");
                break;

            //右に移動
            case Player2StateType.rightMove:
                moveAfter2P = transform.position + moveX;
                animator.SetTrigger("Trigger_r");
                AnimetionEnd2P();
                break;

            //左に移動
            case Player2StateType.leftMove:
                moveAfter2P = transform.position - moveX;
                animator.SetTrigger("Trigger_l");
                AnimetionEnd2P();
                break;

            //弱攻撃
            case Player2StateType.lightPunch:
                animator.SetTrigger("Trigger_LP");
                playercolLP.LPCol();
                effectscript.LpFx();
                Debug.Log("弱攻撃呼ばれた");
                AnimetionEnd2P();
                break;

            //強攻撃
            case Player2StateType.heavyPunch:
                animator.SetTrigger("Trigger_HP");
                playercolHP.HPCol();
                effectscript.HpFx();
                Debug.Log("強攻撃呼ばれた");
                AnimetionEnd2P();
                break;

            //構え
            case Player2StateType.pose:
                animator.SetTrigger("Trigger_Pose");
                effectscript.PoseFx();
                Debug.Log("構え");
                Pose2P();
                break;

            //スキル1
            case Player2StateType.skill1:
                Debug.Log("スキル1");
                animator.SetTrigger("Trigger_S1");
                SkillOne();
                //playercolS1.S1Col();
                //effectscript.S1Fx();
                AnimetionEnd2P();
                break;

            //スキル2
            case Player2StateType.skill2:
                Debug.Log("スキル2");
                animator.SetTrigger("Trigger_S2");
                playercolS2.S2Col();
                effectscript.S2Fx();
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
                animator.SetTrigger("Trigger_knock1");
                KnockBack2P();
                AnimetionEnd2P();
                break;

            //ノックバック2
            case Player2StateType.knockBack2:
                animator.SetTrigger("Trigger_knock2");
                KnockBack2P();
                AnimetionEnd2P();
                break;

            //ノックバック3
            case Player2StateType.knockBack3:
                animator.SetTrigger("Trigger_knock3");
                KnockBack2P();
                AnimetionEnd2P();
                break;
        }
    }

    //プレイヤーの状態を立ちに戻す
    private void AnimetionEnd2P()
    {
        p2BeforeState = p2StateType;
        p2StateType = Player2StateType.animeNow;
        Invoke("AnimetionStand2P", 1.3f);
    }

    private void AnimetionStand2P()
    {
        p2StateType = Player2StateType.stand;
    }

    private void Pose2P()
    {
        poseCount++;
        if (poseCount % 2 == 0)
        {
            AnimetionEnd2P();
        }
    }

    //攻撃受けた時の下がる挙動
    private void KnockBack2P()
    {
        //右向き
        if (wayLeft2P == false && minMove.x < this.transform.position.x)
        {
            moveAfter2P = transform.position - moveX;
            Debug.Log("2Pは左に下がる");
        }
        //左向き
        if (wayLeft2P == true && this.transform.position.x < maxMove.x)
        {
            moveAfter2P = transform.position + moveX;
            Debug.Log("2Pは右に下がる");
        }
        //2P画面左端
        if (wayLeft2P == false && minMove.x == this.transform.position.x)
        {
            player1cs.Player2LeftEdge();
            Debug.Log("1Pは右に下がる");
        }
        //2P画面右端
        if (wayLeft2P == true && this.transform.position.x == maxMove.x)
        {
            player1cs.Player2RightEdge();
            Debug.Log("1Pは左に下がる");
        }
    }

    //相手が画面右端のため自分が左に下がる
    public void Player1RightEdge()
    {
        moveAfter2P = transform.position - moveX;
    }

    //相手が画面左端のため自分が右に下がる
    public void Player1LeftEdge()
    {
        moveAfter2P = transform.position + moveX;
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

    //自分のキャラを判別する
    private void CharacterJudge()
    {
        if (this.gameObject.name == "Suzuki2P(Clone)")
        {
            myCharName2P = "suzuki";
        }
        if (this.gameObject.name == "Yokoyama2P(Clone)")
        {
            myCharName2P = "yokoyama";
        }
        if (this.gameObject.name == "Niduma2P(Clone)")
        {
            myCharName2P = "niduma";
        }
        if (this.gameObject.name == "LUO2P(Clone)")
        {
            myCharName2P = "LUO";
        }
    }

    private void SkillOne()
    {
        switch (myCharName2P)
        {
            case "suzuki":
                if (SkillR2P == true)
                {
                    moveAfter2P = transform.position + moveX * 2;
                    SoundManager.Instance.PlaySe(SE.SuzukiS1);
                }
                else
                {
                    moveAfter2P = transform.position - moveX * 2;
                    SoundManager.Instance.PlaySe(SE.SuzukiS1);
                }
                break;

            case "yokoyama":
                Debug.Log("横山のスキル1");
                animator.SetTrigger("Trigger_S1");
                playercolS1.S1Col();
                effectscript.S1Fx();
                break;

            case "niduma":
                Debug.Log("新妻のスキル1");
                animator.SetTrigger("Trigger_S1");
                playercolS1.S1Col();
                effectscript.S1Fx();
                break;

            case "LUO":
                Debug.Log("ラのスキル1");
                animator.SetTrigger("Trigger_S1");
                playercolS1.S1Col();
                effectscript.S1Fx();
                break;
        }
    }

    private void ResultAction2P()
    {
        if (HPManager.clearCheck)
        {
            //リザルトの負けアクション
            animator.SetTrigger("Trigger_Lose");
        }
        else
        {
            //リザルトの勝ちアクション
            animator.SetTrigger("Trigger_Win");
        }
    }
}