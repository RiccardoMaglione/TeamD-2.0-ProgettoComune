using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class SpecialThiefAttack : StateMachineBehaviour
{
    ThiefSpecialAttack thiefSpecialAttack;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thiefSpecialAttack = animator.GetComponent<ThiefSpecialAttack>();
        thiefSpecialAttack.StartCoroutine(thiefSpecialAttack.Attack());
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
