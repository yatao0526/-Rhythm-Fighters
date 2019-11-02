using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arroｗController : MonoBehaviour
{
    public int charNum=1;
    //選択されたキャラのナンバー数を設定

    // Start is called before the first frame update
    void Start()
    {
        GameObject arrow;
        arrow = GameObject.Find("arrow");
       
    }

    // Update is called once per frame
    void FixedUpdate()
         
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            if (charNum == 1)
            {
                charNum = 6;
            }else
            {
                charNum = charNum - 1;
            }
            Debug.Log("hitari" + charNum);
        }
        //左へ移動


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            
            if (charNum == 6)
            {
                charNum = 1;
            }
            else
            {
                charNum = charNum + 1;
            }
            Debug.Log("migi" + charNum);
        }
        //右へ移動

        switch (charNum)
        {
            case 1:
                this.transform.position = new Vector3(335, 760, 0);
                break;
                //キャラ１の位置に移動
            case 2:
                this.transform.position = new Vector3(585, 760, 0);
                break;
                //キャラ2の位置に移動
            case 3:
                this.transform.position = new Vector3(835, 760, 0);
                break;
                //キャラ3の位置に移動
            case 4:
                this.transform.position = new Vector3(1085, 760, 0);
                break;
                //キャラ4の位置に移動
            case 5: 
                this.transform.position = new Vector3(1335, 760, 0);
                break;
                //キャラ5の位置に移動
            case 6:
                this.transform.position = new Vector3(1585, 760, 0);
                break;
                //キャラ6の位置に移動


        }

    }
}
