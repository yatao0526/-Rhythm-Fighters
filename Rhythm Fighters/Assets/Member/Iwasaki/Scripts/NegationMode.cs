using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegationMode : MonoBehaviour
{
    //打消しモードに入ったときにbool値をもらう
    public static bool check = false;
    
    public static int p1Num;
    public static int p2Num;
    private string nokezori;

    private Chara chara = Chara.SUZUKI;
    private Attack attack;

    [SerializeField]
    private SpriteFillBar negationBerR;
    [SerializeField]
    private SpriteFillBar negationBerL;
    [SerializeField]
    private ChractorData[] chractorData;
    private Dictionary<int, float> revocationGaugeDic = new Dictionary<int, float>()
    
    {
        {0,0.0f },
        {1,0.1f },
        {2,0.3f },
        {3,0.5f },
        {4,0.7f },
        {5,1.0f },
    };
    private void Update()
    {
        if (GameController.modeType == GameController.ModeType.negationMode)
        {
            if (check == false)
            {
                GetNum();
                SetBar();
                check = true;
            }
        }
        else
        {
            check = false;
            negationBerL.gameObject.SetActive(false);
            negationBerR.gameObject.SetActive(false);
            Debug.Log("通常モード");
        }
    }
    //キャラ、攻撃によってenum変える
    public void NagationChar(int charNum)
    {
        switch(charNum)
        {
            case 0:
                chara = Chara.LUO;
                break;
            case 1:
                chara = Chara.MIYAZAWA;
                break;
            case 2:
                chara = Chara.NEGISHI;
                break;
            case 3:
                chara = Chara.NITSUMA;
                break;
            case 4:
                chara = Chara.SUZUKI; 
                break;
            case 5:
                chara = Chara.YOKOYAMA;
                break;
        }
    }
    public void NagationATK(int charATK)
    {
        switch(charATK)
        {
            case 0:
                attack = Attack.Comand1;
                break;
            case 1:
                attack = Attack.Comand2;
                break;
            case 2:
                attack = Attack.HeavyPunch;
                break;
            case 3:
                attack = Attack.LightPunch;
                break;
        }
    }
    //キャラとどの攻撃同士なのかチェック
    public void GetNum()
    {
        p1Num = GetRevocatioNum(Chara.SUZUKI, Attack.HeavyPunch);
        p2Num = GetRevocatioNum(Chara.SUZUKI, Attack.Comand1);
        negationBerL.gameObject.SetActive(true);
        negationBerR.gameObject.SetActive(true);
    }
    //打消し突入時打消しゲージset
    public void SetBar()
    {
        float p1gaugelange = revocationGaugeDic[p1Num];
        float p2gaugelange = revocationGaugeDic[p2Num];
        negationBerL.SetFill(p1gaugelange);
        negationBerR.SetFill(p2gaugelange);
        negationBerL.SetCollider(p1gaugelange);
        negationBerR.SetCollider(p2gaugelange);
    }
    //ゲージ減算
    public void Decrease1PGauge()
    {
        p1Num -= 1;
        SetBar();
    }
    //ゲージ減算
    public void Decrease2PGauge()
    {
        p2Num -= 1;
        SetBar();
    }
    private int GetRevocatioNum(Chara chara, Attack attack)
    {
        ChractorData data = chractorData[(int)chara];
        int nokezoriNum = 0;
        switch (attack)
        {
            case Attack.LightPunch:
                nokezori = data._lp.ToString();
                break;
            case Attack.HeavyPunch:
                nokezori = data._hp.ToString();
                break;
            case Attack.Comand1:
                nokezori = data._c1.ToString();
                break;
            case Attack.Comand2:
                nokezori = data._c2.ToString();
                break;
        }
        switch (nokezori)
        {
            case "None":
                nokezoriNum = 1;
                break;
            case "Small":
                nokezoriNum = 2;
                break;
            case "Middle":
                nokezoriNum = 3;
                break;
            case "Big":
                nokezoriNum = 4;
                break;
            case "Gigant":
                nokezoriNum = 5;
                break;
        }
        return nokezoriNum;
    }
}
