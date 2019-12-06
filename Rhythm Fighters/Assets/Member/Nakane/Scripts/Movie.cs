using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Movie : MonoBehaviour
{
    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Invoke("SceneMove", 1.0f);
        }
    }

    public void SceneMove()
    {
        // 左クリックでTitleへ遷移
        SceneManager.LoadScene("Title");
        
    }

}
