using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class PSMAttack : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("PSM-Attack", false);
        //animator.GetComponent<PSMController>().RB2D.velocity = Vector2.zero;
        animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(0, animator.GetComponent<PSMController>().RB2D.velocity.y);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(0, animator.GetComponent<PSMController>().RB2D.velocity.y);
        //animator.GetComponent<PSMController>().RB2D.velocity = Vector2.zero;

        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("DPad X") < 0) && (DialogueType1.StaticTutorial != -1 && DialogueType1.StaticTutorial2 != 2 && DialogueType1.StaticTutorial != 4 && DialogueType1.StaticTutorial != 6) && SpecialBKIdle.BoriousMove == true)                                                                                                                                                                                        //Se schiaccio A vado a sinistra
        {
            animator.GetComponent<PSMController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PSMController>().transform.rotation.x, -180, animator.GetComponent<PSMController>().transform.rotation.z);   //Ruoto il player
        }
        else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("DPad X") > 0) && (DialogueType1.StaticTutorial != -1 && DialogueType1.StaticTutorial2 != 2 && DialogueType1.StaticTutorial != 4 && DialogueType1.StaticTutorial != 6) && SpecialBKIdle.BoriousMove == true)                                                                                                                                                                                   //Se schiaccio D vado a destra
        {
            animator.GetComponent<PSMController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PSMController>().transform.rotation.x, 0, animator.GetComponent<PSMController>().transform.rotation.z);      //Ruoto il player
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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
