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
    private float player1HP, player2HP = 1000;

    private float HPTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        KO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player1HP -= damage;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            player2HP -= damage;
        }

        if (player1HP <= 0 || player2HP <= 0)
        {
            KO.SetActive(true);
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
