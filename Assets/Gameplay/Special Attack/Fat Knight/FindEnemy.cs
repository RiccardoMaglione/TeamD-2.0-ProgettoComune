﻿using UnityEngine;
using SwordGame;

public class FindEnemy : StateMachineBehaviour
{
    FatKnightSpecialAttack specialAttack;
    PSMController psmController;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        specialAttack = animator.GetComponent<FatKnightSpecialAttack>();
        specialAttack.Findenemy();
        psmController = animator.GetComponentInParent<PSMController>();
        psmController.CurrentEnergy = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
}
