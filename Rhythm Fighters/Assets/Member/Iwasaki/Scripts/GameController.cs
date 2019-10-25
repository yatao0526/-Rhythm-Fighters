using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject checkBox;
    [SerializeField]
    private AudioSource audioSource;

    public static int notesSpeed;
    public static int BPM;
    public int BPMNum;

    private float tes;
    void Start()
    {
        BPM = BPMNum;
        notesSpeed = BPMNum / 20;
        
        //tes = (60 * 4) / BPM * 
    }

    void Update()
    {
        
    }
}
