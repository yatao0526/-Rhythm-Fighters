using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class arrow1Controller : MonoBehaviour
{
    [SerializeField] private int charNum1 = 0,  charNum2 = 5, charNumMAX = 6;

      [SerializeField] private int charNum_1 = 0, charNum_2 = 5;//いま選択しているキャラクター
    [SerializeField] private GameObject[] characters = new GameObject[6];//キャラクター達
    [SerializeField] private GameObject arrow1, arrow2, Background;//今だれか何か選択してる　赤い 青い
    [SerializeField] private bool player1PCharacter = false, player2PCharacter = false;//選択確認
    [SerializeField] private Image player1_Icon, player2_Icon;//選択したキャラクター
    [SerializeField] private Sprite[] player_Icons = new Sprite[6], Backgrounds = new Sprite[3];//キャラクター画像

    //選択されたキャラのナンバー数を設定

    // Start is called before the first frame update
    void Start()
    {
        charNum_1 = charNum1 % charNumMAX;
        arrow1 = GameObject.Find("arrow1");
        arrow1.transform.position = new Vector3(characters[charNum_1].transform.position.x, 320, 0);
        player1_Icon.sprite = player_Icons[charNum_1];

        charNum_2 = charNum2 % charNumMAX;
        arrow2 = GameObject.Find("arrow2");
        arrow2.transform.position = new Vector3(characters[charNum_2].transform.position.x, 760, 0);
        player2_Icon.sprite = player_Icons[charNum_2];

    }

    // Update is called once per frame
    void Update()
    {
        Player2Move();
        Player1Move();

        if (player1PCharacter && player2PCharacter)
        {
            Debug.Log("1P" + characters[charNum_1] + "2P" + characters[charNum_2]);

            //次のシーンへ
            SceneManager.LoadScene("Game");
        }

    }
    void Player1Move()
    {
        //--------Player1 Y320

        if (Input.GetKeyDown(KeyCode.A) && !player1PCharacter)
        {
            characters[charNum_1].GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f);
            //左へ移動
            charNum1--;
         
            charNum_1 = charNum1 % charNumMAX;
            if (charNum1 % charNumMAX <= 0) {
                charNum1 = charNumMAX;
            }
            if (charNum1 % charNumMAX == charNum2 % charNumMAX)
            {
                charNum1--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) && !player1PCharacter)
        {
            characters[charNum_1].GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f);
            charNum1++;
           
            if (charNum1 % charNumMAX == charNum2 % charNumMAX)
            {
                charNum1++;
            }

        }
        charNum_1 = charNum1 % charNumMAX;
        //
        player1_Icon.sprite = player_Icons[charNum_1];
        arrow1.transform.position = new Vector3(characters[charNum_1].transform.position.x, 320, 0);
       


       
        if (Input.GetKeyDown(KeyCode.E) && !player1PCharacter)
        {
            player1PCharacter = true;

        } //」選択するまだ選択直し処理
        else if (Input.GetKeyDown(KeyCode.E) && player1PCharacter)
        {
            player1PCharacter = false;
        }
       
        if (player1PCharacter)
        {
            characters[charNum_1].GetComponent<Image>().color = new Color(255.0f / 255.0f, 8 / 255.0f, 0 / 255.0f, 255 / 255.0f);
        } //選択した表示
        else
        {
            characters[charNum_1].GetComponent<Image>().color = new Color(255.0f / 255.0f, 8 / 255.0f, 0 / 255.0f, 130 / 255.0f);
        }

    }
    void Player2Move()
    {

        //-----------------Player2Y760
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !player2PCharacter)
        {
            characters[charNum_2].GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f);
            //左へ移動
            charNum2--;

         
            if (charNum2 % charNumMAX <= 0)
            {
                charNum2 = charNumMAX;
            }
            if (charNum2 % charNumMAX == charNum1 % charNumMAX)
            {
                charNum2--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !player2PCharacter)
        {
            characters[charNum_2].GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f);
            charNum2++;

            if (charNum1 % charNumMAX == charNum2 % charNumMAX)
            {
                charNum2++;
            }

        }
        charNum_2 = charNum2 % charNumMAX;
        arrow2.transform.position = new Vector3(characters[charNum_2].transform.position.x, 760, 0);
        player2_Icon.sprite = player_Icons[charNum_2];

        if (Input.GetKeyDown(KeyCode.Space) && !player2PCharacter)
        {
            player2PCharacter = true;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && player2PCharacter)
        {
            player2PCharacter = false;
        }
        if (player2PCharacter) { characters[charNum_2].GetComponent<Image>().color = new Color(0 / 255.0f, 62 / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f); }
        else { characters[charNum_2].GetComponent<Image>().color = new Color(0 / 255.0f, 62 / 255.0f, 255.0f / 255.0f, 130.0f / 255.0f); }

    }


}
