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
    private Vector3 vec3;
    private Rigidbody2D rb2d;
    private RectTransform rectTransform;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rectTransform = this.GetComponent<RectTransform>();
    }
    private void Update()
    {
        NoteUIMove();
    }
    void NoteUIMove()
    {
        switch(thisUI)
        {
            case ThisUI.RtoLNoteUI:
                Vector2 posR = rectTransform.anchoredPosition;
                posR.x -= transform.right.x * 10 * Time.deltaTime;
                if (posR.x >= 0)
                {
                    this.transform.position = posR;
                    this.gameObject.SetActive(false);
                }
                break;
            case ThisUI.LtoRNoteUI:
                Vector2 posL = rectTransform.anchoredPosition;
                posL.x += transform.right.x * 10 * Time.deltaTime;
                this.transform.position += transform.right * 10 * Time.deltaTime;
                if (posL.x <= 0)
                {
                    this.transform.position = posL;
                    this.gameObject.SetActive(false);
                }
                break;
        }
    }
}
