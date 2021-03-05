using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSMIdle : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        #region Move
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))     //Se schiaccio A o D
        {
            Debug.Log("PlayerState - Vai nello stato 'PSMMove'");           //Debuggo in console cosa fa
            animator.SetBool("PSM-CanMove", true);                          //Cambio stato in "Player Move State"
        }

        animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(0, animator.GetComponent<PSMController>().RB2D.velocity.y);      //Per sicurezza blocca il movimento - non dovrebbe servire
        #endregion

        #region Jump
        if (Input.GetKeyDown(KeyCode.Space))     //Se schiaccio spazio
        {
            Debug.Log("PlayerState - Vai nello stato 'PSMJump'");           //Debuggo in console cosa fa
            animator.SetTrigger("PSM-CanJump");                             //Setto attivo il trigger - Prima condizione per il cambio stato in "Player Jump State"
        }
        #endregion

        #region Fall
        if (animator.GetComponent<PSMController>().RB2D.velocity.y < 0)
        {
            Debug.Log("PlayerState - Vai in 'Player Fall State'");
            animator.SetBool("PSM-IsGrounded", false);
            animator.SetTrigger("PSM-IsInFall");
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
