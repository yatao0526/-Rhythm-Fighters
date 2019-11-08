using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesJenerate : MonoBehaviour
{
    //ノーツをまとめる箱(親)
    [SerializeField]
    private GameObject notesBox;
    //何小節か
    [SerializeField]
    private float measure;
    //ノーツの流れるスピード
    private float beatSpeed;
    private float timeElapsed;
    
    private void Start()
    {
        //beatSpeed = 60 * measure / GameController.BPM;
    }

    public void NoteJene(GameObject Lobj, Vector2 Lvec2)
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= beatSpeed)
        {
            Instantiate(Lobj, Lvec2, Quaternion.identity).transform.SetParent(notesBox.transform);
            Debug.Log(beatSpeed);
            timeElapsed = 0.0f;
        }
    }
}
