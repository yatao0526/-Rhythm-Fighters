using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    //ゲーム中のcanvas
    [SerializeField]
    GameObject gameCanvas;

    //リザルトのcanvas
    [SerializeField]
    GameObject resultCanvas;

    [SerializeField]
    Text winnerText;

    private void Start()
    {
        resultCanvas.SetActive(false);
    }

    void Update()
    {
        Result();
    }

    private void Result()
    {
        if (GameController.modeType == GameController.ModeType.gameEnd)
        {
            gameCanvas.SetActive(false);
            resultCanvas.SetActive(true);
        }

        if (HPManager.clearCheck)
        {
            winnerText.text = "1P WIN";
        }
        else
        {
            winnerText.text = "2P WIN";
        }
    }

}
