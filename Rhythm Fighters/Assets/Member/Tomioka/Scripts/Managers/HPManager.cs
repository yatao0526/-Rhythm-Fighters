using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPManager : MonoBehaviour
{
    //プレイヤーのHPバー
    [SerializeField]
    private Image HP1PBar, HP2PBar;

    //HPの最大値
    private int playerMaxHP = 1000;

    //ダメージ値
    [SerializeField]
    private int damage = 100;

    //1Pと2PのHP
    public static float player1HP = 1000;
    public static float player2HP = 1000;

    public static bool clearCheck = true;

    private void Start()
    {
        player1HP = 1000;
        player2HP = 1000;
    }

    void Update()
    {
        //どちらかのプレイヤーのHPが0になったらKOを表示
        if (player1HP <= 0 || player2HP <= 0)
        {
            if(player1HP < player2HP)
            {
                clearCheck = false;
            }
            if (player1HP > player2HP)
            {
                clearCheck = true;
            }
            GameController.modeType = GameController.ModeType.gameEnd;
            //Invoke("ResultSceneMove",2.0f);
        }
        HP();
    }

    //HPバーの画像処理
    private void HP()
    {
        HP1PBar.fillAmount = player1HP / playerMaxHP;
        HP2PBar.fillAmount = player2HP / playerMaxHP;
    }

    private void ResultSceneMove()
    {
        SceneManager.LoadScene("Result");
    }
}
