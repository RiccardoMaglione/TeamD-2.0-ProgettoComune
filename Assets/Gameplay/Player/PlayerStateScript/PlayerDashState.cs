using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class PlayerDashState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("GroundDash", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        #region Left Dash
        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftControl) || (Input.GetKey(KeyCode.LeftShift))) && animator.GetComponent<PlayerController>().CanDashRight == false && animator.GetComponent<PlayerController>().CanDashJump == true && animator.GetComponent<PlayerController>().GravityChange == true && animator.GetComponent<PlayerController>().CanDash == true)
        {
            animator.GetComponent<PlayerController>().CanDashLeft = true;
            animator.GetComponent<PlayerController>().CanDash = false;
            animator.GetComponent<PlayerController>().GetComponent<Rigidbody2D>().gravityScale = 0.000001f;
            animator.GetComponent<PlayerController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PlayerController>().transform.rotation.x, -180, animator.GetComponent<PlayerController>().transform.rotation.z);
            animator.GetComponent<PlayerController>().EffectDash();
        }
        if (animator.GetComponent<PlayerController>().CanDashLeft == true && animator.GetComponent<PlayerController>().TimerDash <= animator.GetComponent<PlayerController>().LimitTimerDash)
        {
            animator.GetComponent<PlayerController>().rb.velocity = new Vector2(-animator.GetComponent<PlayerController>().ValueMovement.Speed * 5, 0);
            animator.GetComponent<PlayerController>().TimerDash += Time.deltaTime;
            if (animator.GetComponent<PlayerController>().TimerDash >= animator.GetComponent<PlayerController>().LimitTimerDash)
            {
                animator.GetComponent<PlayerController>().StartCoroutine(animator.GetComponent<PlayerController>().CooldownDash());
            }
        }
        #endregion

        #region Right Dash
        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftControl) || (Input.GetKey(KeyCode.LeftShift))) && animator.GetComponent<PlayerController>().CanDashLeft == false && animator.GetComponent<PlayerController>().CanDashJump == true && animator.GetComponent<PlayerController>().GravityChange == true && animator.GetComponent<PlayerController>().CanDash == true)
        {
            animator.GetComponent<PlayerController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PlayerController>().transform.rotation.x, 0, animator.GetComponent<PlayerController>().transform.rotation.z);
            animator.GetComponent<PlayerController>().GetComponent<Rigidbody2D>().gravityScale = 0.000001f;
            animator.GetComponent<PlayerController>().CanDashRight = true;
            animator.GetComponent<PlayerController>().CanDash = false;
            animator.GetComponent<PlayerController>().EffectDash();
        }
        if (animator.GetComponent<PlayerController>().CanDashRight == true && animator.GetComponent<PlayerController>().TimerDash <= animator.GetComponent<PlayerController>().LimitTimerDash)
        {
            animator.GetComponent<PlayerController>().rb.velocity = new Vector2(animator.GetComponent<PlayerController>().ValueMovement.Speed * 5, 0);
            animator.GetComponent<PlayerController>().TimerDash += Time.deltaTime;
            if (animator.GetComponent<PlayerController>().TimerDash >= animator.GetComponent<PlayerController>().LimitTimerDash)
            {
                animator.GetComponent<PlayerController>().StartCoroutine(animator.GetComponent<PlayerController>().CooldownDash());
            }
        }
        #endregion
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsFall", false);
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
