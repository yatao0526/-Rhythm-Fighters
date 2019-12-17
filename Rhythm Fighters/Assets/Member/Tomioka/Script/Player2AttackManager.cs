using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2AttackManager : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "LightPunch":
                Debug.Log("1Pの弱攻撃が当たった");
                HPManager.player2HP -= 100;
                break;

            case "HeavyPunch":
                Debug.Log("1Pの強攻撃が当たった");
                HPManager.player2HP -= 100;
                break;

            case "Skill2":
                Debug.Log("1Pのスキル2が当たった");
                HPManager.player2HP -= 100;
                break;
        }
    }
}
