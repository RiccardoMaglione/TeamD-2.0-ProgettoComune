using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaAttackState : StateMachineBehaviour
{
    ParabolaController parabolaController;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        parabolaController = animator.GetComponent<ParabolaController>();
        parabolaController.enabled = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(parabolaController.Animation == false)
        {
            parabolaController.enabled = false;
            animator.SetTrigger("GoToIdle");
        }          
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
