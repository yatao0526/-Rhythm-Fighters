using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Player":
                Debug.Log("プレイヤー(Player)");
                break;


            case "GameController":
                Debug.Log("攻撃(GameController)");
                break;

        }

        //Debug.Log("OnTriggerEnter2D: " + other.gameObject.name);
    }
}
