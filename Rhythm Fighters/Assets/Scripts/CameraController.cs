using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerOne;
    [SerializeField]
    private GameObject PlayerTwo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(PlayerOne.transform.position.x) <= 6 && Mathf.Abs(PlayerTwo.transform.position.x) <= 6)
        {
            Camera.main.fieldOfView = 10;
        }else if(Mathf.Abs(PlayerOne.transform.position.x)>=12|| Mathf.Abs(PlayerTwo.transform.position.x) >= 12)
        {
            Camera.main.fieldOfView = 18;
        }
        else if (Mathf.Abs(PlayerOne.transform.position.x) >= Mathf.Abs(PlayerTwo.transform.position.x))
        {
            Camera.main.fieldOfView = 10 + ((Mathf.Abs(PlayerOne.transform.position.x) - 6) / 6 * 8);
        }
        else
        {
            Camera.main.fieldOfView = 10 + ((Mathf.Abs(PlayerTwo.transform.position.x) - 6) / 6 * 8);
        }
    }
}
