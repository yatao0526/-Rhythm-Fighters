using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // 非同期動作で使用するAsyncOperation
    private AsyncOperation async;
    // シーンロード中に表示するUI画面
    [SerializeField]
    private GameObject loadingUI;
    // 読み込み率を表示するスライダー
    [SerializeField]
    private Slider slider;
    // 背景
    [SerializeField]
    private GameObject backGround;

    void Start()
    {
        // 一定時間後MoveMovie関数実行
        //Invoke("MoveMovie", 7.0f);
    }

    void Update()
    {
        InputGet();
    }
    private void InputGet()
    {
        if (Input.anyKey)
        {
            // ロード画面UI表示
            loadingUI.SetActive(true);
            // 背景非表示
            backGround.SetActive(false);
            // コルーチン開始
            StartCoroutine("LoadingScreen");
            // Invokeを呼び出さないようにする
            CancelInvoke();
            // 一定時間後、再びInvokeを呼び出す
            //Invoke("MoveMovie", 10.0f);
        }
    }

    IEnumerator LoadingScreen()
    {
        yield return new WaitForSeconds(0.5f);

        // シーンの読み込み
        //async = SceneManager.LoadSceneAsync("CharacterSelectPlayersController");
        async = SceneManager.LoadSceneAsync("MainTest");

        // 読み込みが終わるまで進捗状況をスライダーの値に反映させる
        while (!async.isDone)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progressVal;
            yield return null;
        }
    }

    private void MoveMovie()
    {
        // Movieシーンへ遷移
        SceneManager.LoadScene("Movie");
    }
}
