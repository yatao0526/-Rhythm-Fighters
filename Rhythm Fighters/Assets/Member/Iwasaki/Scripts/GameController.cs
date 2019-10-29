using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject checkBox;
    [SerializeField]
    private AudioSource audioSource;

    public GameObject judgeLine;

    public static int notesSpeed;
    public static float BPM;
    public int BPMNum;

    private float tes;


    void Start()
    {
        BPM = BPMNum;
        notesSpeed = BPMNum / 20;
    }

    void Update()
    {
        
    }
}
