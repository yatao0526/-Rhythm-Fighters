using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1AttackManager : MonoBehaviour
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
                Debug.Log("2Pの弱攻撃が当たった");
                animator.SetTrigger("Trigger_knock1");
                //HPManager.player1HP -= 100;
                break;

            case "HeavyPunch":
                Debug.Log("2Pの強攻撃が当たった");
                this.animator.SetTrigger("Trigger_knock2");
                //HPManager.player1HP -= 100;
                break;

            case "Skill2":
                Debug.Log("2Pのスキル2が当たった");
                this.animator.SetTrigger("Trigger_knock3");
                //HPManager.player1HP -= 100;
                break;
        }
    }
}
