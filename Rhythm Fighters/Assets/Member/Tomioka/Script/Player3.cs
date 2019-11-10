using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : MonoBehaviour
{

    [SerializeField]
    private Vector3 moveX;

    // 移動時間
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
        }
        Move();
    }

    //押したキーによって進む方向を決める
    void SetTargetPosition()
    {

        moveBeforePos = moveAfter;

        if (Input.GetAxis("LeftRight") > 0.5f || Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveAfter = transform.position + moveX;
        }
        if (Input.GetAxis("LeftRight") < -0.5f || Input.GetKeyDown(KeyCode.LeftArrow))
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

