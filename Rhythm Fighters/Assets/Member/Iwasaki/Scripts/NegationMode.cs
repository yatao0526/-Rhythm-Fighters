using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NegationMode : MonoBehaviour
{
    //打消しモードに入ったときにbool値をもらう
    public static bool check = false;

    public static int p1Num;
    public static int p2Num;
    public static int countNum = 0;

    public Image negationObject;

    private string nokezori;

    [HideInInspector]
    public Chara chara1P = Chara.SUZUKI, chara2P = Chara.SUZUKI;
    [HideInInspector]
    public Attack attack1P, attack2P;

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
        NegationProcessing();
    }
    private void NegationProcessing()
    {
        Debug.Log(countNum);
        //打消しモード突入
        if (GameController.modeType == GameController.ModeType.negationMode)
        {
            negationObject.enabled=true;
            countNum = 1;
            switch (countNum)
            {
                //打消し1拍目
                case 1:
                    Debug.Log("打消しはいったよ。処理開始");
                    Debug.Log("打消し1拍目");
                    Nagation1PATK();
                    Negation2PATK();
                    GetNum();
                    SetBar();
                    break;
                //打消し2拍目
                case 2:
                    Debug.Log("打消し2拍目");
                    break;
            }

        }
        else　//通常モード
        {
            //check = false;
            negationBerL.gameObject.SetActive(false);
            negationBerR.gameObject.SetActive(false);
            negationObject.enabled=false;
            countNum = 0;
        }
    }
    //キャラ、攻撃によってenum変える
    public void NegationChar1P(int char1PNum)
    {
        switch (char1PNum)
        {
            case 0:
                chara1P = Chara.LUO;
                break;
            case 1:
                chara1P = Chara.MIYAZAWA;
                break;
            case 2:
                chara1P = Chara.NEGISHI;
                break;
            case 3:
                chara1P = Chara.NITSUMA;
                break;
            case 4:
                chara1P = Chara.SUZUKI;
                break;
            case 5:
                chara1P = Chara.YOKOYAMA;
                break;
        }
        Debug.Log(char1PNum);
    }
    public void NegationChar2P(int char2PNum)
    {
        switch (char2PNum)
        {
            case 0:
                chara2P = Chara.LUO;
                break;
            case 1:
                chara2P = Chara.MIYAZAWA;
                break;
            case 2:
                chara2P = Chara.NEGISHI;
                break;
            case 3:
                chara2P = Chara.NITSUMA;
                break;
            case 4:
                chara2P = Chara.SUZUKI;
                break;
            case 5:
                chara2P = Chara.YOKOYAMA;
                break;
        }
        Debug.Log(char2PNum);
    }
    private void Nagation1PATK()
    {
        switch (NegationManager.attackNum1P)
        {
            case 0:
                attack1P = Attack.Comand1;
                break;
            case 1:
                attack1P = Attack.Comand2;
                break;
            case 2:
                attack1P = Attack.HeavyPunch;
                break;
            case 3:
                attack1P = Attack.LightPunch;
                break;
        }
        Debug.Log(attack1P);
    }
    private void Negation2PATK()
    {
        switch (NegationManager.attackNum2P)
        {
            case 0:
                attack2P = Attack.Comand1;
                break;
            case 1:
                attack2P = Attack.Comand2;
                break;
            case 2:
                attack2P = Attack.HeavyPunch;
                break;
            case 3:
                attack2P = Attack.LightPunch;
                break;
        }
        Debug.Log(attack2P);
    }
    //キャラとどの攻撃同士なのかチェック
    public void GetNum()
    {
        p1Num = GetRevocatioNum(Chara.SUZUKI, attack1P = Attack.HeavyPunch);
        p2Num = GetRevocatioNum(Chara.SUZUKI, attack2P = Attack.LightPunch);
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
