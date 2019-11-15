using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesController : MonoBehaviour
{
    private enum ThisNote
    {
        RtoLNote,
        LtoRNote,
    }

    [SerializeField]
    private ThisNote thisNote;

    private Vector3 pos;

    private void Start()
    {
        pos = this.transform.position;
    }
    void Update()
    {
        NoteMove();
    }
    private void NoteMove()
    {
        switch (thisNote)
        {
            //右から流れるノーツの処理
            //左に向かってノーツを流す一定値(1)超えたら初期値に戻す
            case ThisNote.RtoLNote:
                this.transform.position -= transform.right * 10 * Time.deltaTime;
                if (this.gameObject.transform.position.x <= -1)
                {
                    this.transform.position = pos;
                    this.gameObject.SetActive(false);
                }
                break;
            //左から流れるノーツの処理
            case ThisNote.LtoRNote:
                //右に向かってノーツを流す一定値(1)超えたら初期値に戻す
                this.transform.position += transform.right * 10 * Time.deltaTime;
                if (this.gameObject.transform.position.x >= 1)
                {
                    this.transform.position = pos;
                    this.gameObject.SetActive(false);
                }
                break;
        }
    }
}