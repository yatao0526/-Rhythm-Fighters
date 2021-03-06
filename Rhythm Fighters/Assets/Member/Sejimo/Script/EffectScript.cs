﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScript : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("Speed", 1.7f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MissFX()
    {
        animator.SetTrigger("Miss_Fx");
    }

    public void HpFx()
    {
        animator.SetTrigger("HP_Fx_Up");
    }

    public void S1Fx()
    {
        animator.SetTrigger("S1_Fx");
        Debug.Log("S1_FX");
    }

    public void S2Fx()
    {
        animator.SetTrigger("S2_Fx");
        Debug.Log("aaa");
    }

    public void LpFx()
    {
        animator.SetTrigger("LP_Fx");
        Debug.Log("LP_Fx");
    }

    public void PoseFx()
    {
        animator.SetTrigger("Pose_Fx");
    }
}
