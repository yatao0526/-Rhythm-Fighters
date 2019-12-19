using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScropt : MonoBehaviour
{
    public bool isGradientColourMove = false;
    [SerializeField] private float gradientColourMoveSpeet;
    private void Update()
    {
        GradientColourMove();
    }
    private void GradientColourMove()
    {
        if (isGradientColourMove && GetComponent<Image>().color.a < 1)
        {
            this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.b, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.a + (gradientColourMoveSpeet * Time.deltaTime));
            if (GetComponent<Image>().color.a <= 0)
            {
                isGradientColourMove = false;
            }
        }
    }
}
