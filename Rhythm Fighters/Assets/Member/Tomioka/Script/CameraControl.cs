using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;

    //Player同士の間の座標
    [SerializeField]
    private Vector2 center;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        between1Pand2P();
    }

    private void between1Pand2P()
    {
        center = (player1.transform.position + player2.transform.position) * 0.5f;
        this.transform.position = center;
    }


   
}

