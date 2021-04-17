using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAttackState : StateMachineBehaviour
{
    Boss boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();

        int rand = Random.Range(1, 3);

        if (rand == 1)
            animator.SetTrigger("Attack1");
        else
            animator.SetTrigger("Attack2");
        
        animator.ResetTrigger("GoToIdle");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack1");
        animator.ResetTrigger("Attack2");
        
        boss.canDamage = true;
    }
}
