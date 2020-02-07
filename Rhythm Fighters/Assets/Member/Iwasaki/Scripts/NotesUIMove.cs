using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesUIMove : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    RectTransform target;
    [SerializeField]
    private ThisNote thisNote;
    [SerializeField]
    private int noteStartPos;
    [SerializeField]
    private int UIStartPos;
    private void Start()
    {
        NoteUICanvasSerevtor serector = (NoteUICanvasSerevtor)FindObjectOfType(typeof(NoteUICanvasSerevtor));
        canvas = serector.canvas;
        ImageCreatePooling imagePool = (ImageCreatePooling)FindObjectOfType(typeof(ImageCreatePooling));
        NotesController notesController = this.GetComponent<NotesController>();
        if (notesController._ThisNote == ThisNote.LtoRNote)
        {
            target = imagePool.GetGameImageL().rectTransform;
        }
        if(notesController._ThisNote == ThisNote.RtoLNote)
        {
            target = imagePool.GetGameImageR().rectTransform;
        }
    }
    private void Update()
    {
        UIMove();
    }

    void UIMove()
    {
        switch(thisNote)
        {
            case ThisNote.LtoRNote:
                Vector2 vec2 = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, this.transform.position);

                //　オブジェクトの割合計算　(現在の位置ー始点）/ (目標点ー始点)
                Vector2 objLPos;
                objLPos.x = (((transform.position.x - -noteStartPos) / (1 - -noteStartPos)) + 0.25f) % 1;
                // UI上の位置(目標点ー始点)　* 割合 + 始点
                Vector2 UIPos;
                UIPos.x = (0 - -UIStartPos) * objLPos.x + -UIStartPos;

                Vector2 vector2 = target.anchoredPosition;
                vector2.x = UIPos.x;
                target.anchoredPosition = vector2;
                break;
            case ThisNote.RtoLNote:
                Vector2 vecR2 = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, this.transform.position);
                Vector2 objRPos;
                objRPos.x = (((transform.position.x - noteStartPos) / (-1 - noteStartPos)) +0.25f) % 1;
                Vector2 UIRPos;
                UIRPos.x = (0 - UIStartPos) * objRPos.x + UIStartPos;
                Vector2 vectorR2 = target.anchoredPosition;
                vectorR2.x = UIRPos.x;
                target.anchoredPosition = vectorR2;
                break;
        }
    }
}