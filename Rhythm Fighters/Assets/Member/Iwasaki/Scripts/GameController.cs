using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //note入れてる
    [SerializeField]
    private GameObject noteObj;
    //生成するノーツの初期値(右から生成)
    [SerializeField]
    private Vector2 notePop;
    //notejenerate呼ぶため
    [SerializeField]
    private NotesJenerate nj;

    public static int notesSpeed;
    public static float BPM;
    public int BPMNum;
    
    void Start()
    {
        BPM = BPMNum;
        notesSpeed = BPMNum / 20;
    }

    void Update()
    {
        //instatiate呼び出し
        nj.NoteJene(noteObj, notePop);
    }
}

