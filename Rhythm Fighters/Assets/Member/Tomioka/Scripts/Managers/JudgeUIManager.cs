using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgeUIManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] judgeSprite;

    [SerializeField]
    private Image judgeUI1P, judgeUI2P;

    private void Start()
    {
        judgeUI1P.sprite = judgeSprite[0];
        judgeUI2P.sprite = judgeSprite[0];
    }

    private void Update()
    {
        UIjudge1P();
        UIjudge2P();
    }

    private void UIjudge1P()
    {
        switch (Player1.p1StateType)
        {
            case Player1.Player1StateType.stand:
                judgeUI1P.sprite = judgeSprite[0];
                break;

            case Player1.Player1StateType.miss:
                judgeUI1P.sprite = judgeSprite[2];
                break;

            case Player1.Player1StateType.leftMove:
            case Player1.Player1StateType.rightMove:
            case Player1.Player1StateType.lightPunch:
            case Player1.Player1StateType.heavyPunch:
            case Player1.Player1StateType.pose:
            case Player1.Player1StateType.skill1:
            case Player1.Player1StateType.skill2:
                judgeUI1P.sprite = judgeSprite[1];
                break;
                        }
    }

    private void UIjudge2P()
    {
        switch (Player2.p2StateType)
        {
            case Player2.Player2StateType.stand:
                judgeUI2P.sprite = judgeSprite[0];
                break;

            case Player2.Player2StateType.leftMove:
            case Player2.Player2StateType.rightMove:
            case Player2.Player2StateType.lightPunch:
            case Player2.Player2StateType.heavyPunch:
            case Player2.Player2StateType.pose:
            case Player2.Player2StateType.skill1:
            case Player2.Player2StateType.skill2:
                judgeUI2P.sprite = judgeSprite[1];
                break;

            case Player2.Player2StateType.miss:
                judgeUI2P.sprite = judgeSprite[2];
                break;
        }

    }
}
