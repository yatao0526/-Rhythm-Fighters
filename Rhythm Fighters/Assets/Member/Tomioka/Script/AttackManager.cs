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
                Debug.Log("弱攻撃に当たった→打ち消しモードへ");
                break;
                
            case "StrongAttack":
                Debug.Log("強攻撃に当たった→打ち消しモードへ");
                break;

            case "Player2":
                HPManager.player2HP -= 100;
                Debug.Log("プレイヤーに当たった→ダメージとのけぞりへ");
                break;
        }
    }
}
