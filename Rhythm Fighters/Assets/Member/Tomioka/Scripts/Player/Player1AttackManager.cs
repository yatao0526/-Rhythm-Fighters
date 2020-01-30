using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1AttackManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.name);
        if (GameController.modeType == GameController.ModeType.normalMode)
        {
            switch (col.tag)
            {
                case "LightPunch":
                    Debug.Log("2Pの弱攻撃が当たった");
                    Player1.p1StateType = Player1.Player1StateType.knockBack1;
                    HPManager.player1HP -= 100;
                    break;

                case "HeavyPunch":
                    Debug.Log("2Pの強攻撃が当たった");
                    Player1.p1StateType = Player1.Player1StateType.knockBack2;
                    HPManager.player1HP -= 100;
                    break;

                case "Skill2":
                    Debug.Log("2Pのスキル2が当たった");
                    Player1.p1StateType = Player1.Player1StateType.knockBack3;
                    HPManager.player1HP -= 100;
                    break;
            }
        }
    }
}
