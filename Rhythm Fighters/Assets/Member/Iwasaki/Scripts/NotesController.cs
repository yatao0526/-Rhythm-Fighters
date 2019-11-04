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

    void Update()
    {
        switch (thisNote)
        {
            case ThisNote.RtoLNote:
                this.transform.position -= transform.right * 10 * Time.deltaTime;
                if (this.gameObject.transform.position.x <= -1) Destroy(gameObject);
                break;
            case ThisNote.LtoRNote:
                this.transform.position += transform.right * 10 * Time.deltaTime;
                if (this.gameObject.transform.position.x >= 1) Destroy(gameObject);
                break;
        }
    }
}
