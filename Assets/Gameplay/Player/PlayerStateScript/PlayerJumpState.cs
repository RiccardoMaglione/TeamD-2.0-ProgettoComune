using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class PlayerJumpState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.SetBool("IsGroundFallDash", true);
        if (animator.GetComponent<PlayerController>().Grounded == true /*&& animator.GetComponent<PlayerController>().rb.velocity.y == 0 */&& animator.GetComponent<PlayerController>().canJump == true)
        {
            animator.GetComponent<PlayerController>().rb.AddForce(Vector2.up * animator.GetComponent<PlayerController>().ValueJump.InitialJumpForce, ForceMode2D.Impulse);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        #region Jump Zone
        animator.SetBool("IsJump", false);
        if (Input.GetKey(KeyCode.Space) && animator.GetComponent<PlayerController>().Grounded == true /*&& animator.GetComponent<PlayerController>().rb.velocity.y == 0 */&& animator.GetComponent<PlayerController>().canJump == true)
        {
            animator.GetComponent<PlayerController>().rb.AddForce(Vector2.up * animator.GetComponent<PlayerController>().ValueJump.jumpForce, ForceMode2D.Impulse);
            animator.GetComponent<PlayerController>().Grounded = false;
            animator.GetComponent<PlayerController>().canJump = false;
            Debug.Log("Bloccato 5");
        }
        else if (animator.GetComponent<PlayerController>().rb.velocity.y > 1 && !Input.GetButton("Jump")) //If Jump
        {
            animator.GetComponent<PlayerController>().rb.velocity += Vector2.up * Physics2D.gravity.y * (animator.GetComponent<PlayerController>().ValueJump.lowJumpMultiplier - 1) * Time.deltaTime;
            Debug.Log("Bloccato 4");
        }
        else if (animator.GetComponent<PlayerController>().rb.velocity.y < 4 && animator.GetComponent<PlayerController>().rb.velocity.y > 0)
        {
            animator.GetComponent<PlayerController>().rb.velocity = new Vector2(animator.GetComponent<PlayerController>().rb.velocity.x, 0);
            Debug.Log("Bloccato 3");
        }

        if (animator.GetComponent<PlayerController>().rb.velocity.y <= 0)
        {
            Debug.Log("Bloccato 2");
            animator.SetBool("IsJump", false);
            animator.SetBool("IsFall", true);
            animator.Play("Fall");
        }
        if (animator.GetComponent<PlayerController>().rb.velocity.y == 0)
        {
            animator.SetBool("IsJump", false);
            animator.SetBool("IsFall", true);
            animator.SetBool("DashJumpInJump", true);
            animator.Play("Fall");
            Debug.Log("Bloccato 1");
        }
        #endregion

        #region Movement in Jump Zone
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.GetComponent<PlayerController>().ValueMovement.Speed = animator.GetComponent<PlayerController>().tempSpeed;
            animator.GetComponent<PlayerController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PlayerController>().transform.rotation.x, -180, animator.GetComponent<PlayerController>().transform.rotation.z);
            Debug.Log("Bloccato 6");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.GetComponent<PlayerController>().ValueMovement.Speed = animator.GetComponent<PlayerController>().tempSpeed;
            animator.GetComponent<PlayerController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PlayerController>().transform.rotation.x, 0, animator.GetComponent<PlayerController>().transform.rotation.z);
            Debug.Log("Bloccato 7");
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.GetComponent<PlayerController>().CalculateSpeed();
            animator.GetComponent<PlayerController>().rb.velocity = new Vector2(-animator.GetComponent<PlayerController>().ValueMovement.Speed, animator.GetComponent<PlayerController>().rb.velocity.y);
            animator.GetComponent<PlayerController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PlayerController>().transform.rotation.x, -180, animator.GetComponent<PlayerController>().transform.rotation.z);
            Debug.Log("Bloccato 8");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.GetComponent<PlayerController>().CalculateSpeed();
            animator.GetComponent<PlayerController>().rb.velocity = new Vector2(animator.GetComponent<PlayerController>().ValueMovement.Speed, animator.GetComponent<PlayerController>().rb.velocity.y);
            animator.GetComponent<PlayerController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PlayerController>().transform.rotation.x, 0, animator.GetComponent<PlayerController>().transform.rotation.z);
            Debug.Log("Bloccato 9");
        }
        else
        {
            animator.GetComponent<PlayerController>().rb.velocity = new Vector2(0, animator.GetComponent<PlayerController>().rb.velocity.y);
            animator.SetBool("IsMove", false);
            Debug.Log("Bloccato 10");
        }
        #endregion

        #region Dash in Jump Zone
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.GetComponent<PlayerController>().CanDash = true;
            Debug.Log("Bloccato 11");
        }
        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftControl) || (Input.GetKey(KeyCode.LeftShift))) && animator.GetComponent<PlayerController>().CanDashRight == false && animator.GetComponent<PlayerController>().CanDashJump == true && animator.GetComponent<PlayerController>().GravityChange == true && animator.GetComponent<PlayerController>().CanDash == true)
        {
            animator.GetComponent<PlayerController>().CanDashLeft = true;
            animator.SetBool("IsDash", true);
            Debug.Log("Bloccato 12");
        }
        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftControl) || (Input.GetKey(KeyCode.LeftShift))) && animator.GetComponent<PlayerController>().CanDashLeft == false && animator.GetComponent<PlayerController>().CanDashJump == true && animator.GetComponent<PlayerController>().GravityChange == true && animator.GetComponent<PlayerController>().CanDash == true)
        {
            animator.GetComponent<PlayerController>().CanDashRight = true;
            animator.SetBool("IsDash", true);
            Debug.Log("Bloccato 13");
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
