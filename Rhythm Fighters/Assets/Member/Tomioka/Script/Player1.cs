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
    public static int  player1ActionNumber;

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

    //押したキーによって進む方向を決める
    private void SetTargetPosition()
    {
        moveBeforePos = moveAfter;
        if (NotesController.judge)
        {
            if (Input.GetAxis("LeftRight") > 0.5f && this.transform.position.x < maxMove.x)
            {
                player1ActionNumber = 2;
            }
            if (Input.GetAxis("LeftRight") < -0.5f && this.transform.position.x > minMove.x)
            {
                player1ActionNumber = 3;
            }
            if (Input.GetButtonDown("Maru"))
            {
                player1ActionNumber = 4;
            }
            if (Input.GetButtonDown("Batu"))
            {
                player1ActionNumber = 5;
            }
        }
        else
        {
            //何もしていない状態のためPauseの状態
            player1ActionNumber = 1;
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

    public void MoveAction()
    {
        Debug.Log(player1ActionNumber);
        switch (player1ActionNumber)
        {
            case 0:
                animator.SetTrigger("Trigger_Miss");
                Debug.Log("ミス");
                break;

            case 1:
                animator.SetTrigger("Trigger_Pause");
                break;

            case 2:
                moveAfter = transform.position + moveX;
                animator.SetTrigger("Trigger_r");
                player1ActionNumber = 1;
                break;

            case 3:
                moveAfter = transform.position - moveX;
                animator.SetTrigger("Trigger_l");
                player1ActionNumber = 1;
                break;

            case 4:
                animator.SetTrigger("Trigger_LP");
                playercol.LPCol();
                player1ActionNumber = 1;
                break;

            case 5:animator.SetTrigger("Trigger_HP");
                playercol.HPCol();
                player1ActionNumber = 1;
                break;

            case 6:
                break;

            case 7:
                animator.SetTrigger("Trigger_S2");
                playercol.S2Col();
                break;

            case 8:
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
