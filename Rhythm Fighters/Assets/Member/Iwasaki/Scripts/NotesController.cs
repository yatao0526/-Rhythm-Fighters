using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesController : MonoBehaviour
{
    void Update()
    {
        this.transform.position -= transform.right * 10 * Time.deltaTime;

        if (this.gameObject.transform.position.x <= -9.5f) Destroy(gameObject);
    }
}
