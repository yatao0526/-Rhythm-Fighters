using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInRange : MonoBehaviour
{
    [SerializeField]
    private Renderer targetRenderer;

    void Start()
    {
        targetRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (targetRenderer.isVisible)
        {
            Debug.Log("カメラの範囲内");
        }
        else
        {
            Debug.Log("カメラの範囲外");
        }
    }
}
