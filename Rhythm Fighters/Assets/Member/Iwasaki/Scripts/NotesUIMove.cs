using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesUIMove : MonoBehaviour
{
    private enum ThisUI
    {
        RtoLNoteUI,
        LtoRNoteUI
    }
    [SerializeField]
    private ThisUI thisUI;
    private Vector2 posR, posL;
    private Rigidbody2D rb2d;
    private RectTransform rectTransform;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rectTransform = this.GetComponent<RectTransform>();
        posR = rectTransform.anchoredPosition;
        posL = rectTransform.anchoredPosition;
    }
    private void Update()
    {
        NoteUIMove();
    }
    void NoteUIMove()
    {
        switch (thisUI)
        {
            case ThisUI.RtoLNoteUI:
                Debug.Log("case内呼ばれてる");
                posR.x -= rectTransform.right.x * 10 * Time.deltaTime;
                if (posR.x <= 0)
                {
                    Debug.Log("if内呼ばれてる");
                    this.rectTransform.position = posR;
                    this.gameObject.SetActive(false);
                }
                break;
            case ThisUI.LtoRNoteUI:
                Debug.Log("case内呼ばれてる");
                posL.x += rectTransform.right.x * 10 * Time.deltaTime;
                if (posL.x >= 0)
                {
                    Debug.Log("if内呼ばれてる");
                    this.transform.position = posL;
                    this.gameObject.SetActive(false);
                }
                break;
        }
    }
}
