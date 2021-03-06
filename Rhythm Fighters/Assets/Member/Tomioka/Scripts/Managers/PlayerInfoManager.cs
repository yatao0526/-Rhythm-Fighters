﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoManager : MonoBehaviour
{
    public static GameObject thisGamePlayer1;
    public static GameObject thisGamePlayer2;

    private void Awake()
    {
        thisGamePlayer1 = null;
        thisGamePlayer2 = null;
        CreatePrefab();
    }

    void Start()
    {

    }

    private void CreatePrefab()
    {
        switch (CharacterSelectPlayersController.player1PCharacterName)
        {
            case "Character1":
                thisGamePlayer1 = (GameObject)Resources.Load("Suzuki1P");
                Instantiate(thisGamePlayer1, new Vector3(-2.0f, -1.0f, 70.0f), Quaternion.identity);
                thisGamePlayer1 = GameObject.Find("Suzuki1P(Clone)");
                break;

            case "Character2":
                thisGamePlayer1 = (GameObject)Resources.Load("Yokoyama1P");
                Instantiate(thisGamePlayer1, new Vector3(-2.0f, -1.0f, 70.0f), Quaternion.identity);
                thisGamePlayer1 = GameObject.Find("Yokoyama1P(Clone)");
                break;

            case "Character3":
                thisGamePlayer1 = (GameObject)Resources.Load("Niduma1P");
                Instantiate(thisGamePlayer1, new Vector3(-2.0f, -1.2f, 70.0f), Quaternion.identity);
                thisGamePlayer1 = GameObject.Find("Niduma1P(Clone)");
                break;

            case "Character4":
                thisGamePlayer1 = (GameObject)Resources.Load("LUO1P");
                Instantiate(thisGamePlayer1, new Vector3(-2.0f, -1.0f, 70.0f), Quaternion.identity);
                thisGamePlayer1 = GameObject.Find("LUO1P(Clone)");
                break;
        }

        switch (CharacterSelectPlayersController.player2PCharacterName)
        {
            case "Character1":
                thisGamePlayer2 = (GameObject)Resources.Load("Suzuki2P");
                Instantiate(thisGamePlayer2, new Vector3(2.0f, -1.0f, 70.0f), Quaternion.identity);
                thisGamePlayer2 = GameObject.Find("Suzuki2P(Clone)");
                break;

            case "Character2":
                thisGamePlayer2 = (GameObject)Resources.Load("Yokoyama2P");
                Instantiate(thisGamePlayer2, new Vector3(2.0f, -1.0f, 70.0f), Quaternion.identity);
                thisGamePlayer2 = GameObject.Find("Yokoyama2P(Clone)");
                break;

            case "Character3":
                thisGamePlayer2 = (GameObject)Resources.Load("Niduma2P");
                Instantiate(thisGamePlayer2, new Vector3(2.0f, -1.2f, 70.0f), Quaternion.identity);
                thisGamePlayer2 = GameObject.Find("Niduma2P(Clone)");
                break;

            case "Character4":
                thisGamePlayer2 = (GameObject)Resources.Load("LUO2P");
                Instantiate(thisGamePlayer2, new Vector3(2.0f, -1.0f, 70.0f), Quaternion.identity);
                thisGamePlayer2 = GameObject.Find("LUO2P(Clone)");
                break;
        }
    }

}
