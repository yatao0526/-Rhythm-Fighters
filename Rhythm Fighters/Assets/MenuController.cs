using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //選択肢を選ぶカーソル
    [SerializeField]
    private GameObject cursor;
    //メニューのパネル
    [SerializeField]
    private GameObject menuWindow;

    [Header("配列の数とメニューの総数は同じにする")]
    [SerializeField]
    private GameObject[] indexNum;
    [SerializeField]
    private Vector3[] tmp;

    //メニューのオンオフ
    private bool menuActive;

    private int menuNum;

    private void Awake()
    {
        tmp = new Vector3[indexNum.Length];

        Debug.Log("呼ばれた");
        for (int i = 0; i < indexNum.Length; i++)
        {

            tmp[i] = indexNum[i].transform.position;
            Debug.Log(tmp[i]);
        }
    }

    void Start()
    {
        menuActive = false;
        menuWindow.SetActive(menuActive);
    }

    void Update()
    {
        MenuWindowOnOff();
        MenuIndex();
    }

    private void MenuWindowOnOff()
    {
        if (Input.GetButtonDown("Option") || Input.GetButtonDown("2POption"))
        {
            menuActive = !menuActive;
            menuWindow.SetActive(menuActive);
        }
    }

    private void MenuIndex()
    {
        if (menuActive == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                menuNum++;
                Debug.Log(menuNum);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                menuNum--;
                Debug.Log(menuNum);
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                switch (menuNum)
                {
                    case 0:
                        menuActive = false;
                        break;
                    case 1:
                        SceneManager.LoadScene("Titele");
                        break;
                    case 2:
                        SceneManager.LoadScene("");
                        break;
                }
            }

            switch (menuNum)
            {
                case 0:
                    cursor.transform.position = tmp[0];
                    break;
                case 1:
                    cursor.transform.position = tmp[1];
                    break;
                case 2:
                    cursor.transform.position = tmp[1];
                    break;
            }
        }
    }
}
