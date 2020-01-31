using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//どちら側からノーツが流れるか分けるよう
public enum ThisNote
{
    RtoLNote,
    LtoRNote,
}

public class NotesController : MonoBehaviour
{
    [SerializeField]
    private ThisNote thisNote;
    //transformをループさせるために位置データ保管
    private Vector3 pos;
    //あたり判定等
    private Rigidbody2D rb2d;
    //通常モード用判定bool
    public static bool judge = false;
    //行動用bool
    public static bool getActive = false;
    //打消しで使うフラグ
    public static bool negation1PFlag = false;
    public static bool negation2PFlag = false;
    //ボタン押す目あす
    public static bool pushBottun = false;

    public ThisNote _ThisNote { get => thisNote; set => thisNote = value; }
    
    private void Start()
    {
        pos = this.transform.position;
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        NoteMove();
    }
    //
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
        if (col.gameObject.name == "CheckBox_M")
        {
            getActive = true;
        }
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
            }
        }
        else
        {
            if(NegationMode.countNum >= 2)
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
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "CheckBox_M")
        {
            getActive = false;
        }
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
            }
        }
        else
        {
            if(NegationMode.countNum >= 2)
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
}