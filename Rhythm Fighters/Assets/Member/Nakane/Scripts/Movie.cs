using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Movie : MonoBehaviour
{
    void Update()
    {
        InputGet();
    }
    private void InputGet()
    {
        if (Input.anyKey)
        {
            Invoke("SceneMove", 1.0f);
        }
    }
    private void SceneMove()
    {
        // 左クリックでTitleへ遷移
        SceneManager.LoadScene("Title");       
    }
}
