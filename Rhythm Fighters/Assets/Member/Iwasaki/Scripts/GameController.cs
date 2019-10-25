using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject checkBox;

    public static int notesSpeed;
    public static int BPM;
    public int BPMNum;

    void Start()
    {
        BPM = BPMNum;
        notesSpeed = BPMNum / 20;
    }

    void Update()
    {
        
    }
}
