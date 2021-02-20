using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;
public class PlayerMoveState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.GetComponent<PlayerController>().ValueMovement.Speed = animator.GetComponent<PlayerController>().tempSpeed;
            //if(TempSprite != null)
            //    TempSprite.flipX = true;
            animator.GetComponent<PlayerController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PlayerController>().transform.rotation.x, -180, animator.GetComponent<PlayerController>().transform.rotation.z);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.GetComponent<PlayerController>().ValueMovement.Speed = animator.GetComponent<PlayerController>().tempSpeed;
            //if (TempSprite != null)
            //    TempSprite.flipX = false;
            animator.GetComponent<PlayerController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PlayerController>().transform.rotation.x, 0, animator.GetComponent<PlayerController>().transform.rotation.z);
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.GetComponent<PlayerController>().CalculateSpeed();
            animator.GetComponent<PlayerController>().rb.velocity = new Vector2(-animator.GetComponent<PlayerController>().ValueMovement.Speed, animator.GetComponent<PlayerController>().rb.velocity.y);
            animator.GetComponent<PlayerController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PlayerController>().transform.rotation.x, -180, animator.GetComponent<PlayerController>().transform.rotation.z);
            //if (TempSprite != null)
            //  TempSprite.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.GetComponent<PlayerController>().CalculateSpeed();
            animator.GetComponent<PlayerController>().rb.velocity = new Vector2(animator.GetComponent<PlayerController>().ValueMovement.Speed, animator.GetComponent<PlayerController>().rb.velocity.y);
            animator.GetComponent<PlayerController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PlayerController>().transform.rotation.x, 0, animator.GetComponent<PlayerController>().transform.rotation.z);
            //if (TempSprite != null)
            //  TempSprite.flipX = false;
        }
        else
        {
            animator.GetComponent<PlayerController>().rb.velocity = new Vector2(0, animator.GetComponent<PlayerController>().rb.velocity.y);
            animator.SetBool("IsMove", false);
        }

        if (Input.GetKey(KeyCode.Space) && (animator.GetComponent<PlayerController>().Grounded == true || animator.GetComponent<PlayerController>().rb.velocity.y == 0) && animator.GetComponent<PlayerController>().canJump == true)
        {
            animator.SetBool("IsJump", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.GetComponent<PlayerController>().canJump = true;
        }





        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.GetComponent<PlayerController>().CanDash = true;
        }

        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftControl) || (Input.GetKey(KeyCode.LeftShift))) && animator.GetComponent<PlayerController>().CanDashRight == false && animator.GetComponent<PlayerController>().CanDashJump == true && animator.GetComponent<PlayerController>().GravityChange == true && animator.GetComponent<PlayerController>().CanDash == true)
        {
            animator.GetComponent<PlayerController>().CanDashLeft = true;
            animator.SetBool("IsDash", true);
        }
        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftControl) || (Input.GetKey(KeyCode.LeftShift))) && animator.GetComponent<PlayerController>().CanDashLeft == false && animator.GetComponent<PlayerController>().CanDashJump == true && animator.GetComponent<PlayerController>().GravityChange == true && animator.GetComponent<PlayerController>().CanDash == true)
        {
            animator.GetComponent<PlayerController>().CanDashRight = true;
            animator.SetBool("IsDash", true);
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
