using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1AttackManager : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "LightPunch":
                Debug.Log("弱攻撃が当たった");
                HPManager.player2HP -= 100;
                break;

            case "HeavyPunch":
                Debug.Log("強攻撃が当たった");
                HPManager.player2HP -= 100;
                break;

            case "Player2":
                Debug.Log("");
                break;
        }
    }
}
