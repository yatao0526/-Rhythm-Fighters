using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegationManager : MonoBehaviour
{
    private string negationStr1P;
    private string negationStr2P;

    [SerializeField]
    private NegationMode negationMode;

    public static int attackNum1P = 0;
    public static int attackNum2P = 0;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Negation();
        if (col.tag != "Player1" && col.tag != "Player2" && col.tag != "Note")
        {
            GameController.modeType = GameController.ModeType.negationMode;
            Debug.Log("1Pは" + negationStr1P + "で打消し開始");
            Debug.Log("2Pは" + negationStr2P + "で打消し開始");
            Debug.Log("うちけいそ");
        }
    }

    private void Negation()
    {
        Debug.Log(Player1.p1BeforeState);

        switch (Player1.p1BeforeState)
        {
            case Player1.Player1StateType.lightPunch:
                negationStr1P = "弱攻撃";
                attackNum1P = 3;
                Debug.Log(attackNum1P);
                break;
            case Player1.Player1StateType.heavyPunch:
                negationStr1P = "強攻撃";
                attackNum1P = 2;
                Debug.Log(attackNum1P);
                break;
            case Player1.Player1StateType.skill1:
                negationStr1P = "スキル1";
                attackNum1P = 0;
                Debug.Log(attackNum1P);
                break;
            case Player1.Player1StateType.skill2:
                negationStr1P = "スキル2";
                attackNum1P = 1;
                Debug.Log(attackNum1P);
                break;
            default:
                Debug.Log("何かがおかしい1");
                break;
        }

        Debug.Log(Player2.p2BeforeState);

        switch (Player2.p2BeforeState)
        {
            case Player2.Player2StateType.lightPunch:
                negationStr2P = "弱攻撃";
                attackNum2P = 3;
                Debug.Log(attackNum2P);
                break;
            case Player2.Player2StateType.heavyPunch:
                negationStr2P = "強攻撃";
                attackNum2P = 2;
                Debug.Log(attackNum2P);
                break;
            case Player2.Player2StateType.skill1:
                negationStr2P = "スキル1";
                attackNum2P = 0;
                Debug.Log(attackNum2P);
                break;
            case Player2.Player2StateType.skill2:
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
