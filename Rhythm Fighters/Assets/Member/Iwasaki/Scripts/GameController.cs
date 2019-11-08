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
    //objectpool参照
    private NoteObjectPool pool;

    public static int notesSpeed;
    public int BPM;

    private float judgeTime;
    
    void Start()
    {
        notesSpeed = BPM / 2;
        pool = GetComponent<NoteObjectPool>();
        pool.CreatePool(Notes[0], 10);
        pool.CreatePool(Notes[1], 10);
    }
}

