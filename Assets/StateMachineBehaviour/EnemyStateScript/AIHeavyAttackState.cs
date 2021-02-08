using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHeavyAttackState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsPatroling", false);
        animator.SetBool("IsFollowing", false);
        animator.SetBool("RecoilHeavy", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    #region HeavyAttack
        //animator.SetFloat("TotalTimer", animator.GetFloat("TotalTimer") + Time.deltaTime);

        //animator.GetComponent<EnemyManager>().ActivateDifferentCicleHeavy();

        //if(animator.GetFloat("TotalTimer") >= animator.GetComponent<EnemyManager>().CooldownTimerHeavy + animator.GetComponent<EnemyManager>().MaxDeactiveColliderTimerHeavy + animator.GetComponent<EnemyManager>().MaxInitialTimerHeavy + +0.01f)
        //{
        //    //animator.SetBool("CanAttack", false);
        //}
        //#endregion
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyManager>().HeavyAttackCollider.SetActive(true);
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
