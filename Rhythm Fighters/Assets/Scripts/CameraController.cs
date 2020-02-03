using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerOne;
    [SerializeField]
    private GameObject PlayerTwo;

    private float AttenRate = 3f; // 減衰比率

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(PlayerOne.transform.position.x) < 6 && Mathf.Abs(PlayerTwo.transform.position.x) < 6)
        {
            Camera.main.fieldOfView = 10;
        }
        else if (Mathf.Abs(PlayerOne.transform.position.x) >= Mathf.Abs(PlayerTwo.transform.position.x))
        {
            // Lerp減衰
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, ((Mathf.Abs(PlayerOne.transform.position.x) - 6) / 6 * 8) + 10, Time.deltaTime * AttenRate);
        }
        else
        {
            // Lerp減衰
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, ((Mathf.Abs(PlayerOne.transform.position.x) - 6) / 6 * 8) + 10, Time.deltaTime * AttenRate);
        }
    }
}
