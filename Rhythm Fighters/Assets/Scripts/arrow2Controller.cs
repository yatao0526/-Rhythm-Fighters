using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow2Controller : MonoBehaviour
{
    public int charNum_2 = 6;
    //選択されたキャラのナンバー数を設定

    // Start is called before the first frame update
    void Start()
    {
        GameObject arrow2;
        arrow2 = GameObject.Find("arrow2");

    }

    // Update is called once per frame
    void FixedUpdate()

    {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (charNum_2 == 1)
            {
                charNum_2 = 6;
            }
            else
            {
                charNum_2 = charNum_2 - 1;
            }
            Debug.Log("hitari" + charNum_2);
        }
        //左へ移動


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (charNum_2 == 6)
            {
                charNum_2 = 1;
            }
            else
            {
                charNum_2 = charNum_2 + 1;
            }
            Debug.Log("migi" + charNum_2);
        }
        //右へ移動

        switch (charNum_2)
        {
            case 1:
                this.transform.position = new Vector3(335, 320, 0);
                break;
            //キャラ１の位置に移動
            case 2:
                this.transform.position = new Vector3(585, 320, 0);
                break;
            //キャラ2の位置に移動
            case 3:
                this.transform.position = new Vector3(835, 320, 0);
                break;
            //キャラ3の位置に移動
            case 4:
                this.transform.position = new Vector3(1085, 320, 0);
                break;
            //キャラ4の位置に移動
            case 5:
                this.transform.position = new Vector3(1335, 320, 0);
                break;
            //キャラ5の位置に移動
            case 6:
                this.transform.position = new Vector3(1585, 320, 0);
                break;
                //キャラ6の位置に移動


        }

    }
}
