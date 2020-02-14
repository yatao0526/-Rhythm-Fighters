using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEJudge : MonoBehaviour
{
    //1PのSE
    #region

    //1Pの弱攻撃が当たった
    public static void LightPunchSE1P()
    {
        switch (PlayerInfoManager.thisGamePlayer1.name)
        {
            case "Suzuki1P(Clone)":
                SoundManager.Instance.PlaySe(SE.SuzukiLP);
                break;

            case "Yokoyama1P(Clone)":
                SoundManager.Instance.PlaySe(SE.YandNLP);
                break;

            case "Niduma1P(Clone)":
                SoundManager.Instance.PlaySe(SE.YandNLP);
                break;

            case "LUO1P(Clone)":
                SoundManager.Instance.PlaySe(SE.LUOMaruAttack);
                break;
        }
    }

    //1Pの強攻撃が当たった
    public static void HeavyPunchSE1P()
    {
        switch (PlayerInfoManager.thisGamePlayer1.name)
        {
            case "Suzuki1P(Clone)":
                SoundManager.Instance.PlaySe(SE.SuzukiHP);
                break;

            case "Yokoyama1P(Clone)":
                SoundManager.Instance.PlaySe(SE.YandNHP);
                break;

            case "Niduma1P(Clone)":
                SoundManager.Instance.PlaySe(SE.YandNHP);
                break;

            case "LUO1P(Clone)":
                SoundManager.Instance.PlaySe(SE.LUOBatuAttack);
                break;
        }
    }

    //1Pのスキル1が当たった
    public static void Skill1SE1P()
    {
        switch (PlayerInfoManager.thisGamePlayer1.name)
        {
            case "Suzuki1P(Clone)":
                //SoundManager.Instance.PlaySe(SE.SuzukiS1);
                break;

            case "Yokoyama1P(Clone)":
                SoundManager.Instance.PlaySe(SE.YS1);
                break;

            case "Niduma1P(Clone)":
                SoundManager.Instance.PlaySe(SE.YandNHP);
                break;

            case "LUO1P(Clone)":
                SoundManager.Instance.PlaySe(SE.LUOMaruAttack);
                break;
        }
    }

    //1Pのスキル2が当たった
    public static void Skill2SE1P()
    {
        switch (PlayerInfoManager.thisGamePlayer1.name)
        {
            case "Suzuki1P(Clone)":
                SoundManager.Instance.PlaySe(SE.SuzukiS2);
                break;

            case "Yokoyama1P(Clone)":
                SoundManager.Instance.PlaySe(SE.YS2);
                break;

            case "Niduma1P(Clone)":
                SoundManager.Instance.PlaySe(SE.YandNLP);
                break;

            case "LUO1P(Clone)":
                SoundManager.Instance.PlaySe(SE.LUOBatuAttack);
                break;
        }
    }

    #endregion

    //2PのSE
    #region

    //2Pの弱攻撃が当たった
    public static void LightPunchSE2P()
    {
        switch (PlayerInfoManager.thisGamePlayer2.name)
        {
            case "Suzuki2P(Clone)":
                SoundManager.Instance.PlaySe(SE.SuzukiLP);
                break;

            case "Yokoyama2P(Clone)":
                SoundManager.Instance.PlaySe(SE.YandNLP);
                break;

            case "Niduma2P(Clone)":
                SoundManager.Instance.PlaySe(SE.YandNLP);
                break;

            case "LUO2P(Clone)":
                SoundManager.Instance.PlaySe(SE.LUOMaruAttack);
                break;
        }
    }

    //2Pの強攻撃が当たった
    public static void HeavyPunchSE2P()
    {
        switch (PlayerInfoManager.thisGamePlayer2.name)
        {
            case "Suzuki2P(Clone)":
                SoundManager.Instance.PlaySe(SE.SuzukiHP);
                break;

            case "Yokoyama2P(Clone)":
                SoundManager.Instance.PlaySe(SE.YandNHP);
                break;

            case "Niduma2P(Clone)":
                SoundManager.Instance.PlaySe(SE.YandNHP);
                break;

            case "LUO2P(Clone)":
                SoundManager.Instance.PlaySe(SE.LUOBatuAttack);
                break;
        }
    }

    //2Pのスキル1が当たった
    public static void Skill1SE2P()
    {
        switch (PlayerInfoManager.thisGamePlayer2.name)
        {
            case "Suzuki2P(Clone)":
                //SoundManager.Instance.PlaySe(SE.SuzukiS1);
                break;

            case "Yokoyama2P(Clone)":
                SoundManager.Instance.PlaySe(SE.YS1);
                break;

            case "Niduma2P(Clone)":
                SoundManager.Instance.PlaySe(SE.YandNHP);
                break;

            case "LUO2P(Clone)":
                SoundManager.Instance.PlaySe(SE.LUOMaruAttack);
                break;
        }
    }

    //2Pのスキル2が当たった
    public static void Skill2SE2P()
    {
        switch (PlayerInfoManager.thisGamePlayer2.name)
        {
            case "Suzuki2P(Clone)":
                SoundManager.Instance.PlaySe(SE.SuzukiS2);
                break;

            case "Yokoyama2P(Clone)":
                SoundManager.Instance.PlaySe(SE.YS2);
                break;

            case "Niduma2P(Clone)":
                SoundManager.Instance.PlaySe(SE.YandNLP);
                break;

            case "LUO2P(Clone)":
                SoundManager.Instance.PlaySe(SE.LUOBatuAttack);
                break;
        }
    }
    #endregion
}
