using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class arrow1Controller : MonoBehaviour
{
    public int charNum_1=1;
    public int charNum_2 = 6;
    public GameObject[] characters = new GameObject[6];
    public GameObject arrow1;
    public GameObject arrow2;
    public bool player1PCharacter = false;
    public bool player2PCharacter = false;
    public Image player1_Icon;
    public Image player2_Icon;
    public Image player1_Comment;
    public Image player2_Comment;
    public Sprite[]player_Comments= new Sprite[6];
    public Sprite[]player_Icons= new Sprite[6];



    //選択されたキャラのナンバー数を設定

    // Start is called before the first frame update
    void Start()
    {
        
        
        arrow1 = GameObject.Find("arrow1");
        arrow2 = GameObject.Find("arrow2");
        arrow1.transform.position = new Vector3(characters[charNum_1].transform.position.x, 320, 0);
        arrow2.transform.position = new Vector3(characters[charNum_2].transform.position.x, 760, 0);
        player1_Icon.sprite = player_Icons[charNum_1];
        player1_Comment.sprite = player_Comments[charNum_1];
        player2_Icon.sprite = player_Icons[charNum_2];
        player2_Comment.sprite = player_Comments[charNum_2];
    }

    // Update is called once per frame
    void Update()

    {

        Player2Move();
        Player1Move();
        if (player1PCharacter && player2PCharacter) {
            Debug.Log("1P" + characters[charNum_1]+ "2P" + characters[charNum_2]);

            //次のシーンへ
            SceneManager.LoadScene("Game");
        }
 
    }
    void Player1Move() {
        //--------Player1 Y320
        if (!player1PCharacter) { 
        if (Input.GetKeyDown(KeyCode.A))
        {
            //左へ移動
            characters[charNum_1].GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f);
            charNum_1--;
           
            if (charNum_1 < 0) {
                charNum_1 = 5;      
            }
            if (charNum_2 == charNum_1)
            {
                charNum_1--;
                if (charNum_1 < 0)
                {
                    charNum_1 = 5;
                }
            }
          

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            characters[charNum_1].GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f);
            charNum_1++;
          
            if (charNum_1 > 5)
            {
                charNum_1 = 0;
            }
            if (charNum_1 == charNum_2)
            {
                charNum_1++;
                if (charNum_1 > 5)
                {
                    charNum_1 = 0;
                }
            }
           

        }
        arrow1.transform.position = new Vector3(characters[charNum_1].transform.position.x, 320, 0);
            player1_Icon.sprite = player_Icons[charNum_1];
            player1_Comment.sprite = player_Comments[charNum_1];

            if (Input.GetKeyDown(KeyCode.E) && !player1PCharacter)
            {
                player1PCharacter = true;
               
            }
            if (player1PCharacter) { characters[charNum_1].GetComponent<Image>().color = new Color(255.0f / 255.0f, 8 / 255.0f, 0 / 255.0f, 255 / 255.0f); }
            else {
                characters[charNum_1].GetComponent<Image>().color = new Color(255.0f / 255.0f, 8 / 255.0f, 0 / 255.0f, 130 / 255.0f);
            }
        }
    }
    void Player2Move()
    {
        if (!player2PCharacter)
        {
            //-----------------Player2Y760
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                characters[charNum_2].GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f);
                charNum_2--;

                if (charNum_2 < 0)
                {
                    charNum_2 = 5;
                }
                if (charNum_2 == charNum_1)
                {
                    charNum_2--;
                    if (charNum_2 < 0)
                    {
                        charNum_2 = 5;
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                characters[charNum_2].GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f);
                //左へ移動
                charNum_2++;
                if (charNum_2 > 5)
                {
                    charNum_2 = 0;
                }
                if (charNum_2 == charNum_1)
                {
                    charNum_2++;
                    if (charNum_2 > 5)
                    {
                        charNum_2 = 0;
                    }
                }


            }

            arrow2.transform.position = new Vector3(characters[charNum_2].transform.position.x, 760, 0);
            player2_Icon.sprite = player_Icons[charNum_2];
            player2_Comment.sprite = player_Comments[charNum_2];

            if (Input.GetKeyDown(KeyCode.Space)&& !player2PCharacter)
            {
                player2PCharacter = true;
             
            }
            if (player2PCharacter) { characters[charNum_2].GetComponent<Image>().color = new Color(0 / 255.0f, 62 / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f); }
            else { characters[charNum_2].GetComponent<Image>().color = new Color(0 / 255.0f, 62 / 255.0f, 255.0f / 255.0f, 130.0f / 255.0f); }
        }
    }
}
