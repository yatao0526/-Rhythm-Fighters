using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainResult : MonoBehaviour
{
    [SerializeField]
    private Text clearText;
    private void Start()
    {
        if(HPManager.clearCheck)
        {
            clearText.text = "1P WIN";
        }
        else
        {
            clearText.text = "2P WIN";
        }
    }
    private void Update()
    {
        //オプションキー
        if(Input.GetKeyDown(KeyCode.Joystick1Button9) || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
