﻿using SwordGame;
using UnityEngine;

public class FindEnemy : StateMachineBehaviour
{
    FatKnightSpecialAttack specialAttack;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        specialAttack = animator.GetComponent<FatKnightSpecialAttack>();
        specialAttack.Findenemy();

        if (specialAttack.enemyList.Count != 0)
            animator.SetTrigger("Next");

        else
            animator.SetTrigger("Stop");
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
