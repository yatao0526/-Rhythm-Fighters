using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectPlayersController : MonoBehaviour
{
    private bool PS1Con = true;
    private bool PS2Con = true;

    [SerializeField]
    private Image Common1, Common2;

    // charNum_1　   charNum_2プレイヤーが選択しているキャラクター, stageNum選択するステージ
    [SerializeField]
    private int charNumMAX;

    private int charNum_1 = 0, charNum_2 = 3, stageMoves = 0, stageNumMAX = 3;

    public int stageNum = 1;

    [SerializeField]
    private float gradientColourMoveSpeet = 0.5f;

    //キャラクター達
    [SerializeField]
    private GameObject[] characters = new GameObject[6];
    [SerializeField]
    private GameObject[] backgroundGameObjects = new GameObject[3];

    //今だれか何か選択してる　赤い 青い//Backgroundは背景,
    [SerializeField]
    private GameObject arrow1, arrow2, Background;

    //player1PCharacter　player2PCharacter　　キャラクターの選択が終わったか　isPlayer1　プレイヤー１先に選択終わったか　isStageController今ステージの選択すべきか
    private bool player1PCharacter = false, player2PCharacter = false, isPlayerSelection = false, isPlayer1 = false, isStageController = false;

    //選択したキャラクター
    //プレイヤーのアイコン　赤い　青い
    [SerializeField]
    private GameObject player1_Icon, player2_Icon;

    // [SerializeField] private Image player1_Icon, player2_Icon;
    //キャラクター画像//背景画像
    //　選択できる　キャラクターと背景の画像
    [SerializeField]
    private Sprite[] player_Icons = new Sprite[6], playerCharacterAffirmations = new Sprite[6], playerCharacters = new Sprite[6], Backgrounds = new Sprite[3];

    [SerializeField]
    private Sprite[] playerCommons;

    //選択の結果
    public static string player1PCharacterName, player2PCharacterName;

    private string stageName;

    private void Start()
    {
        charNum_2 = charNumMAX - 1;
        //Common1 = GameObject.Find("Player1_common");
        //Common2 = GameObject.Find("Player2_common");

        charNum_1 = charNum_1 % charNumMAX;
        arrow1.transform.position = new Vector3(characters[charNum_1].transform.position.x, 760, 0);
        player1_Icon.GetComponent<Image>().sprite = player_Icons[charNum_1];
        Common1.sprite = playerCommons[charNum_1];

        charNum_2 = charNum_2 % charNumMAX;
        arrow2.transform.position = new Vector3(characters[charNum_2].transform.position.x, 760, 0);
        player2_Icon.GetComponent<Image>().sprite = player_Icons[charNum_2];
        Common2.sprite = playerCommons[charNum_2];
        //  player2_Icon.sprite = player_Icons[charNum_2];

    }
    // Update is called once per frame
    private void Update()
    {
        PSConBool();
        Player1Move();
        Player2Move();
        DebugPlayer1Move();
        DebugPlayer2Move();
        PlayersStageController();
    }

    private void PSConBool()
    {
        if (Input.GetAxis("LeftRight") == 0.0f)
        {
            PS1Con = true;
        }
        if (Input.GetAxis("2PLeftRight") == 0.0f)
        {
            PS2Con = true;
        }
    }

    private void Player1Move()
    {
        if (Input.GetAxis("LeftRight") < -0.5 && !player1PCharacter && !isPlayerSelection && PS1Con)
        {
            PS1Con = false;
            SoundManager.Instance.PlaySe(SE.pinMove);
            // player1_Icon.GetComponent<Image>().sprite = player_Icons[charNum_1];
            characters[charNum_1].GetComponent<Image>().sprite = playerCharacters[charNum_1];
            characters[charNum_1].GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
            //左へ移動
            charNum_1--;
            if (charNum_1 % charNumMAX < 0)
            {
                // Debug.Log("  if (charNum_1 % charNumMAX <0)" + charNum_1);
                charNum_1 = charNumMAX - 1;
            }
            if (charNum_1 % charNumMAX == charNum_2 % charNumMAX)
            {
                charNum_1--;
            }
            if (charNum_1 % charNumMAX < 0)
            {
                // Debug.Log("  if (charNum_1 % charNumMAX <0)" + charNum_1);
                charNum_1 = charNumMAX - 1;
            }
        }
        else if (Input.GetAxis("LeftRight") > 0.5f && !player1PCharacter && !isPlayerSelection && PS1Con)
        {
            PS1Con = false;
            SoundManager.Instance.PlaySe(SE.pinMove);
            characters[charNum_1].GetComponent<Image>().sprite = playerCharacters[charNum_1];
            characters[charNum_1].GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
            charNum_1++;
            if (charNum_1 % charNumMAX == charNum_2 % charNumMAX)
            {
                charNum_1++;
            }
        }
        charNum_1 = charNum_1 % charNumMAX;

        // player1_Icon.sprite = player_Icons[charNum_1];
        if (arrow1 != null)
        {
            player1_Icon.GetComponent<Image>().sprite = player_Icons[charNum_1];
            Common1.sprite = playerCommons[charNum_1];
            arrow1.transform.position = new Vector3(characters[charNum_1].transform.position.x, 580, 0);//760>580
        }

        if (Input.GetButtonDown("Maru") && !player1PCharacter && !isPlayerSelection)
        {
            SoundManager.Instance.PlaySe(SE.charSelect);
            player1PCharacter = true;
            PlayerSelectionMove();
        }

        //選択するまだ選択直し処理
        else if (Input.GetButtonDown("Maru") && player1PCharacter && !isPlayerSelection)
        {
            player1PCharacter = false;
        }

        if (player1PCharacter)
        {
            //characters[charNum_1].GetComponent<Image>().color = new Color(255.0f / 255.0f, 8 / 255.0f, 0 / 255.0f, 255 / 255.0f);
            characters[charNum_1].GetComponent<Image>().sprite = playerCharacterAffirmations[charNum_1];
        } //選択した表示
        else
        {
            //characters[charNum_1].GetComponent<Image>().color = new Color(255.0f / 255.0f, 8 / 255.0f, 0 / 255.0f, 130 / 255.0f);
            characters[charNum_1].GetComponent<Image>().sprite = playerCharacterAffirmations[charNum_1];
        }
    }

    private void Player2Move()
    {
        if (Input.GetAxis("2PLeftRight") < -0.5 && !player2PCharacter && !isPlayerSelection && PS2Con)
        {
            PS2Con = false;
            SoundManager.Instance.PlaySe(SE.pinMove);
            characters[charNum_2].GetComponent<Image>().sprite = playerCharacters[charNum_2];
            characters[charNum_2].GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
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
            if (charNum_2 % charNumMAX < 0)
            {
                charNum_2 = charNumMAX - 1;
            }

        }
        else if (Input.GetAxis("2PLeftRight") > 0.5f && !player2PCharacter && !isPlayerSelection && PS2Con)
        {
            PS2Con = false;
            SoundManager.Instance.PlaySe(SE.pinMove);
            characters[charNum_2].GetComponent<Image>().sprite = playerCharacters[charNum_2];
            characters[charNum_2].GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
            charNum_2++;

            if (charNum_1 % charNumMAX == charNum_2 % charNumMAX)
            {
                charNum_2++;
            }

        }
        charNum_2 = charNum_2 % charNumMAX;
        if (arrow2 != null)
        {
            arrow2.transform.position = new Vector3(characters[charNum_2].transform.position.x, 580, 0);//760>580
            player2_Icon.GetComponent<Image>().sprite = player_Icons[charNum_2];
            Common2.sprite = playerCommons[charNum_2];
        }

        // player2_Icon.sprite = player_Icons[charNum_2];
        if (Input.GetButtonDown("2PMaru") && !player2PCharacter && !isPlayerSelection)
        {
            SoundManager.Instance.PlaySe(SE.charSelect);
            player2PCharacter = true;
            PlayerSelectionMove();
        }
        else if (Input.GetButtonDown("2PMaru") && player2PCharacter && !isPlayerSelection)
        {
            player2PCharacter = false;
        }
        if (player2PCharacter)
        {
            characters[charNum_2].GetComponent<Image>().sprite = playerCharacterAffirmations[charNum_2];
            //characters[charNum_2].GetComponent<Image>().color = new Color(0 / 255.0f, 62 / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f); 
        }
        else
        {
            characters[charNum_2].GetComponent<Image>().sprite = playerCharacterAffirmations[charNum_2];
            //characters[charNum_2].GetComponent<Image>().color = new Color(0 / 255.0f, 62 / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f); 
        }
    }

    private void DebugPlayer1Move()
    {
        if (Input.GetKeyDown(KeyCode.A) && !player1PCharacter && !isPlayerSelection)
        {
            SoundManager.Instance.PlaySe(SE.pinMove);
            // player1_Icon.GetComponent<Image>().sprite = player_Icons[charNum_1];
            characters[charNum_1].GetComponent<Image>().sprite = playerCharacters[charNum_1];
            characters[charNum_1].GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
            //左へ移動
            charNum_1--;
            if (charNum_1 % charNumMAX < 0)
            {
                // Debug.Log("  if (charNum_1 % charNumMAX <0)" + charNum_1);
                charNum_1 = charNumMAX - 1;
            }
            if (charNum_1 % charNumMAX == charNum_2 % charNumMAX)
            {
                charNum_1--;
            }
            if (charNum_1 % charNumMAX < 0)
            {
                // Debug.Log("  if (charNum_1 % charNumMAX <0)" + charNum_1);
                charNum_1 = charNumMAX - 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) && !player1PCharacter && !isPlayerSelection)
        {
            SoundManager.Instance.PlaySe(SE.pinMove);
            characters[charNum_1].GetComponent<Image>().sprite = playerCharacters[charNum_1];
            characters[charNum_1].GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
            charNum_1++;
            if (charNum_1 % charNumMAX == charNum_2 % charNumMAX)
            {
                charNum_1++;
            }
        }
        charNum_1 = charNum_1 % charNumMAX;

        // player1_Icon.sprite = player_Icons[charNum_1];
        if (arrow1 != null)
        {
            player1_Icon.GetComponent<Image>().sprite = player_Icons[charNum_1];
            Common1.sprite = playerCommons[charNum_1];
            arrow1.transform.position = new Vector3(characters[charNum_1].transform.position.x, 580, 0);//760>580
        }

        if (Input.GetKeyDown(KeyCode.E) && !player1PCharacter && !isPlayerSelection)
        {
            SoundManager.Instance.PlaySe(SE.charSelect);
            player1PCharacter = true;
            PlayerSelectionMove();
        }

        //選択するまだ選択直し処理
        else if (Input.GetKeyDown(KeyCode.E) && player1PCharacter && !isPlayerSelection)
        {
            player1PCharacter = false;
        }

        if (player1PCharacter)
        {
            //characters[charNum_1].GetComponent<Image>().color = new Color(255.0f / 255.0f, 8 / 255.0f, 0 / 255.0f, 255 / 255.0f);
            characters[charNum_1].GetComponent<Image>().sprite = playerCharacterAffirmations[charNum_1];
        } //選択した表示
        else
        {
            //characters[charNum_1].GetComponent<Image>().color = new Color(255.0f / 255.0f, 8 / 255.0f, 0 / 255.0f, 130 / 255.0f);
            characters[charNum_1].GetComponent<Image>().sprite = playerCharacterAffirmations[charNum_1];
        }
    }

    private void DebugPlayer2Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !player2PCharacter && !isPlayerSelection)
        {
            SoundManager.Instance.PlaySe(SE.pinMove);
            characters[charNum_2].GetComponent<Image>().sprite = playerCharacters[charNum_2];
            characters[charNum_2].GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
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
            if (charNum_2 % charNumMAX < 0)
            {
                charNum_2 = charNumMAX - 1;
            }

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !player2PCharacter && !isPlayerSelection)
        {
            SoundManager.Instance.PlaySe(SE.pinMove);
            characters[charNum_2].GetComponent<Image>().sprite = playerCharacters[charNum_2];
            characters[charNum_2].GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
            charNum_2++;

            if (charNum_1 % charNumMAX == charNum_2 % charNumMAX)
            {
                charNum_2++;
            }

        }
        charNum_2 = charNum_2 % charNumMAX;
        if (arrow2 != null)
        {
            arrow2.transform.position = new Vector3(characters[charNum_2].transform.position.x, 580, 0);//760>580
            player2_Icon.GetComponent<Image>().sprite = player_Icons[charNum_2];
            Common2.sprite = playerCommons[charNum_2];
        }

        // player2_Icon.sprite = player_Icons[charNum_2];
        if (Input.GetKeyDown(KeyCode.Space) && !player2PCharacter && !isPlayerSelection)
        {
            SoundManager.Instance.PlaySe(SE.charSelect);
            player2PCharacter = true;
            PlayerSelectionMove();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && player2PCharacter && !isPlayerSelection)
        {
            player2PCharacter = false;
        }
        if (player2PCharacter)
        {
            characters[charNum_2].GetComponent<Image>().sprite = playerCharacterAffirmations[charNum_2];
            //characters[charNum_2].GetComponent<Image>().color = new Color(0 / 255.0f, 62 / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f); 
        }
        else
        {
            characters[charNum_2].GetComponent<Image>().sprite = playerCharacterAffirmations[charNum_2];
            //characters[charNum_2].GetComponent<Image>().color = new Color(0 / 255.0f, 62 / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f); 
        }
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
            //Debug.Log("1P" + characters[charNum_1] + "                   2P" + characters[charNum_2] + "1pがステージを選択か」" + isPlayer1);
            CharactersGradientColour();
        }
    }
    //ステージ選択画面の演出
    //選択されてなかったキャラクター消す
    private void CharactersGradientColour()
    {

        Common1.gameObject.SetActive(false);
        Common2.gameObject.SetActive(false);
        //  Debug.Log("CharactersGradientColour");
        for (int charactersSprite = 0; charactersSprite < charNumMAX; charactersSprite++)
        {
            //  Debug.Log("int charactersSprite = 0; charactersSprite < 6; charactersSprite++)");
            if (charactersSprite != charNum_1 && charactersSprite != charNum_2)
            {//削除したい画像はプレイヤーが選択した画像なら
             //    Debug.Log(" if (charactersSprite != charNum_1 && charactersSprite != charNum_2)" + charactersSprite);
                characters[charactersSprite].GetComponent<ImageGradientColour>().gradientColourMoveSpeet = gradientColourMoveSpeet;
                characters[charactersSprite].GetComponent<ImageGradientColour>().isGradientColourMove = true;
                //   Debug.Log("    characters[charactersSprite].GetComponent<ImageGradientColour>().gradientColourMove = true;" + characters[charactersSprite].GetComponent<ImageGradientColour>().isGradientColourMove);
            }
            arrow1.GetComponent<ImageGradientColour>().gradientColourMoveSpeet = gradientColourMoveSpeet - 0.1f;
            arrow1.GetComponent<ImageGradientColour>().isGradientColourMove = true;
            arrow2.GetComponent<ImageGradientColour>().gradientColourMoveSpeet = gradientColourMoveSpeet - 0.1f;
            arrow2.GetComponent<ImageGradientColour>().isGradientColourMove = true;
            player1_Icon.GetComponent<ImageGradientColour>().gradientColourMoveSpeet = gradientColourMoveSpeet - 0.1f;
            player1_Icon.GetComponent<ImageGradientColour>().isGradientColourMove = true;
            player2_Icon.GetComponent<ImageGradientColour>().gradientColourMoveSpeet = gradientColourMoveSpeet - 0.1f;
            player2_Icon.GetComponent<ImageGradientColour>().isGradientColourMove = true;


            CardsPosXMove();
        }
    }//選択されたキャラクター各場所に転移
    private void CardsPosXMove()
    {
        characters[charNum_1].GetComponent<ImageGradientColour>().myX = 160;
        characters[charNum_1].GetComponent<ImageGradientColour>().isCardPosXMove = true;
        characters[charNum_2].GetComponent<ImageGradientColour>().myX = 1760;
        characters[charNum_2].GetComponent<ImageGradientColour>().isCardPosXMove = true;
        characters[charNum_2].transform.eulerAngles = new Vector3(0, 180, 0);
        Invoke("stageMove", 3.0f);
    }
    //ステージ選択開始
    private void stageMove()
    {
        CharacterSelectPlayersControllerEnd();

        //if (stageMoves < 3)
        //{
        //    backgroundGameObjects[stageMoves].transform.position = new Vector3(backgroundGameObjects[stageMoves].transform.position.x, 150);
        //    backgroundGameObjects[stageMoves].GetComponent<BackgroundScropt>().isGradientColourMove = true;
        //    stageMoves++;
        //    Invoke("stageMove", stageMoves * 3);
        //}
        //else
        //{
        //    //ステージ選択できるようになった
        //    isStageController = true;
        //    Background.GetComponent<Image>().sprite = backgroundGameObjects[1].GetComponent<Image>().sprite;
        //}
    }
    //ステージ選択入力
    private void PlayersStageController()
    {

        if (isStageController && isPlayer1)
        {
            if ((Input.GetKeyDown(KeyCode.A)) || (Input.GetAxis("LeftRight") < -0.5))
            {
                backgroundGameObjects[stageNum].GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
                stageNum--;
                if (stageNum % stageNumMAX < 0)
                {
                    stageNum = stageNumMAX - 1;
                }
                Background.GetComponent<BackgroundMoveScript>().speedTime = 1.0f;
            }
            else if ((Input.GetKeyDown(KeyCode.D)) || (Input.GetAxis("LeftRight") > 0.5f))
            {
                backgroundGameObjects[stageNum].GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
                stageNum++;
                Background.GetComponent<BackgroundMoveScript>().speedTime = 1.0f;
            }
            else if ((Input.GetKeyDown(KeyCode.E)) || (Input.GetButtonDown("Maru")))
            {
                CharacterSelectPlayersControllerEnd();
            }
            stageNum = stageNum % stageNumMAX;
            Background.GetComponent<BackgroundMoveScript>().myX = stageNum;
            //  Background.GetComponent<Image>().sprite = backgroundGameObjects[stageNum].GetComponent<Image>().sprite;
            backgroundGameObjects[stageNum].GetComponent<Image>().color = new Color(255.0f / 255.0f, 8 / 255.0f, 0 / 255.0f, 255.0f / 255.0f);
        }
        else if (isStageController && !isPlayer1)
        {
            if ((Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetAxis("2PLeftRight") < -0.5))
            {
                backgroundGameObjects[stageNum].GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
                stageNum--;
                if (stageNum % stageNumMAX < 0)
                {
                    stageNum = stageNumMAX - 1;
                }
                Background.GetComponent<BackgroundMoveScript>().speedTime = 1.0f;
            }
            else if ((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetAxis("2PLeftRight") > 0.5f))
            {
                backgroundGameObjects[stageNum].GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
                stageNum++;
                Background.GetComponent<BackgroundMoveScript>().speedTime = 1.0f;
            }
            else if (Input.GetKeyDown(KeyCode.Space) || (Input.GetButtonDown("2PMaru")))
            {
                CharacterSelectPlayersControllerEnd();
            }
            stageNum = stageNum % stageNumMAX;

            Background.GetComponent<BackgroundMoveScript>().myX = stageNum;

            //  Background.GetComponent<Image>().sprite = backgroundGameObjects[stageNum].GetComponent<Image>().sprite;
            backgroundGameObjects[stageNum].GetComponent<Image>().color = new Color(0 / 255.0f, 62 / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
        }
    }

    //最終結果　データを他のスクリプト出す処理
    private void CharacterSelectPlayersControllerEnd()
    {
        isStageController = false;
        player1PCharacterName = characters[charNum_1].name;
        player2PCharacterName = characters[charNum_2].name;
        stageName = backgroundGameObjects[stageNum].name;
        Debug.Log(" プレイヤー1Pのキャラクター" + player1PCharacterName + "です," + " プレイヤー2Pのキャラクター" + player2PCharacterName + "です," + " ステージは" + stageName + "です");

        Debug.Log("ステージ転移先と選択結果のデータ出し先は分からないので、まだ書いてません");
        //ステージ転移
        // SceneManager.LoadScene("Game");
        SceneManager.LoadScene("MainTest");
        //SceneManager.LoadScene("TestSelect");
        //データを他のスクリプト出す処理
    }
}
//キャラクター　
//顔向き
//ステージイメージ表す；
//選択開始