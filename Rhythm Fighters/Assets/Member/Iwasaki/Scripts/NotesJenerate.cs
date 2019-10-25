using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesJenerate : MonoBehaviour
{
    #region シリアライズ化
    //ノーツ・ノーツをまとめる箱(親)
    [SerializeField]
    private GameObject note, notesBox;
    [SerializeField]
    private float beatSpeed;
    #endregion


    //生成するノーツの初期値
    private Vector2 notePop = new Vector2(9, -4);
    
    private float timeElapsed;

    private void Start()
    {
        //debug
        //NoteJenerater(_notePop);
    }
    
    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= beatSpeed)
        {
            NoteJenerater(notePop);
            timeElapsed = 0.0f;
        }
    }
    public void NoteJenerater(Vector2 vec2)
    {
        Instantiate(note, vec2, Quaternion.identity).transform.SetParent(notesBox.transform);
    }
}
