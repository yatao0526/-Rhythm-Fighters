using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegationMode : MonoBehaviour
{
    //どの攻撃判定なったかをint値で管理
    private int negationModeNum;
    //打消しモードに入ったときにbool値をもらう
    public static bool check = false;

    private int p1Num;
    private int p2Num;
    private string nokezori;

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
    }
    //
    public void GetNum()
    {
        p1Num = GetRevocatioNum(Chara.SUZUKI, Attack.HeavyPunch);
        p2Num = GetRevocatioNum(Chara.SUZUKI, Attack.Comand1);
    }
    //
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
    public void DecreaseGauge()
    {
        p1Num -= 1;
        p2Num -= 1;
        SetBar();
    }
    //
    private int GetRevocatioNum(Chara chara, Attack attack)
    {
        ChractorData data = chractorData[(int)chara];
        int  nokezoriNum = 0;
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
        switch(nokezori)
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
    
    //
    private void ObjActive(int sizeR,int sizeL)
    {
        //negationBerR.SetActive(true);
        //negationBerL.SetActive(true);

        negationBerR.transform.localScale = new Vector2(sizeR, 0.3f);
        negationBerL.transform.localScale = new Vector2(sizeL, 0.3f);
        check = true;
    }
}
