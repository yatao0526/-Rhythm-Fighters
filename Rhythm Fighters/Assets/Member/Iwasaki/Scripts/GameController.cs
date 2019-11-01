using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //noteと判定箱入れてる
    [SerializeField]
    private GameObject[] noteObj;
    //上の配列に入ってるオブジェのスクリプト関係いじるよう
    [SerializeField]
    private LRController[] lrCon;
    //生成するノーツの初期値(右から生成)
    [SerializeField]
    private Vector2[] notePop;

    [SerializeField]
    private NotesJenerate nj;
    [SerializeField]
    private AudioSource audioSource;

    public static int notesSpeed;
    public static float BPM;
    public int BPMNum;
    
    void Start()
    {
        BPM = BPMNum;
        notesSpeed = BPMNum / 20;

        for(int i = 0; i < noteObj.Length; i++)
        {
            lrCon[i] = noteObj[i].GetComponent<LRController>();
        }
    }

    void Update()
    {
        nj.NoteJene(noteObj[2], notePop[0]);
        nj.NoteJene(noteObj[3], notePop[1]);
    }

}
