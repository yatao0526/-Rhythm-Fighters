using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    void Start()
    {
        // 一定時間後MoveMovieScene関数実行
        Invoke("MoveMovie", 5.0f);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // 左クリックでInvokeを呼び出さないようにする
            CancelInvoke();

            // 一定時間後、再びInvokeを呼び出す
            Invoke("MoveMovie", 10.0f);
        }
    }

    public void OnClick()
    {
        // 対戦モードボタンをクリックでCharacterSelectへ遷移
        SceneManager.LoadScene("CharacterSelect");
    }

    public void MoveMovie()
    {
        // Movieへ遷移
        SceneManager.LoadScene("Movie");
    }
}
