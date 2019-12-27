using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Chara
{
    MIYAZAWA = 0,
    SUZUKI = 1,
    NITSUMA = 2,
    NEGISHI = 3,
    YOKOYAMA = 4,
    LUO = 5
}
public enum Attack
{
    LightPunch,
    HeavyPunch,
    Comand1,
    Comand2
}

public class GameController : MonoBehaviour
{
    //ゲームモード管理
    public enum ModeType
    {
        normalMode,
        negationMode
    }
    public static ModeType modeType = ModeType.normalMode;

    [SerializeField]
    private GameObject[] judge;                 //判定
    [SerializeField]
    private GameObject[] Notes;                 //Notes(Prefab)入れてる
    [SerializeField]
    private float timeOut;                      //生成する秒
    [SerializeField]
    private Text text;                          //確認用のテキスト
    [SerializeField]
    private NegationMode negationMode;
    [SerializeField]
    private Player1 player1;
    [SerializeField]
    private Player2 player2;
    [SerializeField]
    private Image buton;
    [SerializeField]
    private Sprite[] buttonImage;

    private NoteObjectPool poolL, poolR;        //objectpool参照
    
    private float judgeTime;                    //判定用タイム
    private float audioTime;                    //判定補助タイマー（BGM開始時間指定用）
    private float time = 0;

    private static bool soundPlaying = false;   //test用、BGMか流しているかどうかの判断

    public GameObject soundManager;             //test用、soundManager
    
    private void Awake()
    {
        poolL = GetComponent<NoteObjectPool>();
        poolR = GetComponent<NoteObjectPool>();
        poolL.CreatePoolL(Notes[0], 10);
        poolR.CreatePoolR(Notes[1], 10);
    }
    private void FixedUpdate()
    {
        //Debug.Log(modeType);
        MoveTime();
        //テスト用テキスト
        if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.A)) || 
            (Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            switch (NotesController.judge)
            {
                case true:
                    text.text = "OK";
                    break;
                case false:
                    text.text = "NG";
                    break;
            }
            switch (NotesController.negation2PFlag)
            {
                case true:
                    text.text = "打消し中OK";
                    break;
                case false:
                    text.text = "打消し中NG";
                    break;
            }
        }
        //ボタン押す目あす
        switch (NotesController.judge)
        {
            case true:
                buton.sprite = buttonImage[0];
                break;
            case false:
                buton.sprite = buttonImage[1];
                break;
        }
        //AudioSourceがloop時発生するズレ修正
        if (soundManager.GetComponent<AudioSource>().time - time < 0)
        {
            judgeTime = (time % 0.75f + soundManager.GetComponent<AudioSource>().time);
        }
        //真ん中になる時、判定を出す
        if (NotesController.getActive)
        {
            player1.Move1PAction();
            player2.Move2PAction();

            if (Player1.negationButton1P)
            {
                Player1.negationButton1P = false;
            }
            else
            {
                GameController.modeType = GameController.ModeType.normalMode;
            }
            if (Player2.negationButton2P)
            {
                Player2.negationButton2P = false;
            }
            else
            {
                GameController.modeType = GameController.ModeType.normalMode;
            }
            //Debug.Log("判定");
            //Debug.Log(audioTime);
            NotesController.getActive = false;
        }
        //BGM流す
        if (soundPlaying == false && audioTime >= 0.75f)//ノーズの流すスピードで計算（=9.5/10-0.2(反応スピード)）
        {
            soundPlaying = true;
            soundManager.GetComponent<AudioSource>().Play();
        }
        //ズレ修正用
        time = soundManager.GetComponent<AudioSource>().time;
    }
    private void MoveTime()
    {
        judgeTime += Time.deltaTime;
        audioTime += Time.deltaTime;
        if (judgeTime >= timeOut)
        {
            poolL.GetGameObjL();
            poolR.GetGameObjR();
            judgeTime -= timeOut;//ズレ修正
        }
    }
}