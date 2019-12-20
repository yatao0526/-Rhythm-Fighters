using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonBlink : MonoBehaviour
{

    [SerializeField] private float _blinkSpeed;

    private Text _pushText;
    private float _blinktime;

    void Start()
    {
        _pushText = GetComponent<Text>();
    }

    void Update()
    {
        _pushText.color = AlphaColor(_pushText.color);
    }
    private Color AlphaColor(Color color)
    {
        _blinktime += Time.deltaTime * 5.0f * _blinkSpeed;
        color.a = Mathf.Sin(_blinktime) * 0.5f + 0.5f;
        return color;
    }
}
