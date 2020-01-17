using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegationManager : MonoBehaviour
{
    [SerializeField]
    private NegationMode negationMode;
    
    private int negation1P = 0;
    private int negation2P = 0;

    private string negationStr1P;
    private string negationStr2P;

    public static int attackNum1P = 0;
    public static int attackNum2P = 0;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Negation();
        if (col.tag != "Player1" && col.tag != "Player2")
        {
            negationMode.negationObject.SetActive(true);
            GameController.modeType = GameController.ModeType.negationMode;
            //Debug.Log("うちけいそ");
        }
    }

    private void Negation()
    {
        //if (Player1.player1ActionNumber > 1)
        //{
            negation1P = Player1.player1ActionNumber;

            switch (negation1P)
            {
                case 4:
                    negationStr1P = "弱攻撃";
                    attackNum1P = 3;
                    Debug.Log(attackNum1P);
                    break;
                case 5:
                    negationStr1P = "強攻撃";
                    attackNum1P = 2;
                    Debug.Log(attackNum1P);
                    break;
                case 7:
                    negationStr1P = "スキル1";
                    attackNum1P = 0;
                    Debug.Log(attackNum1P);
                    break;
                case 8:
                    negationStr1P = "スキル2";
                    attackNum1P = 1;
                    Debug.Log(attackNum1P);
                    break;
                default:
                    Debug.Log("何かがおかしい1");
                    break;
            }
            Debug.Log(negation1P);
        //}

        if (Player2.player2ActionNumber > 1)
        {
            negation2P = Player2.player2ActionNumber;
            switch (negation2P)
            {
                case 4:
                    negationStr2P = "弱攻撃";
                    attackNum2P = 3;
                    Debug.Log(attackNum2P);
                    break;
                case 5:
                    negationStr2P = "強攻撃";
                    attackNum2P = 2;
                    Debug.Log(attackNum2P);
                    break;
                case 7:
                    negationStr2P = "スキル1";
                    attackNum2P = 0;
                    Debug.Log(attackNum2P);
                    break;
                case 8:
                    negationStr2P = "スキル2";
                    attackNum2P = 1;
                    Debug.Log(attackNum2P);
                    break;
                default:
                    Debug.Log("何かがおかしい1");
                    break;
            }
        }
    }
}