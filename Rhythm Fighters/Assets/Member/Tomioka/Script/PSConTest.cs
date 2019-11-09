using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSConTest : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetAxis("Left") > 0.5f)
        {
            Debug.Log("右");
        }
        if (Input.GetAxis("Left") < -0.5f)
        {
            Debug.Log("左");
        }
        if (Input.GetButtonDown("Maru"))
        {
            Debug.Log("〇");
        }
        if (Input.GetButtonDown("Batu"))
        {
            Debug.Log("×");
        }
        if (Input.GetButtonDown("Sankaku"))
        {
            Debug.Log("△");
        }
        if (Input.GetButtonDown("Sikaku"))
        {
            Debug.Log("□");
        }
    }
}
