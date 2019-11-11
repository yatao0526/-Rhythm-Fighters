﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorAction : MonoBehaviour
{   
    // 1P(左側)の移動

    // 一回の左右移動で動く距離
    public float moveSpeed = 2.0f;

    void Start()
    {
        
    }

    void Update()
    {
        // キャラクター移動用
        CharactorMove();
    }

    void CharactorMove()
    {
        Vector2 position = transform.position;

        // 右方向移動
        if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            position.x += moveSpeed;
        }
        // 左方向移動
        else if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            position.x -= moveSpeed;
        }

        // 構え
        if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
           //StancePose(); 
        }

        // 弱攻撃
        if (Input.GetKeyDown(KeyCode.Z))
        {
            WeakAttack();
        }

        // 強攻撃
        if (Input.GetKeyDown(KeyCode.X))
        {
            StrengthAttack();
        }

        transform.position = position;
    }

    void StancePose()
    {
        CommandTechnique01();

        CommandTechnique02();
    }

    void WeakAttack()
    {

    }

    void StrengthAttack()
    {

    }

    // コマンド技1
    void CommandTechnique01()
    {
        StancePose();
    }

    // コマンド技2
    void CommandTechnique02()
    {
        StancePose();
    }
    
    // ノックバック
    void KnockBack()
    {
        Vector2 position = transform.position;

        position.x -= moveSpeed;
    }

    // 打ち消しモーション
    void NegateMotion()
    {

    }
}
