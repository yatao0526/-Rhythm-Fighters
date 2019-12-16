using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScript : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        animator.SetTrigger("HP_Fx_Down");
    }

    public void S2Fx()
    {
        animator.SetTrigger("S2_Fx");
    }

    public void PoseFx()
    {
        animator.SetTrigger("Pose_Fx");
    }
}
