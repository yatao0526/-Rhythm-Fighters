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
        if(Input.anyKey)
        {
            SceneManager.LoadScene("Title");
        }
    }
}
