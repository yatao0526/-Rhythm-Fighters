using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSConTest : MonoBehaviour
{
    private bool neutralLRPosition = true;
    private bool neutralDownPosition = true;


    void Update()
    {
        PSConDebug();
    }

    private void PSConDebug()
    {
        //コントローラーの左右
        #region
        if (Input.GetAxis("LeftRight") > 0.5f && neutralLRPosition == true)
        {
            Debug.Log("右");
            neutralLRPosition = false;
        }
        if (Input.GetAxis("LeftRight") < -0.5 && neutralLRPosition == true)
        {
            Debug.Log("左");
            neutralLRPosition = false;
        }
        if (Input.GetAxis("LeftRight") == 0.0f)
        {
            neutralLRPosition = true;
        }
        #endregion

        //コントローラーの下
        #region
        if (Input.GetAxis("Down") < -0.5f && neutralDownPosition == true)
        {
            Debug.Log("下");
            neutralDownPosition = false;
        }
        if (Input.GetAxis("Down") == 0.0f)
        {
            neutralDownPosition = true;
        }
        #endregion

        //〇×△□のボタン
        #region
        if (Input.GetButtonDown("Maru"))
        {
            Debug.Log("〇");
        }
        if (Input.GetButtonDown("Batu"))
        {
            Debug.Log("×");
        }
        if (Input.GetButtonDown("Sankaku"))
        {
            Debug.Log("△");
        }
        if (Input.GetButtonDown("Sikaku"))
        {
            Debug.Log("□");
        }
        #endregion

    }
}
