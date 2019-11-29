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
    [SerializeField]
    private AudioSource audioSource;
    //objectpool参照
    private NoteObjectPool poolL, poolR;
    //判定用タイム
    private float judgeTime;
    //曲の時間
    private float audioTime;
    //
    [SerializeField]
    private int BPM;

    private void Awake()
    {
        poolL = GetComponent<NoteObjectPool>();
        poolR = GetComponent<NoteObjectPool>();
        poolL.CreatePoolL(Notes[0], 10);
        poolR.CreatePoolR(Notes[1], 10);
    }
    private void Start()
    {
        //テスト用の曲を200に無理やりしてる後で消す
        audioSource.pitch = audioSource.pitch + 0.5f;
        timeOut = 240 / BPM / 2
    }
    private void Update()
    { 
        text.text = audioTime.ToString("F4");
        MoveTime();
        //テスト用テキスト
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    switch (NotesController.judge)
        //    {
        //        case true:
        //            text.text = "OK";
        //            break;
        //        case false:
        //            text.text = "NG";
        //            break;
        //    }
        //}
    }
    private void MoveTime()
    {
        judgeTime += Time.deltaTime;
        audioTime += Time.deltaTime;
        if (judgeTime >= timeOut)
        {
            poolL.GetGameObjL();
            poolR.GetGameObjR();
            judgeTime = audioTime % timeOut;
        }
    }
}

