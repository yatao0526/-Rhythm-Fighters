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

    void Start()
    {
        BPM = BPMNum;
        _notesSpeed = BPMNum / 20;
    }

    void Update()
    {
        
    }
}
