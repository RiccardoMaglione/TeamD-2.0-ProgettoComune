using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPossession : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyData>().timerStun = 0;
        animator.GetComponent<EnemyData>().CountHit = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyData>().timerStun += Time.deltaTime;
        if (animator.GetComponent<EnemyData>().CountHit >= animator.GetComponent<EnemyData>().MaxCountHit)
        {
            animator.SetTrigger("IsDeath");
        }
        if (animator.GetComponent<EnemyData>().timerStun >= animator.GetComponent<EnemyData>().DurationStun)
        {
            animator.SetTrigger("IsDeath");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
