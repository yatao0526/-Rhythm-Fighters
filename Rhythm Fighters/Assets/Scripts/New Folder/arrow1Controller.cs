using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class arrow1Controller : MonoBehaviour
{

    //いま選択しているキャラクター
    [SerializeField] private int charNum_1 = 0, charNum_2 = 5, charNumMAX = 6;
    //キャラクター達
    [SerializeField] private GameObject[] characters = new GameObject[6];
    [SerializeField] private GameObject[] backgroundGameObjects = new GameObject[3];
    //今だれか何か選択してる　赤い 青い//Backgroundは背景
    [SerializeField] private GameObject arrow1, arrow2, Background;
    //選択確認
    [SerializeField] private bool player1PCharacter = false, player2PCharacter = false, isPlayerSelection = false, isPlayer1 = false;
    //選択したキャラクター

    [SerializeField] private Image player1_Icon, player2_Icon;
    //キャラクター画像//背景画像
    [SerializeField] private Sprite[] player_Icons = new Sprite[6], Backgrounds = new Sprite[3];

    //選択されたキャラのナンバー数を設定

    // Start is called before the first frame update
    private void Start()
    {
        charNum_1 = charNum_1 % charNumMAX;
        arrow1.transform.position = new Vector3(characters[charNum_1].transform.position.x, 320, 0);
        player1_Icon.sprite = player_Icons[charNum_1];

        charNum_2 = charNum_2 % charNumMAX;
        arrow2.transform.position = new Vector3(characters[charNum_2].transform.position.x, 760, 0);
        player2_Icon.sprite = player_Icons[charNum_2];

    }
    // Update is called once per frame
    private void Update()
    {
        Player2Move();
        Player1Move();


        //-test

        //--

    }
    private void Player1Move()
    {
        //--------Player1 Y320

        if (Input.GetKeyDown(KeyCode.A) && !player1PCharacter && !isPlayerSelection)
        {
            characters[charNum_1].GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f);
            //左へ移動
            charNum_1--;
            if (charNum_1 % charNumMAX < 0)
            {
                Debug.Log("  if (charNum_1 % charNumMAX <0)" + charNum_1);
                charNum_1 = charNumMAX - 1;
            }
            if (charNum_1 % charNumMAX == charNum_2 % charNumMAX)
            {
                charNum_1--;
            }


        }
        else if (Input.GetKeyDown(KeyCode.D) && !player1PCharacter && !isPlayerSelection)
        {
            characters[charNum_1].GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f);
            charNum_1++;

            if (charNum_1 % charNumMAX == charNum_2 % charNumMAX)
            {
                charNum_1++;
            }

        }
        charNum_1 = charNum_1 % charNumMAX;
        //
        player1_Icon.sprite = player_Icons[charNum_1];
        arrow1.transform.position = new Vector3(characters[charNum_1].transform.position.x, 320, 0);




        if (Input.GetKeyDown(KeyCode.E) && !player1PCharacter && !isPlayerSelection)
        {
            player1PCharacter = true;
            PlayerSelectionMove();
        } //選択するまだ選択直し処理
        else if (Input.GetKeyDown(KeyCode.E) && player1PCharacter && !isPlayerSelection)
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
    private void Player2Move()
    {

        //-----------------Player2Y760
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !player2PCharacter && !isPlayerSelection)
        {
            characters[charNum_2].GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f);
            //左へ移動
            charNum_2--;

            if (charNum_2 % charNumMAX < 0)
            {
                charNum_2 = charNumMAX - 1;
            }
            if (charNum_2 % charNumMAX == charNum_1 % charNumMAX)
            {
                charNum_2--;
            }

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !player2PCharacter && !isPlayerSelection)
        {
            characters[charNum_2].GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f);
            charNum_2++;

            if (charNum_1 % charNumMAX == charNum_2 % charNumMAX)
            {
                charNum_2++;
            }

        }
        charNum_2 = charNum_2 % charNumMAX;
        arrow2.transform.position = new Vector3(characters[charNum_2].transform.position.x, 760, 0);
        player2_Icon.sprite = player_Icons[charNum_2];

        if (Input.GetKeyDown(KeyCode.Space) && !player2PCharacter && !isPlayerSelection)
        {
            player2PCharacter = true;
            PlayerSelectionMove();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && player2PCharacter && !isPlayerSelection)
        {
            player2PCharacter = false;
        }
        if (player2PCharacter) { characters[charNum_2].GetComponent<Image>().color = new Color(0 / 255.0f, 62 / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f); }
        else { characters[charNum_2].GetComponent<Image>().color = new Color(0 / 255.0f, 62 / 255.0f, 255.0f / 255.0f, 130.0f / 255.0f); }

    }
    //誰か先に選択おしたか
    private void PlayerSelectionMove()
    {

        if (!player2PCharacter || !player1PCharacter)
        {

            if (player1PCharacter)
            {
                isPlayer1 = true;
            }
            else if (player2PCharacter)
            {
                isPlayer1 = false;
            }

        }
        PlayerSelection();
    }
    //キャラクター選択結果
    private void PlayerSelection()
    {
        if (player1PCharacter && player2PCharacter && !isPlayerSelection)
        {
            isPlayerSelection = true;
            Debug.Log("1P" + characters[charNum_1] + "                   2P" + characters[charNum_2] + "1pがステージを選択か」" + isPlayer1);
            CharactersGradientColour();
        }

    }
    //ステージ選択画面の演出

    //選択されてなかったキャラクター消す
    private void CharactersGradientColour()
    {
        Debug.Log("CharactersGradientColour");
        for (int charactersSprite = 0; charactersSprite < 6; charactersSprite++)
        {
            Debug.Log("int charactersSprite = 0; charactersSprite < 6; charactersSprite++)");
            if (charactersSprite != charNum_1 && charactersSprite != charNum_2)
            {//削除したい画像はプレイヤーが選択した画像なら
                Debug.Log(" if (charactersSprite != charNum_1 && charactersSprite != charNum_2)" + charactersSprite);
                characters[charactersSprite].GetComponent<ImageGradientColour>().isGradientColourMove = true;
                Debug.Log("    characters[charactersSprite].GetComponent<ImageGradientColour>().gradientColourMove = true;" + characters[charactersSprite].GetComponent<ImageGradientColour>().isGradientColourMove);
            }
            CardsPosXMove();
        }
    }
    private void CardsPosXMove()
    {
        characters[charNum_1].GetComponent<ImageGradientColour>().myX = 160;
        characters[charNum_1].GetComponent<ImageGradientColour>().isCardPosXMove = true;
        characters[charNum_2].GetComponent<ImageGradientColour>().myX = 1760;
        characters[charNum_2].GetComponent<ImageGradientColour>().isCardPosXMove = true;
        Debug.Log(characters[charNum_2].gameObject.transform.position.y);
        characters[charNum_2].transform.eulerAngles = new Vector3(0, 180, 0);
      
    }
    public GameObject AS;
    void Player1RotationYMove()
    {
        for (int i=0; i < 3; i++)
        {
             backgroundGameObjects[i].transform.position = new Vector3(transform.position.y, 200);
        }
    
    
        
    }
}
/*
 *  
 * 
 * 
 * 
 * 
 */

//キャラクター　
//顔向き
//ステージイメージ表す；
//選択開始





