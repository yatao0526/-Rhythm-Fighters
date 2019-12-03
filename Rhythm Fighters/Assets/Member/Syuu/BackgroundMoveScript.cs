using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//-489.5498 310.4502
public class BackgroundMoveScript : MonoBehaviour
{
    [SerializeField] private int[] posX = new int[3] { 2880, 960,-960  };
    public float speedTime;//
    [SerializeField] private float  speed;
    public int myX = 1;
    private void Update()
    {
        CardPosXMove();
    }
    private void CardPosXMove()
    {
        speedTime -= Time.deltaTime;
        if (speedTime >= 0) {
            speed = (posX[myX] - transform.position.x) / speedTime;
        }
        if (transform.position.x != posX[myX] && speedTime>=0&& transform.position.x>posX[myX]  )//MyY最終地点
        {
            transform.position = new Vector3(transform.position.x +speed * Time.deltaTime, transform.position.y);//最終地点に動
                if (posX[myX] > transform.position.x)
                {
                    transform.position = new Vector3(posX[myX], transform.position.y);//最終地点に動
                }
        }else if (transform.position.x != posX[myX] && speedTime >= 0 && transform.position.x < posX[myX])//MyY最終地点
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y);//最終地点に動
            if (posX[myX] < transform.position.x)
            {
                transform.position = new Vector3(posX[myX], transform.position.y);//最終地点に動
            }
        }/*移動エラー防ぐ
        if (transform.position.x > posX[0]) {
            transform.position = new Vector3(posX[0], transform.position.y);//最終地点に動
        }
        else if(transform.position.x < posX[2]) {
            transform.position = new Vector3(posX[2], transform.position.y);//最終地点に動
        }*/
    }
}
