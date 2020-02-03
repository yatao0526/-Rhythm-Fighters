//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerInfoManager : MonoBehaviour
//{
//    public static GameObject thisGamePlayer1;
//    public static GameObject thisGamePlayer2;

//    private void Awake()
//    {
//        CreatePrefab();
//    }

//    void Start()
//    {

//    }

//    private void CreatePrefab()
//    {
//        switch (CharacterSelectPlayersController.player1PCharacterName)
//        {
//            case "Character1":
//                thisGamePlayer1 = (GameObject)Resources.Load("Suzuki1P");
//                Instantiate(thisGamePlayer1, new Vector3(-2.0f, -1.0f, 70.0f), Quaternion.identity);
//                break;

//            case "Character2":
//                thisGamePlayer1 = (GameObject)Resources.Load("Yokoyama1P");
//                Instantiate(thisGamePlayer1, new Vector3(-2.0f, -1.0f, 70.0f), Quaternion.identity);
//                break;

//            case "Character3":

//                break;

//            case "Character4":

//                break;
//        }

//        switch (CharacterSelectPlayersController.player2PCharacterName)
//        {
//            case "Character1":
//                thisGamePlayer2 = (GameObject)Resources.Load("Suzuki2P");
//                Instantiate(thisGamePlayer2, new Vector3(2.0f, -1.0f, 70.0f), Quaternion.identity);
//                break;

//            case "Character2":
//                thisGamePlayer2 = (GameObject)Resources.Load("Yokoyama2P");
//                Instantiate(thisGamePlayer2, new Vector3(2.0f, -1.0f, 70.0f), Quaternion.identity);
//                break;

//            case "Character3":

//                break;

//            case "Character4":

//                break;
//        }
//    }

//}
