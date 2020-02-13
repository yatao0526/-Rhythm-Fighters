using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Movie : MonoBehaviour
{
    [SerializeField]
    private VideoClip PV;

    private double loadTime;

    private void Start()
    {
        loadTime = PV.length + 2;
    }

    void Update()
    {
        loadTime -= Time.deltaTime;

        if (loadTime < 0)
        {
            Debug.Log("呼ばれた");
            SceneManager.LoadScene("Title");
        }

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
