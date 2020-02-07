using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_speed : MonoBehaviour
{
    private Animator animator;
    //[Range(0f, 5f)]
    //public float SpeedValue = 1f;
    public bool animspeed = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //animator.speed = SpeedValue;
    }

    public void ChangeSpeed()
    {
        if(animspeed == true)
        {
            animator.SetFloat("Speed", 1.0f);
        }
        else
        {
            animator.SetFloat("Speed", 6.0f);
        }
    }

    private void Changespeed()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animspeed = false;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
