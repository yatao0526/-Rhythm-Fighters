using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow1Controller : MonoBehaviour
{
    public int charNum_1=1;
    public int charNum_2 = 6;
    public GameObject[] characters = new GameObject[6];
    public GameObject arrow1;
    public GameObject arrow2;
    //選択されたキャラのナンバー数を設定

    // Start is called before the first frame update
    void Start()
    {
        
        
        arrow1 = GameObject.Find("arrow1");


        
        arrow2 = GameObject.Find("arrow2");

    }

    // Update is called once per frame
    void Update()

    {

        Player2Move();
        Player1Move();

    }
    void Player1Move() {
        //--------Player1 Y320

        if (Input.GetKeyDown(KeyCode.A))
        {
            //左へ移動
            charNum_1--;
            if (charNum_2 == charNum_1)
            {
                charNum_1--;
            }
            if (charNum_1 < 0) {
                charNum_1 = 5;      
            }
           
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
           
            charNum_1++;
            if (charNum_1 == charNum_2)
            {
                charNum_1++;
            }
            if (charNum_1 > 5)
            {
                charNum_1 = 0;
            }
           
        }
        arrow1.transform.position = new Vector3(characters[charNum_1].transform.position.x, 320, 0);
      
    }
    void Player2Move() {
       
        //-----------------Player2Y760
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            charNum_2--;
            if (charNum_2 == charNum_1)
            {
                charNum_2--;
            }
            if (charNum_2 < 0)
            {
                charNum_2 = 5;
            }
           
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //左へ移動
            charNum_2++;

            if (charNum_2 == charNum_1)
            {
                charNum_2++;
            }
            if (charNum_2 > 5)
            {
                charNum_2 = 0;
            }

        }
        
        arrow2.transform.position = new Vector3(characters[charNum_2].transform.position.x, 760, 0);

    }
}
