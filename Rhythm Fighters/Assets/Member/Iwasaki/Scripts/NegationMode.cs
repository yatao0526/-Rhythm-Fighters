using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegationMode : MonoBehaviour
{
    //どの攻撃判定なったかをint値で管理
    private int negationModeNum;
    //打消しモードに入ったときにbool値をもらう
    public static bool check = false;

    private void Update()
    {
        if(check == true)
        {
            NegationModeStart();
        }
    }

    private void NegationModeStart()
    {
        switch (negationModeNum)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
}
