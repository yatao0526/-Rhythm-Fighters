using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2AttackManager : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.name);
        switch (col.tag)
        {
            case "LightPunch":
                Debug.Log("1Pの弱攻撃が当たった");
                animator.SetTrigger("Trigger_knock1");
                HPManager.player2HP -= 100;
                break;
            case "HeavyPunch":
                Debug.Log("1Pの強攻撃が当たった");
                this.animator.SetTrigger("Trigger_knock2");
                HPManager.player2HP -= 100;
                break;
            case "Skill2":
                Debug.Log("1Pのスキル2が当たった");
                this.animator.SetTrigger("Trigger_knock3");
                HPManager.player2HP -= 100;
                break;
        }
    }
}
