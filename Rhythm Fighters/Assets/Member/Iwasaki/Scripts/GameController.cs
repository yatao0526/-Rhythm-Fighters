using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //判定
    [SerializeField]
    private GameObject[] judge;
    //Notes(Prefab)入れてる
    [SerializeField]
    private GameObject[] Notes;
    //生成する秒
    [SerializeField]
    private float timeOut;
    //テスト用のテキスト(モック終わったら消す)
    [SerializeField]
    private Text text;
    //objectpool参照
    private NoteObjectPool poolL, poolR;

    //判定用タイム
    private float judgeTime;
    //判定補助タイマー（BGM開始時間指定用）
    private float audioTime;

    //test用、soundManager
    public GameObject soundManager;
    //test用、BGMか流しているかどうかの判断
    private static bool soundPlaying = false;
    private float time = 0;

    [SerializeField]
    Player1 player1;

    private void Awake()
    {
        poolL = GetComponent<NoteObjectPool>();
        poolR = GetComponent<NoteObjectPool>();
        poolL.CreatePoolL(Notes[0], 10);
        poolR.CreatePoolR(Notes[1], 10);
    }
    private void FixedUpdate()
    {
        MoveTime();
        //テスト用テキスト
        if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.RightArrow)))
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
        }
        //AudioSourceがloop時発生するズレ修正
        if (soundManager.GetComponent<AudioSource>().time - time < 0)
        {
            judgeTime = (time % 0.75f + soundManager.GetComponent<AudioSource>().time);
            //Debug用
            //Debug.Log("loop");
            //Debug.Log("time = " + time);
            //Debug.Log("time%0.75 = " + (time%0.75f));
            //Debug.Log(soundManager.GetComponent<AudioSource>().time);
            //Debug.Log("judgeTime = " + judgeTime);
        }
        //真ん中になる時、判定を出す
        if (NotesController.getActive)
        {
            player1.MoveAction();
            Debug.Log("判定");
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

