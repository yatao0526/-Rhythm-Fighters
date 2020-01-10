using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSConTest : MonoBehaviour
{
    private bool neutralLRPosition = true;
    private bool neutralDownPosition = true;
    private bool neutral2PLRPosition = true;
    private bool neutral2PDownPosition = true;

    void Update()
    {
        PSConDebug();
    }

    ///summary
    ///InputManagerのボタン内はjoystick 2 と入れないと反応しないから
    ///1Pと2Pにも入れることを、忘れないようにすること
    ///summary
    private void PSConDebug()
    {
        //1P
        #region

        //1Pのコントローラーの左右
        #region
        if (Input.GetAxis("LeftRight") > 0.5f && neutralLRPosition == true)
        {
            Debug.Log("1P 右");
            neutralLRPosition = false;
        }
        if (Input.GetAxis("LeftRight") < -0.5 && neutralLRPosition == true)
        {
            Debug.Log("1P 左");
            neutralLRPosition = false;
        }
        if (Input.GetAxis("LeftRight") == 0.0f)
        {
            neutralLRPosition = true;
        }
        #endregion

        //1Pのコントローラーの上下
        #region
        if (Input.GetAxis("Down") < -0.5f && neutralDownPosition == true)
        {
            Debug.Log("1P 下");
            neutralDownPosition = false;
        }
        if (Input.GetAxis("Down") == 0.0f)
        {
            neutralDownPosition = true;
        }
        #endregion

        //1Pの〇×△□のボタンとオプションボタン
        #region
        if (Input.GetButtonDown("Maru"))
        {
            Debug.Log("1P 〇");
        }
        if (Input.GetButtonDown("Batu"))
        {
            Debug.Log("1P ×");
        }
        if (Input.GetButtonDown("Sankaku"))
        {
            Debug.Log("1P △");
        }
        if (Input.GetButtonDown("Sikaku"))
        {
            Debug.Log("1P □");
        }
        if (Input.GetButtonDown("Option"))
        {
            Debug.Log("1P オプション");
        }
        #endregion

        #endregion

        //2P
        #region

        //2Pのコントローラーの左右
        #region
        if (Input.GetAxis("2PLeftRight") > 0.5f && neutral2PLRPosition == true)
        {
            Debug.Log("2P 右");
            neutral2PLRPosition = false;
        }
        if (Input.GetAxis("2PLeftRight") < -0.5 && neutral2PLRPosition == true)
        {
            Debug.Log("2P 左");
            neutral2PLRPosition = false;
        }
        //2Pのコントローラーの下
        if (Input.GetAxis("2PLeftRight") == 0.0f)
        {
            neutral2PLRPosition = true;
        }
        #endregion

        //2Pのコントローラーの上下
        #region
        if (Input.GetAxis("2PDown") < -0.5f && neutral2PDownPosition == true)
        {
            Debug.Log("2P 下");
            neutral2PDownPosition = false;
        }
        if (Input.GetAxis("2PDown") == 0.0f)
        {
            neutral2PDownPosition = true;
        }
        #endregion


        //2Pの〇×△□のボタンとオプションボタン
        #region
        if (Input.GetButtonDown("2PMaru"))
        {
            Debug.Log("2P 〇");
        }
        if (Input.GetButtonDown("2PBatu"))
        {
            Debug.Log("2P ×");
        }
        if (Input.GetButtonDown("2PSankaku"))
        {
            Debug.Log("2P △");
        }
        if (Input.GetButtonDown("2PSikaku"))
        {
            Debug.Log("2P □");
        }
        if (Input.GetButtonDown("2POption"))
        {
            Debug.Log("2P オプション");
        }
        #endregion

        #endregion
    }
}
