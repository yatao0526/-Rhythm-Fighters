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

    //移動後と移動前の場所
    private Vector3 moveAfter;
    private Vector3 moveBeforePos;

    [SerializeField]
    private PlayerCol playercol;

    [HideInInspector]
    public static int player2ActionNumber;
    private int player2BackNumber = 0;

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
            if (Input.GetAxis("2PLeftRight") > 0.5f && this.transform.position.x < maxMove.x)
            {
                player2ActionNumber = 2;
            }
            if (Input.GetAxis("2PLeftRight") < -0.5f && this.transform.position.x > minMove.x)
            {
                player2ActionNumber = 3;
            }
            if (Input.GetAxis("2PDown") < -0.5f)
            {
                player2ActionNumber = 6;
                player2BackNumber = 1;
            }
            if (Input.GetButtonDown("2PMaru"))
            {
                player2ActionNumber = 4;
            }
            if (Input.GetButtonDown("2PBatu"))
            {
                player2ActionNumber = 5;
            }
            //スキル1
            if (player2BackNumber == 1 && Input.GetButtonDown("2PMaru"))
            {
                player2ActionNumber = 7;
            }
            //スキル2
            if (player2BackNumber == 1 && Input.GetButtonDown("2PBatu"))
            {
                player2ActionNumber = 8;
            }

        }
        else
        {
            if (Input.anyKey)
            {
                player2ActionNumber = 0;
                player2BackNumber = 0;
            }
        }
    }

    //デバッグ用
    private void DebugSetTargetPosition()
    {
        moveBeforePos = moveAfter;
        if (NotesController.judge)
        {
            //左移動
            if (Input.GetKeyDown(KeyCode.RightArrow) && this.transform.position.x < maxMove.x)
            {
                moveAfter = transform.position + moveX;
                animator.SetTrigger("Trigger_r");
            }
            //右移動
            if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > minMove.x)
            {
                moveAfter = transform.position - moveX;
                animator.SetTrigger("Trigger_l");
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                animator.SetTrigger("Trigger_LP");
                playercol.LPCol();
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                animator.SetTrigger("Trigger_HP");
                playercol.HPCol();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                animator.SetTrigger("Trigger_S2");
                playercol.S2Col();
            }
        }
    }

    //移動用の関数
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveAfter, stepTime * 10 * Time.deltaTime);
    }

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
                playercol.LPCol();
                player2ActionNumber = 1;
                break;

            //強攻撃
            case 5:
                animator.SetTrigger("Trigger_HP");
                playercol.HPCol();
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
                animator.SetTrigger("Trigger_S2");
                playercol.S2Col();
                Debug.Log("スキル2");
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