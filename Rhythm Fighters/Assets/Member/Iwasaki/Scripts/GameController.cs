using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject _checkBox;

    public static int _notesSpeed;
    public static int BPM;
    public int BPMNum;

    //生成するノーツの初期値
    private Vector2 _notePop = new Vector2(9, -4);
    
    void Start()
    {
        BPM = BPMNum;
        _notesSpeed = BPMNum / 20;
    }

    void Update()
    {
        
    }
}
