using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesJenerate : MonoBehaviour
{
    //ノーツ
    [SerializeField] private GameObject _note;
    //ノーツをまとめる箱(親)
    [SerializeField] private GameObject _notesBox;
    //生成するノーツの初期値
    private Vector2 _notePop = new Vector2(9, -4);

    [SerializeField] private float _beatSpeed;

    private void Start()
    {
        //debug
        //NoteJenerater(_notePop);
    }
    private float _timeElapsed;

    private void Update()
    {
        _timeElapsed += Time.deltaTime;
        if (_timeElapsed >= _beatSpeed)
        {
            NoteJenerater(_notePop);
            _timeElapsed = 0.0f;
        }
    }
    public void NoteJenerater(Vector2 vec2)
    {
        Instantiate(_note, vec2, Quaternion.identity).transform.SetParent(_notesBox.transform);
    }
}
