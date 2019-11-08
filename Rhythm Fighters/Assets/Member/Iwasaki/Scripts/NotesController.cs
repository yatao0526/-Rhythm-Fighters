using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesController : MonoBehaviour
{
    //ノーツの移動処理
    void Update()
    {
        this.transform.position -= transform.right * 10 * Time.deltaTime;
        if (this.gameObject.transform.position.x <= -1) Destroy(gameObject);
    }
}
