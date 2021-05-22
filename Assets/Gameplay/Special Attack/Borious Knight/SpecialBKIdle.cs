using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class SpecialBKIdle : StateMachineBehaviour
{
    PSMController psmController;
    public static bool BoriousMove = true;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        psmController = animator.GetComponentInParent<PSMController>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.C) && psmController.CurrentEnergy > psmController.MaxEnergy)
        {
            psmController.CurrentEnergy = 0;
            animator.SetBool("IsAttack", true);
            BoriousMove = false;
        }     
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
}
