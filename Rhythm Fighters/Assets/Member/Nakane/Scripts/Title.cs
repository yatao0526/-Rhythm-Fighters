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

    public void OnClick()
    {
        // 対戦モードボタンをクリックでCharacterSelectへ遷移
        //SceneManager.LoadScene("CharacterSelect");

        // ロード画面UIをアクティブに
        loadingUI.SetActive(true);

        // コルーチン開始
        StartCoroutine("LoadingScreen");
    }

    IEnumerator LoadingScreen()
    {
        
        yield return new WaitForSeconds(0.5f);

        // シーンの読み込み
        async = SceneManager.LoadSceneAsync("CharacterSelect");

        // 読み込みが終わるまで進捗状況をスライダーの値に反映させる
        while (!async.isDone)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progressVal;
            yield return null;
        }

    }

    void Start()
    {
        // 一定時間後MoveMovieScene関数実行
        Invoke("MoveMovie", 7.0f);
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

    public void MoveMovie()
    {
        // Movieへ遷移
        SceneManager.LoadScene("Movie");
    }
}
