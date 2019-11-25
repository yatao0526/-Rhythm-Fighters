using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageGradientColour : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGradientColourMove = false;
    [SerializeField] private float gradientColourMoveSpeet;
    // Update is called once per frame
    void Update()
    {
        GradientColourMove();

    }
    void GradientColourMove(){
        if (isGradientColourMove && GetComponent<Image>().color.a > 0)
        {
            this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.b, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.a - (gradientColourMoveSpeet * Time.deltaTime));
            if (GetComponent<Image>().color.a <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
