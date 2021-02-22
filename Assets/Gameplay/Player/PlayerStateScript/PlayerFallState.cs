using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class PlayerFallState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("OnlyOnceFall", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (animator.GetComponent<PlayerController>().Grounded == true || animator.GetComponent<PlayerController>().rb.velocity.y == 0)
        {
            animator.SetBool("IsFall", false);
            animator.GetComponent<PlayerController>().Grounded = true;
            Debug.Log("cuasdasda1");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.GetComponent<PlayerController>().ValueMovement.Speed = animator.GetComponent<PlayerController>().tempSpeed;
            animator.GetComponent<PlayerController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PlayerController>().transform.rotation.x, -180, animator.GetComponent<PlayerController>().transform.rotation.z);
            if (animator.GetComponent<PlayerController>().Grounded == true || animator.GetComponent<PlayerController>().rb.velocity.y == 0)
            {
                animator.SetBool("IsFall", false);
                animator.GetComponent<PlayerController>().Grounded = true;
                Debug.Log("cuasdasda2");
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.GetComponent<PlayerController>().ValueMovement.Speed = animator.GetComponent<PlayerController>().tempSpeed;
            animator.GetComponent<PlayerController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PlayerController>().transform.rotation.x, 0, animator.GetComponent<PlayerController>().transform.rotation.z);
            if (animator.GetComponent<PlayerController>().Grounded == true || animator.GetComponent<PlayerController>().rb.velocity.y == 0)
            {
                animator.SetBool("IsFall", false);
                animator.GetComponent<PlayerController>().Grounded = true;
                Debug.Log("cuasdasda3");
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.GetComponent<PlayerController>().CalculateSpeed();
            animator.GetComponent<PlayerController>().rb.velocity = new Vector2(-animator.GetComponent<PlayerController>().ValueMovement.Speed, animator.GetComponent<PlayerController>().rb.velocity.y);
            animator.GetComponent<PlayerController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PlayerController>().transform.rotation.x, -180, animator.GetComponent<PlayerController>().transform.rotation.z);
            if (animator.GetComponent<PlayerController>().Grounded == true || animator.GetComponent<PlayerController>().rb.velocity.y == 0)
            {
                animator.SetBool("IsFall", false);
                animator.GetComponent<PlayerController>().Grounded = true;
                Debug.Log("cuasdasda4");
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.GetComponent<PlayerController>().CalculateSpeed();
            animator.GetComponent<PlayerController>().rb.velocity = new Vector2(animator.GetComponent<PlayerController>().ValueMovement.Speed, animator.GetComponent<PlayerController>().rb.velocity.y);
            animator.GetComponent<PlayerController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PlayerController>().transform.rotation.x, 0, animator.GetComponent<PlayerController>().transform.rotation.z);
            if (animator.GetComponent<PlayerController>().Grounded == true || animator.GetComponent<PlayerController>().rb.velocity.y == 0)
            {
                animator.SetBool("IsFall", false);
                animator.GetComponent<PlayerController>().Grounded = true;
                Debug.Log("cuasdasda5");
            }
        }
        else
        {
            animator.GetComponent<PlayerController>().rb.velocity = new Vector2(0, animator.GetComponent<PlayerController>().rb.velocity.y);
            animator.SetBool("IsMove", false);
            if (animator.GetComponent<PlayerController>().Grounded == true || animator.GetComponent<PlayerController>().rb.velocity.y == 0)
            {
                animator.SetBool("IsFall", false);
                animator.GetComponent<PlayerController>().Grounded = true;
                Debug.Log("cuasdasda6");
            }
        }

        //if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftControl) || (Input.GetKey(KeyCode.LeftShift))) && animator.GetComponent<PlayerController>().CanDashRight == false && animator.GetComponent<PlayerController>().CanDashJump == true && animator.GetComponent<PlayerController>().GravityChange == true && animator.GetComponent<PlayerController>().CanDash == true)
        //{
        //    animator.GetComponent<PlayerController>().CanDashLeft = true;
        //    animator.SetBool("IsDash", true);
        //}
        //if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftControl) || (Input.GetKey(KeyCode.LeftShift))) && animator.GetComponent<PlayerController>().CanDashLeft == false && animator.GetComponent<PlayerController>().CanDashJump == true && animator.GetComponent<PlayerController>().GravityChange == true && animator.GetComponent<PlayerController>().CanDash == true)
        //{
        //    animator.GetComponent<PlayerController>().CanDashRight = true;
        //    animator.SetBool("IsDash", true);
        //}


        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.GetComponent<PlayerController>().CanDash = true;
            animator.SetBool("IsDash", false);
        }
        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftControl) || (Input.GetKey(KeyCode.LeftShift))) && animator.GetComponent<PlayerController>().CanDashRight == false && animator.GetComponent<PlayerController>().CanDashJump == true && animator.GetComponent<PlayerController>().GravityChange == true && animator.GetComponent<PlayerController>().CanDash == true && animator.GetBool("CanDashFall") == false)
        {
            animator.GetComponent<PlayerController>().CanDashLeft = true;
            animator.SetBool("IsDash", false);
            animator.SetBool("CanDashFall", true);
        }
        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftControl) || (Input.GetKey(KeyCode.LeftShift))) && animator.GetComponent<PlayerController>().CanDashLeft == false && animator.GetComponent<PlayerController>().CanDashJump == true && animator.GetComponent<PlayerController>().GravityChange == true && animator.GetComponent<PlayerController>().CanDash == true && animator.GetBool("CanDashFall") == false)
        {
            animator.GetComponent<PlayerController>().CanDashRight = true;
            animator.SetBool("IsDash", false);
            animator.SetBool("CanDashFall", true);
        }
        
        if (animator.GetComponent<PlayerController>().rb.velocity.y < 0) //Se cade
        {
            animator.GetComponent<PlayerController>().rb.velocity += Vector2.up * Physics2D.gravity.y * (animator.GetComponent<PlayerController>().ValueJump.fallMultiplier - 1) * Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("OnlyOnceFall", true);
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
