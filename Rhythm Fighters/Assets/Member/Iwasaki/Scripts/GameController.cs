using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //判定
    [SerializeField]
    private GameObject[] judge;
    //Notes(Prefab)入れてる
    [SerializeField]
    private GameObject[] Notes;
    //
    [SerializeField]
    private float timeOut;
    //objectpool参照
    private NoteObjectPool poolL, poolR;

    public static int BPMNum;
    public static int notesSpeed;
    public int BPM;
    
    //判定用タイム
    private float judgeTime;

    private void Awake()
    {
        poolL = GetComponent<NoteObjectPool>();
        poolR = GetComponent<NoteObjectPool>();
        poolL.CreatePool(Notes[0], 10);
        poolR.CreatePool(Notes[1], 10);
    }
    private void Start()
    {

    }

    private void Update()
    {
        //Debug.Log(judgeTime);
        judgeTime += Time.deltaTime;
        if(judgeTime >= timeOut)
        {
            poolL.GetGameObjL();
            poolR.GetGameObjR();
            judgeTime = 0.0f;
        }
        Debug.Log(NotesController.judge);
    }
}

