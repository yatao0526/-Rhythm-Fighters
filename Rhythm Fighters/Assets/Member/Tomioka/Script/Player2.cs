using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    //移動する距離(Vector3)
    [SerializeField]
    private Vector3 moveX;

    //移動した数
    [SerializeField]
    private int numberMoves;

    //移動できる最小値と最大値
    [SerializeField]
    private int minMove, maxMove;

    //移動する速さ
    [Header("移動する速さ")]
    [SerializeField]
    private float stepTime;

    //移動後の場所
    private Vector3 moveAfter;

    private Vector3 moveBeforePos;

    void Start()
    {
        moveAfter = this.transform.position;
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

        if (Input.GetAxis("LeftRight") > 0.5f && numberMoves < maxMove)
        {
            moveAfter = transform.position + moveX;
            numberMoves++;
        }
        if (Input.GetAxis("LeftRight") < -0.5f && numberMoves > minMove)
        {
            moveAfter = transform.position - moveX;
            numberMoves--;
        }

    }

    //デバッグ用
    private void DebugSetTargetPosition()
    {

        moveBeforePos = moveAfter;

        if (Input.GetKeyDown(KeyCode.RightArrow) && numberMoves < maxMove)
        {
            moveAfter = transform.position + moveX;
            numberMoves++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && numberMoves > minMove)
        {
            moveAfter = transform.position - moveX;
            numberMoves--;
        }

    }

    //移動用の関数
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveAfter, stepTime * 10 * Time.deltaTime);
    }
}

