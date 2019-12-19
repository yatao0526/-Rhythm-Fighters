using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegationManager : MonoBehaviour
{
    private int Negation1P = 0;
    private int Negation2P = 0;



    private void Update()
    {
        Negation1P = Player1.player1ActionNumber;
        Negation2P = Player2.player2ActionNumber;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Player1" && col.tag != "Player2")
        {
            GameController.modeType = GameController.ModeType.negationMode;
            Debug.Log("うちけいそ");
        }
    }
}
