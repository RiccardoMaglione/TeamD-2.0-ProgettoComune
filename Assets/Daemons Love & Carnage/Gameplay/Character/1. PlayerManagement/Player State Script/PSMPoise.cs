using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class PSMPoise : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.GetComponent<PSMController>().RB2D.velocity = Vector2.zero;
        animator.SetBool("PSM-IsStagger", false);
        animator.SetBool("PSM-CanAttack", false);

        animator.GetComponent<PSMController>().LightAttackCollider.SetActive(false);
        animator.GetComponent<PSMController>().HeavyAttackCollider.SetActive(false);
        animator.SetBool("PSM-LightAttack", false);
        animator.SetBool("PSM-HeavyAttack", false);
        animator.SetBool("PSM-SpecialAttack", false);
        animator.GetComponent<PSMController>().IsLightAttack = false;
        animator.GetComponent<PSMController>().IsHeavyAttack = false;
        animator.GetComponent<PSMController>().IsSpecialAttack = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PSMController>().PoisePlayer = 0;
        animator.SetBool("PSM-CanAttack", true);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
