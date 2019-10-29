using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesJenerate : MonoBehaviour
{
    //ノーツ・ノーツをまとめる箱(親)
    [SerializeField]
    private GameObject note, notesBox;
    //何小節か
    [SerializeField]
    private int measure;
    //ノーツの流れるスピード
    private float beatSpeed;
    private float timeElapsed;
    
    

    //生成するノーツの初期値
    private Vector2 notePop = new Vector2(9, -4);
    
    private void Start()
    {
        beatSpeed = 60 * measure / GameController.BPM;
    }
    
    private void Update()
    {
        NoteJene();
    }
    public void NoteJene()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= beatSpeed)
        {
            NoteInstant(notePop);
            Debug.Log(beatSpeed);
            timeElapsed = 0.0f;
        }
    }
    private void NoteInstant(Vector2 vec2)
    {
        Instantiate(note, vec2, Quaternion.identity).transform.SetParent(notesBox.transform);
    }
}
