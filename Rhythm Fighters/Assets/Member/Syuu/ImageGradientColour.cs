using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageGradientColour : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGradientColourMove = false;
    [SerializeField] private float gradientColourMoveSpeet;
    //
    [SerializeField]
    private float speedTime = 2;
    [SerializeField]
    private float speed;
    [SerializeField]
    public int myX;
    [SerializeField]
    public bool isCardPosXMove = false;
    // Update is called once per frame
    private void Update()
    {
        GradientColourMove();
        CardPosXMove();

    }
   private void GradientColourMove() {
        if (isGradientColourMove && GetComponent<Image>().color.a > 0)
        {
            this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.b, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.a - (gradientColourMoveSpeet * Time.deltaTime));
            if (GetComponent<Image>().color.a <= 0)
            {
                Destroy(this.gameObject);
            }

        }
    }
   
    private void CardPosXMove()
    {
        if (isCardPosXMove)
        {


            speedTime -= Time.deltaTime;
            speed = (myX - transform.position.x) / speedTime;

            if (myX <1000) {
                if (transform.position.x != myX)//MyY最終地点
                {
                    transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y);//最終地点に動く
                }
            } else if (myX > 1000)
            {
                if (transform.position.x !=myX)//MyY最終地点
                {
                    transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y);//最終地点に動く
                }
            }
           
            if (speedTime <= 0)
            {
                speedTime = 0.0f;
                transform.position = new Vector3(myX, transform.position.y);

            }
        }

     
    }
}
