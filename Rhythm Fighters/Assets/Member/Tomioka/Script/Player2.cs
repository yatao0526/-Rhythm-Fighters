using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    public Animator animator;

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
    void SetTargetPosition()
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
    void DebugSetTargetPosition()
    {
        moveBeforePos = moveAfter;

        if (Input.GetKeyDown(KeyCode.RightArrow) && this.transform.position.x < maxMove.x)
        {
            moveAfter = transform.position + moveX;
            //animator.
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > minMove.x)
        {
            moveAfter = transform.position - moveX;
        }
    }

    //移動用の関数
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveAfter, stepTime * 10 * Time.deltaTime);
    }
}
