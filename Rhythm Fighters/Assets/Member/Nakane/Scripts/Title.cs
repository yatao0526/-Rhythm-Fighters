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

    private AudioClip[] titleCollSE;

    private float BGMLength;

    private bool startBGM;

    void Start()
    {
        startBGM = false;
        // 一定時間後MoveMovie関数実行
        //Invoke("MoveMovie", 7.0f);
        Invoke("TitleCall", 3f);
    }

    void Update()
    {
        InputGet();
        MoveMovie();
    }
    private void InputGet()
    {
        if (Input.GetButtonDown("Maru") || Input.GetButtonDown("2PMaru"))
        {
            SoundManager.Instance.PlaySe(SE.titleSE);
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
        yield return new WaitForSeconds(1.5f);

        // シーンの読み込み
        //async = SceneManager.LoadSceneAsync("CharacterSelectPlayersController");
        //async = SceneManager.LoadSceneAsync("MainTest");
        async = SceneManager.LoadSceneAsync("CharacterSelectPlayersController");

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
        if (startBGM)
        {
            BGMLength -= Time.deltaTime;
        }
        if (BGMLength < 0)
        {
            startBGM = false;
            // Movieシーンへ遷移
            SceneManager.LoadScene("Movie");
        }
    }

    private void TitleCall()
    {
        int x = Random.Range(0, 3);
        //int x = 2;
        float y;
        //Debug.Log(x);
        switch (x)
        {
            //2秒
            case 0:
                SoundManager.Instance.PlaySe(SE.titleCollN);
                y = 3;
                Invoke("TitleBGM", y);
                break;

            //2秒
            case 1:
                SoundManager.Instance.PlaySe(SE.titleCollT);
                y = 3;
                Invoke("TitleBGM", y);
                break;

            //4秒
            case 2:
                SoundManager.Instance.PlaySe(SE.titleCollY);
                y = 5;
                Invoke("TitleBGM", y);
                break;
        }
    }

    private void TitleBGM()
    {
        startBGM = true;
        SoundManager.Instance.PlaySe(SE.titleBGM);
        BGMLength = SoundManager.Instance.seSound[0].clip.length + 1;
    }

}
