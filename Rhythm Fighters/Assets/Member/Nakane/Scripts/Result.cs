using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    // 1P側勝利のテキスト
    [SerializeField]
    private GameObject player1Win;

    // 2P側勝利のテキスト
    [SerializeField]
    private GameObject player2Win;

    [SerializeField]
    private float player1HP = 1000;

    [SerializeField]
    private float player2HP = 1000;

    void Start()
    {
        player1Win.SetActive(false);
        player2Win.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            player1HP -= 100;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            player2HP -= 100;
        }

        if(player1HP <= 0)
        {
            player1Win.SetActive(true);

            if (Input.GetMouseButton(0))
            {
                Invoke("MoveTitle", 1.0f);
            }
            
        }

        if(player2HP <= 0)
        {
            player2Win.SetActive(true);

            if (Input.GetMouseButton(0))
            {
                Invoke("MoveTitle", 1.0f);
            }

        }
    }

    public void MoveTitle()
    {
        SceneManager.LoadScene("Title");
    }

}
