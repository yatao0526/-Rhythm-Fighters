using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegationManager : MonoBehaviour
{
    private int negation1P = 0;
    private int negation2P = 0;

    private string negationStr1P;
    private string negationStr2P;

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Negation();
        if (col.tag != "Player1" && col.tag != "Player2")
        {
            GameController.modeType = GameController.ModeType.negationMode;
            Debug.Log("1Pは" + negationStr1P);
            Debug.Log("2Pは" + negationStr2P);
            Debug.Log("うちけいそ");
        }
    }

    private void Negation()
    {
        if (Player1.player1ActionNumber > 1)
        {
            negation1P = Player1.player1ActionNumber;

            switch (negation1P)
            {
                case 4:
                    negationStr1P = "弱攻撃";
                    break;

                case 5:
                    negationStr1P = "強攻撃";
                    break;

                case 7:
                    negationStr1P = "スキル2";
                    break;

                case 8:
                    negationStr1P = "スキル2";
                    break;

                default:
                    Debug.Log("何かがおかしい1");
                    break;
            }
        }

        if (Player2.player2ActionNumber > 1)
        {
            negation2P = Player2.player2ActionNumber;
            switch (negation2P)
            {
                case 4:
                    negationStr2P = "弱攻撃";
                    break;

                case 5:
                    negationStr2P = "強攻撃";
                    break;

                case 7:
                    negationStr2P = "スキル2";
                    break;

                case 8:
                    negationStr2P = "スキル2";
                    break;

                default:
                    Debug.Log("何かがおかしい1");
                    break;
            }
        }


    }
}
