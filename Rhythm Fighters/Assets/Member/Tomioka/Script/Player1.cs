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

    //移動する速さ
    [Header("移動する速さ")]
    [SerializeField]
    private float stepTime;

    //移動後と移動前の場所
    private Vector3 moveAfter;
    private Vector3 moveBeforePos;

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

        if (Input.GetAxis("LeftRight") > 0.5f && this.transform.position.x < maxMove.x)
        {
            moveAfter = transform.position + moveX;
        }
        if (Input.GetAxis("LeftRight") < -0.5f && this.transform.position.x > minMove.x)
        {
            moveAfter = transform.position - moveX;
        }

    }

    //デバッグ用
    private void DebugSetTargetPosition()
    {
        moveBeforePos = moveAfter;

        if (Input.GetKeyDown(KeyCode.D) && this.transform.position.x < maxMove.x)
        {
            moveAfter = transform.position + moveX;
            animator.SetTrigger("Trigger_r");
        }
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > minMove.x)
        {
            moveAfter = transform.position - moveX;
            animator.SetTrigger("Trigger_l");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("Trigger_LP");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("Trigger_HP");
        }
    }

    //移動用の関数
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveAfter, stepTime * 10 * Time.deltaTime);
    }
}
