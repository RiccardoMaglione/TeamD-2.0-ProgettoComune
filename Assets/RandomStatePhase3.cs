using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStatePhase3 : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int rand = Random.Range(1, 4);

        if (rand == 1)
            animator.SetTrigger("Attack1");

        if (rand == 2)
            animator.SetTrigger("Attack2");

        if (rand == 3)
            animator.SetTrigger("Attack3");

        animator.ResetTrigger("GoToIdle");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack1");
        animator.ResetTrigger("Attack2");
        animator.ResetTrigger("Attack3");

        Boss.canDamage = true;
    }
}
