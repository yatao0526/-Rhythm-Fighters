using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //HPバーの顔アイコン
    [Header("上から順に鈴木、横山、新妻、ラ")]
    [SerializeField]
    private Sprite[] HPBarIcon;

    [SerializeField]
    private Image icon1P, icon2P;

    [Space(15)]

    //左右のコマンド表
    [SerializeField]
    private Sprite[] commandPanel;

    [SerializeField]
    private Image command1P, command2P;


    void Start()
    {
        CharacterUIChange();
    }

    private void CharacterUIChange()
    {
        Debug.Log("UI変更時のプレイヤー1は" + Player1.myCharName1P);
        Debug.Log("UI変更時のプレイヤー2は" + Player2.myCharName2P);

        switch (Player1.myCharName1P)
        {
            case "suzuki":
                icon1P.sprite = HPBarIcon[0];
                command1P.sprite = commandPanel[0];
                break;

            case "yokoyama":
                icon1P.sprite = HPBarIcon[1];
                command1P.sprite = commandPanel[1];
                break;

            case "niduma":
                icon1P.sprite = HPBarIcon[2];
                command1P.sprite = commandPanel[2];
                break;

            case "LUO":
                icon1P.sprite = HPBarIcon[3];
                command1P.sprite = commandPanel[3];
                break;
        }

        switch (Player2.myCharName2P)
        {
            case "suzuki":
                icon2P.sprite = HPBarIcon[0];
                command2P.sprite = commandPanel[0];
                break;

            case "yokoyama":
                icon2P.sprite = HPBarIcon[1];
                command2P.sprite = commandPanel[1];
                break;

            case "niduma":
                icon2P.sprite = HPBarIcon[2];
                command2P.sprite = commandPanel[2];
                break;

            case "LUO":
                icon2P.sprite = HPBarIcon[3];
                command2P.sprite = commandPanel[3];
                break;
        }
    }
}
