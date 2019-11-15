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

    public static int BPMNum;
    public static int notesSpeed;
    public int BPM;
    //判定用タイム
    private float judgeTime;
    private void Awake()
    {
        pool = GetComponent<NoteObjectPool>();
        pool.CreatePool(Notes[0], 1);
        pool.CreatePool(Notes[1], 1);
    }
    private void Start()
    {
        notesSpeed = BPM / 2;

        BPM = BPMNum;
        notesSpeed = BPMNum / 20;
    }

    private void Update()
    {
        pool.GetGameObj();
    }
    //判定
    //押したときの成功・失敗   押さなかったときの無反応

}

