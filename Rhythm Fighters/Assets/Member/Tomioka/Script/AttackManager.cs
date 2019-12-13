using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "WeakAttack":
                Debug.Log("弱攻撃");
                break;


            case "strongAttack":
                Debug.Log("強攻撃");
                break;
        }

        //Debug.Log("OnTriggerEnter2D: " + other.gameObject.name);
    }
}
