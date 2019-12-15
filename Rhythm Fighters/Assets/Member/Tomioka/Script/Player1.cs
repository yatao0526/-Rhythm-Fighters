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

    //移動後と移動前の場所
    private Vector3 moveAfter;
    private Vector3 moveBeforePos;

    [SerializeField]
    private PlayerCol playercol;

    [HideInInspector]
    public static int player1ActionNumber;
    private int player1BackNumber = 0;

    void Start()
    {
        moveAfter = this.transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (this.transform.position == moveAfter)
        {
            SetTargetPosition();
            DebugSetTargetPosition();
        }
        Move();
    }

    //プレイヤーの操作番号
    private void SetTargetPosition()
    {
        moveBeforePos = moveAfter;
        if (NotesController.judge)
        {
            //左移動
            if (Input.GetAxis("LeftRight") > 0.5f && this.transform.position.x < maxMove.x)
            {
                player1ActionNumber = 2;
            }
            //右移動
            if (Input.GetAxis("LeftRight") < -0.5f && this.transform.position.x > minMove.x)
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
            if (player1BackNumber == 1 && Input.GetButtonDown("Maru"))
            {
                player1ActionNumber = 7;
            }
            //スキル2
            if (player1BackNumber == 1 && Input.GetButtonDown("Batu"))
            {
                player1ActionNumber = 8;
            }
        }
        else
        {
            if (Input.anyKey)
            {
                player1ActionNumber = 0;
                player1BackNumber = 0;
            }
        }
    }

    //デバッグ用
    private void DebugSetTargetPosition()
    {
        moveBeforePos = moveAfter;
        if (NotesController.judge)
        {
            Debug.Log("行動可能");
            //左移動
            if (Input.GetKeyDown(KeyCode.D) && this.transform.position.x < maxMove.x)
            {
                moveAfter = transform.position + moveX;
                animator.SetTrigger("Trigger_r");
            }
            //右移動
            if (Input.GetKeyDown(KeyCode.A) && transform.position.x > minMove.x)
            {
                moveAfter = transform.position - moveX;
                animator.SetTrigger("Trigger_l");
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                animator.SetTrigger("Trigger_LP");
                playercol.LPCol();
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                animator.SetTrigger("Trigger_HP");
                playercol.HPCol();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                animator.SetTrigger("Trigger_S2");
                playercol.S2Col();
            }
        }
        else
        {

        }
    }

    //移動用の関数
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveAfter, stepTime * 10 * Time.deltaTime);
    }

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
                playercol.LPCol();
                player1ActionNumber = 1;
                break;

            //強攻撃
            case 5:
                animator.SetTrigger("Trigger_HP");
                playercol.HPCol();
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
                playercol.S2Col();
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
