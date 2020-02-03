using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //HPバーの顔アイコン
    [Header("上から順に鈴木、横山、新妻、ラ")]
    [SerializeField]
    private Sprite[] HPBarIcon1P;
    [SerializeField]
    private Sprite[] HPBarIcon2P;

    [Space(15)]

    [SerializeField]
    private Image icon1P;
    [SerializeField]
    private Image icon2P;

    [Space(15)]
   
    //左右のコマンド表
    [SerializeField]
    private Sprite[] commandPanel1P;
    [SerializeField]
    private Sprite[] commandPanel2P;

    [SerializeField]
    private Image command1P, command2P;


    void Start()
    {
        CharacterUIChange();
    }

    private void CharacterUIChange()
    {
        //Debug.Log("UI変更時のプレイヤー1は" + Player1.myCharName1P);
        //Debug.Log("UI変更時のプレイヤー2は" + Player2.myCharName2P);

        switch (Player1.myCharName1P)
        {
            case "suzuki":
                icon1P.sprite = HPBarIcon1P[0];
                command1P.sprite = commandPanel1P[0];
                break;

            case "yokoyama":
                icon1P.sprite = HPBarIcon1P[1];
                command1P.sprite = commandPanel1P[1];
                break;

            case "niduma":
                icon1P.sprite = HPBarIcon1P[2];
                command1P.sprite = commandPanel1P[2];
                break;

            case "LUO":
                icon1P.sprite = HPBarIcon1P[3];
                command1P.sprite = commandPanel1P[3];
                break;
        }

        switch (Player2.myCharName2P)
        {
            case "suzuki":
                icon2P.sprite = HPBarIcon2P[0];
                command2P.sprite = commandPanel2P[0];
                break;

            case "yokoyama":
                icon2P.sprite = HPBarIcon2P[1];
                command2P.sprite = commandPanel2P[1];
                break;

            case "niduma":
                icon2P.sprite = HPBarIcon2P[2];
                command2P.sprite = commandPanel2P[2];
                break;

            case "LUO":
                icon2P.sprite = HPBarIcon2P[3];
                command2P.sprite = commandPanel2P[3];
                break;
        }
    }
}
