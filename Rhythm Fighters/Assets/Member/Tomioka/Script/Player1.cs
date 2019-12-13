﻿using System.Collections;
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
    private PleyerCol pleyercol;

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
            if (Input.GetAxis("LeftRight") > 0.5f && this.transform.position.x < maxMove.x && PSConTest.neutralLRPosition == true)
            {
                moveAfter = transform.position + moveX;
                animator.SetTrigger("Trigger_r");
            }
            if (Input.GetAxis("LeftRight") < -0.5f && this.transform.position.x > minMove.x && PSConTest.neutralLRPosition == true)
            {
                moveAfter = transform.position - moveX;
                animator.SetTrigger("Trigger_l");
            }
            if (Input.GetButtonDown("Maru"))
            {
                animator.SetTrigger("Trigger_LP");
                pleyercol.LPCol();
            }
            if (Input.GetButtonDown("Batu"))
            {
                animator.SetTrigger("Trigger_HP");
                pleyercol.HPCol();
            }
        }
        else
        {
            animator.SetTrigger("Trigger_Miss");
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
                pleyercol.LPCol();
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                animator.SetTrigger("Trigger_HP");
                pleyercol.HPCol();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                animator.SetTrigger("Trigger_S2");
                pleyercol.S2Col();
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
}
