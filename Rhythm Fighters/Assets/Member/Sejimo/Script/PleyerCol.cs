using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleyerCol : MonoBehaviour
{
    private Animator animator;
    private Vector3 moveAfter;
    private Vector3 moveBeforePos;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DenoPley()
    {
        moveBeforePos = moveAfter;
        if (NotesController.judge)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                animator.SetTrigger("Trigger_LP_Col");
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                animator.SetTrigger("Trigger_HP_Col");
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                animator.SetTrigger("Trigger_S2_Col");
            }

        }
    }

    public void LPCol()
    {
        animator.SetTrigger("Trigger_LP_Col");
    }

    public void HPCol()
    {
        animator.SetTrigger("Trigger_HP_Col");
    }
    public void S2Col()
    {
        animator.SetTrigger("Trigger_S2_Col");
    }
}

