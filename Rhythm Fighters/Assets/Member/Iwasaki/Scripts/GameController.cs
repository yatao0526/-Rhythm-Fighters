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

    private void Awake()
    {
        poolL = GetComponent<NoteObjectPool>();
        poolR = GetComponent<NoteObjectPool>();
        poolL.CreatePoolL(Notes[0], 10);
        poolR.CreatePoolR(Notes[1], 10);
    }
    private void Update()
    {
        MoveTime();
        //テスト用テキスト
        if (Input.GetKeyDown(KeyCode.Space))
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
    }
    private void MoveTime()
    {
        judgeTime += Time.deltaTime;
        if (judgeTime >= timeOut)
        {
            poolL.GetGameObjL();
            poolR.GetGameObjR();
            judgeTime = 0.0f;
        }
    }
}

