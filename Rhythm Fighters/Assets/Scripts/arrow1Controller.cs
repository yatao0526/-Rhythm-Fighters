using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow1Controller : MonoBehaviour
{
    public int charNum_1=1;
    //選択されたキャラのナンバー数を設定

    // Start is called before the first frame update
    void Start()
    {
        GameObject arrow1;
        
        arrow1 = GameObject.Find("arrow1");
       
    }

    // Update is called once per frame
    void FixedUpdate()
         
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            
            if (charNum_1 == 1)
            {
                charNum_1 = 6;
            }else
            {
                charNum_1 = charNum_1 - 1;
            }
            Debug.Log("hitari" + charNum_1);
        }
        //左へ移動


        if (Input.GetKeyDown(KeyCode.D))
        {
            
            if (charNum_1 == 6)
            {
                charNum_1 = 1;
            }
            else
            {
                charNum_1 = charNum_1 + 1;
            }
            Debug.Log("migi" + charNum_1);
        }
        //右へ移動

        switch (charNum_1)
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
