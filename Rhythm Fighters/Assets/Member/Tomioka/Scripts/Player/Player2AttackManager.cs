using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2AttackManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.name);
        if (GameController.modeType == GameController.ModeType.normalMode)
        {
            switch (col.tag)
            {
                case "LightPunch":
                    Debug.Log("1Pの弱攻撃が当たった");
                    Player2.p2StateType = Player2.Player2StateType.knockBack1;
                    HPManager.player2HP -= 100;
                    break;

                case "HeavyPunch":
                    Debug.Log("1Pの強攻撃が当たった");
                    Player2.p2StateType = Player2.Player2StateType.knockBack2;
                    HPManager.player2HP -= 100;
                    break;

                case "Skill1":
                    Debug.Log("1Pのスキル1が当たった");
                    Player2.p2StateType = Player2.Player2StateType.knockBack3;
                    HPManager.player2HP -= 100;
                    break;

                case "Skill2":
                    Debug.Log("1Pのスキル2が当たった");
                    Player2.p2StateType = Player2.Player2StateType.knockBack3;
                    HPManager.player2HP -= 100;
                    break;
            }
        }
    }
}
