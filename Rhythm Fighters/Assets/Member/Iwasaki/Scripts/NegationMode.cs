using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegationMode : MonoBehaviour
{
    //どの攻撃判定なったかをint値で管理
    private int negationModeNum;
    //打消しモードに入ったときにbool値をもらう
    public static bool check = false;

    [SerializeField]
    private GameObject negationBerR;
    [SerializeField]
    private GameObject negationBerL;
    private void Start()
    {
        negationBerR.SetActive(false);
        negationBerL.SetActive(false);
    }
    private void Update()
    {
        if (GameController.modeType == GameController.ModeType.negationMode)
        {
            if(check == false)
            {
                NegationModeStart();
            }
        }
    }

    private void NegationModeStart()
    {
        switch (negationModeNum)
        {
            case 0://弱弱
                break;
            case 1://弱強
                break;
            case 2://弱
                break;
            case 3:
                break;
        }
    }
    private void ObjActiv(int sizeR,int sizeL)
    {
        negationBerR.SetActive(true);
        negationBerL.SetActive(true);

        negationBerR.transform.localScale = new Vector2(sizeR, 4.05f);
        negationBerL.transform.localScale = new Vector2(sizeR, -4.05f);
    }
}
