using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "WeakAttack":
                Debug.Log("弱攻撃が当たった");
                HPManager.player2HP -= 100;
                break;

            case "StrongAttack":
                Debug.Log("強攻撃が当たった");
                HPManager.player2HP -= 100;
                break;

            case "Player2":
                Debug.Log("プレイヤーに当たった→ダメージとのけぞりへ");
                break;
        }
    }
}
