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
    Vector3 moveAfter;

    Vector3 moveBeforePos;

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

    void SetTargetPosition()
    {

        moveBeforePos = moveAfter;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveAfter = transform.position + moveX;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveAfter = transform.position - moveX;
        }

    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveAfter, stepTime * 10 * Time.deltaTime);
    }
}

