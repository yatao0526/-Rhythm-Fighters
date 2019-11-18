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

    private Rigidbody2D rb2d;

    public static bool judge = false;

    private void Start()
    {
        pos = this.transform.position;
        rb2d = GetComponent<Rigidbody2D>();
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
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "CheckBox_R")
        {
            judge = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == "CheckBox_R")
        {
            judge = false;
        }
    }
}