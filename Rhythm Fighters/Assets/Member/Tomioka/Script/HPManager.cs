using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private float HPTime = 0.5f;

    private bool fightNow = true;

    void Start()
    {
    }

    void Update()
    {
        //10キーの1を押すと1PのHPが減る
        if (fightNow == true && Input.GetKeyDown(KeyCode.Keypad1))
        {
            player1HP -= damage;
        }

        //10キーの2を押すと2PのHPが減る
        if (fightNow == true && Input.GetKeyDown(KeyCode.Keypad2))
        {
            player2HP -= damage;
        }

        //どちらかのプレイヤーのHPが0になったらKOを表示
        if (player1HP <= 0 || player2HP <= 0)
        {
            fightNow = false;
        }

        HP();
    }

    //HPバーの画像処理
    private void HP()
    {
        HP1PBar.fillAmount = player1HP / playerMaxHP;
        HP2PBar.fillAmount = player2HP / playerMaxHP;
    }

}
