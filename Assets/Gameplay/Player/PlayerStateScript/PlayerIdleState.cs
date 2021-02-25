using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class PlayerIdleState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PlayerController>().Grounded = true;
        animator.SetBool("IsFall", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("CanDashFall", false);
        animator.GetComponent<PlayerController>().Grounded = true;

        #region Set Movement State
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D)))
        {
            animator.SetBool("IsMove", true);
        }
        else
        {
            animator.GetComponent<PlayerController>().rb.velocity = new Vector2(0, animator.GetComponent<PlayerController>().rb.velocity.y);
            animator.SetBool("IsMove", false);
        }
        #endregion

        #region Set Jump State
        if (Input.GetKey(KeyCode.Space) && (animator.GetComponent<PlayerController>().Grounded == true || animator.GetComponent<PlayerController>().rb.velocity.y == 0) && animator.GetComponent<PlayerController>().canJump == true)
        {
            animator.SetBool("IsJump", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.GetComponent<PlayerController>().canJump = true;
        }
        #endregion

        #region Set Fall State
        if (animator.GetComponent<PlayerController>().rb.velocity.y < 0)
        {
            animator.SetBool("IsFall", true);
        }

        if (animator.GetComponent<PlayerController>().Grounded == true)
        {
            animator.SetBool("IsGroundFallDash", true);
        }
        #endregion
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
