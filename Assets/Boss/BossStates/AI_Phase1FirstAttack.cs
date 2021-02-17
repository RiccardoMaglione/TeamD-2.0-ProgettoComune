using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Phase1FirstAttack : StateMachineBehaviour
{
    WaypointsAttack1 waypointsAttack1;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("FinishAttack", false);
        waypointsAttack1 = animator.GetComponent<WaypointsAttack1>();     
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waypointsAttack1.Attack1();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
