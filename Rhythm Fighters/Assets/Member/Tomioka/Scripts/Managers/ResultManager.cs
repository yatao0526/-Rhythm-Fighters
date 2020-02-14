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
    private Image winnerName;

    [SerializeField]
    private Sprite[] winnerNameSprite;

    private float result1Time, result2Time;

    private void Start()
    {
        resultCanvas.SetActive(false);
        result1Time = SoundManager.Instance.seSound[17].clip.length;
        result2Time = SoundManager.Instance.seSound[18].clip.length / 2;
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
            ResultSE();
        }

        if (HPManager.clearCheck)
        {
            //winnerText.text = "1P WIN";
            switch (PlayerInfoManager.thisGamePlayer1.name)
            {
                case "Suzuki1P(Clone)":
                    winnerName.sprite = winnerNameSprite[0];
                    break;

                case "Yokoyama1P(Clone)":
                    winnerName.sprite = winnerNameSprite[1];
                    break;

                case "Niduma1P(Clone)":
                    winnerName.sprite = winnerNameSprite[2];
                    break;

                case "LUO1P(Clone)":
                    winnerName.sprite = winnerNameSprite[3];
                    break;
            }
        }
        else
        {
            //winnerText.text = "2P WIN";

            switch (PlayerInfoManager.thisGamePlayer2.name)
            {
                case "Suzuki2P(Clone)":
                    winnerName.sprite = winnerNameSprite[0];
                    break;

                case "Yokoyama2P(Clone)":
                    winnerName.sprite = winnerNameSprite[1];
                    break;

                case "Niduma2P(Clone)":
                    winnerName.sprite = winnerNameSprite[2];
                    break;

                case "LUO2P(Clone)":
                    winnerName.sprite = winnerNameSprite[3];
                    break;
            }
        }
    }

    private void ResultSE()
    {
        result1Time -= Time.deltaTime;
        result2Time -= Time.deltaTime;

        if (result1Time < 0)
        {
            Debug.Log("呼ばれてる");
            SoundManager.Instance.PlaySe(SE.result1);
            result1Time = SoundManager.Instance.seSound[17].clip.length;
        }

        if (result2Time < 0)
        {
            Debug.Log("呼ばれてる2");
            SoundManager.Instance.PlaySe(SE.result2);
            result2Time = SoundManager.Instance.seSound[18].clip.length / 2;
        }
    }
}
