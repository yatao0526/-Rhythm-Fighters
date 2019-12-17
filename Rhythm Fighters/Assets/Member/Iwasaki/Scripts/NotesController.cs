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
    //行動用bool
    public static bool getActive = false;
    //打消しで使うフラグ
    public static bool negation1PFlag = false;
    public static bool negation2PFlag = false;
    //ボタン押す目あす
    public static bool pushBottun = false;

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
        if (GameController.modeType == GameController.ModeType.normalMode)
        {
            switch(col.gameObject.name)
            {
                case "CheckBox_R":
                    judge = true;
                    break;
                case "CheckBox_L":
                    judge = true;
                    break;
                case "CheckBox_M":
                    getActive = true;
                    break;
            }
        }
        else
        {
            if (col.gameObject.name == "RevocationGaugeR")
            {
                negation2PFlag = true;
            }
            if (col.gameObject.name == "RevocationGaugeL")
            {
                negation1PFlag = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (GameController.modeType == GameController.ModeType.normalMode)
        {
            switch (other.gameObject.name)
            {
                case "CheckBox_R":
                    judge = false;
                    break;
                case "CheckBox_L":
                    judge = false;
                    break;
                case "CheckBox_M":
                    getActive = false;
                    break;
            }
        }
        else
        {
            if (other.gameObject.name == "RevocationGaugeR")
            {
                negation2PFlag = false;
            }
            if (other.gameObject.name == "RevocationGaugeL")
            {
                negation1PFlag = false;
            }
        }
    }
}