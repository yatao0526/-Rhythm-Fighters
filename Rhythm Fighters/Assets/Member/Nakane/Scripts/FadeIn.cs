using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    // フェードインのおおよその秒数
    [SerializeField]
    private float fadeinTime;
    // 背景Image
    private Image image;

    void Start()
    {
        image = transform.Find("Panel").GetComponent<Image>();
        // コルーチンで使用する待ち時間を計測
        fadeinTime = 1.0f * fadeinTime / 10.0f;
        StartCoroutine("FadeInProcessing");    
    }

    IEnumerator FadeInProcessing()
    {
        // Colorのアルファ値を0.1ずつ下げていく
        for(var i = 1.0f; i >= 0; i -= 0.1f)
        {
            image.color = new Color(0.0f, 0.0f, 0.0f, i);

            yield return new WaitForSeconds(fadeinTime);
        }
    }
}
