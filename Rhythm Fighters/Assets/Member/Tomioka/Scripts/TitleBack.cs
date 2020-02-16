using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBack : MonoBehaviour
{
    private float time = 0;

    void Update()
    {
        Debug.Log(time);
        
        if (Input.GetButton("1PShare") || Input.GetButton("2PShare"))
        {
            time += Time.deltaTime;
        }
        if (Input.GetButtonUp("1PShare") || Input.GetButtonUp("2PShare"))
        {
            time = 0;
        }
        if (time > 3 && SceneManager.GetActiveScene().name != "Title")
        {
            SceneManager.LoadScene("Title");
        }
        if (time > 5 && SceneManager.GetActiveScene().name == "Title")
        {
            Application.Quit();
        }

    }
}
