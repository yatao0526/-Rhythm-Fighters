using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //判定
    [SerializeField]
<<<<<<< HEAD
    private GameObject[] judge;
    //Notes(Prefab)入れてる
    [SerializeField]
    private GameObject[] Notes;
    //objectpool参照
    private NoteObjectPool pool;
=======
    private GameObject noteObj;
    //生成するノーツの初期値(右から生成)
    [SerializeField]
    private Vector2 notePop;
    //notejenerate呼ぶため
    [SerializeField]
    private NotesJenerate nj;
>>>>>>> 8d7642ebf169f55118414d7bec7b00cd66862e3b

    public static int notesSpeed;
    public int BPM;

    private float judgeTime;
    
    void Start()
    {
<<<<<<< HEAD
        notesSpeed = BPM / 2;
        pool = GetComponent<NoteObjectPool>();
        pool.CreatePool(Notes[0], 10);
        pool.CreatePool(Notes[1], 10);
=======
        BPM = BPMNum;
        notesSpeed = BPMNum / 20;
    }

    void Update()
    {
        //instatiate呼び出し
        nj.NoteJene(noteObj, notePop);
>>>>>>> 8d7642ebf169f55118414d7bec7b00cd66862e3b
    }
}

