using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    //プレイヤーのHPバー
    [SerializeField]
    private Image HP1PBar, HP2PBar;

    //KOの文字
    [SerializeField]
    private GameObject KO;

    //HPの最大値
    private int playerMaxHP = 1000;

    //ダメージ値
    [SerializeField]
    private int damage = 100;


    //1Pと2PのHP
    [SerializeField]
    private float player1HP = 1000;
    [SerializeField]
    private float player2HP = 1000;

    private float HPTime = 0.5f;

    private bool fightNow = true;

    // Start is called before the first frame update
    void Start()
    {
        KO.SetActive(false);
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
            KO.SetActive(true);
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
