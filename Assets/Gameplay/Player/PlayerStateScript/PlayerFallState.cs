using SwordGame;
using UnityEngine;

public class PlayerFallState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("OnlyOnceFall", false);
        //animator.GetComponent<PlayerController>().Grounded = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        #region Fall
        if (animator.GetComponent<PlayerController>().rb.velocity.y < 0f) //If fall
        {
            animator.GetComponent<PlayerController>().rb.velocity += Vector2.up * Physics2D.gravity.y * (animator.GetComponent<PlayerController>().ValueJump.fallMultiplier - 1) * Time.deltaTime;
            animator.GetComponent<PlayerController>().Grounded = false;
        }

        if (animator.GetComponent<PlayerController>().Grounded == true/* || animator.GetComponent<PlayerController>().rb.velocity.y == 0*/)
        {
            animator.SetBool("IsFall", false);
            animator.SetBool("CanDashFall", false);
            //animator.GetComponent<PlayerController>().Grounded = true;
        }
        #endregion

        #region Movement in Fall Zone
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.GetComponent<PlayerController>().ValueMovement.Speed = animator.GetComponent<PlayerController>().tempSpeed;
            animator.GetComponent<PlayerController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PlayerController>().transform.rotation.x, -180, animator.GetComponent<PlayerController>().transform.rotation.z);
            //if (animator.GetComponent<PlayerController>().Grounded == true || animator.GetComponent<PlayerController>().rb.velocity.y == 0)
            //{
            //    animator.SetBool("IsFall", false);
            //    animator.SetBool("CanDashFall", false);
            //    //animator.GetComponent<PlayerController>().Grounded = true;
            //}
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.GetComponent<PlayerController>().ValueMovement.Speed = animator.GetComponent<PlayerController>().tempSpeed;
            animator.GetComponent<PlayerController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PlayerController>().transform.rotation.x, 0, animator.GetComponent<PlayerController>().transform.rotation.z);
            //if (animator.GetComponent<PlayerController>().Grounded == true || animator.GetComponent<PlayerController>().rb.velocity.y == 0)
            //{
            //    animator.SetBool("IsFall", false);
            //    animator.SetBool("CanDashFall", false);
            //    //animator.GetComponent<PlayerController>().Grounded = true;
            //}
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.GetComponent<PlayerController>().CalculateSpeed();
            animator.GetComponent<PlayerController>().rb.velocity = new Vector2(-animator.GetComponent<PlayerController>().ValueMovement.Speed, animator.GetComponent<PlayerController>().rb.velocity.y);
            animator.GetComponent<PlayerController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PlayerController>().transform.rotation.x, -180, animator.GetComponent<PlayerController>().transform.rotation.z);
            //if (animator.GetComponent<PlayerController>().Grounded == true || animator.GetComponent<PlayerController>().rb.velocity.y == 0)
            //{
            //    animator.SetBool("IsFall", false);
            //    animator.SetBool("CanDashFall", false);
            //    //animator.GetComponent<PlayerController>().Grounded = true;
            //}
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.GetComponent<PlayerController>().CalculateSpeed();
            animator.GetComponent<PlayerController>().rb.velocity = new Vector2(animator.GetComponent<PlayerController>().ValueMovement.Speed, animator.GetComponent<PlayerController>().rb.velocity.y);
            animator.GetComponent<PlayerController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PlayerController>().transform.rotation.x, 0, animator.GetComponent<PlayerController>().transform.rotation.z);
            //if (animator.GetComponent<PlayerController>().Grounded == true || animator.GetComponent<PlayerController>().rb.velocity.y == 0)
            //{
            //    animator.SetBool("IsFall", false);
            //    animator.SetBool("CanDashFall", false);
            //    //animator.GetComponent<PlayerController>().Grounded = true;
            //}
        }
        else
        {
            animator.GetComponent<PlayerController>().rb.velocity = new Vector2(0, animator.GetComponent<PlayerController>().rb.velocity.y);
            animator.SetBool("IsMove", false);
            //if (animator.GetComponent<PlayerController>().Grounded == true || animator.GetComponent<PlayerController>().rb.velocity.y == 0)
            //{
            //    animator.SetBool("IsFall", false);
            //    animator.SetBool("CanDashFall", false);
            //    //animator.GetComponent<PlayerController>().Grounded = true;
            //}
        }
        #endregion

        #region Active Dash in Fall Zone
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftControl))
        {
            JumpTest.isJumping = false;

            animator.GetComponent<PlayerController>().CanDash = true;
            animator.SetBool("IsDash", false);
        }
        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftControl) || (Input.GetKey(KeyCode.LeftShift))) && animator.GetComponent<PlayerController>().CanDashRight == false && animator.GetComponent<PlayerController>().CanDashJump == true && animator.GetComponent<PlayerController>().GravityChange == true && animator.GetComponent<PlayerController>().CanDash == true && animator.GetBool("CanDashFall") == false)
        {
            JumpTest.isJumping = false;

            animator.GetComponent<PlayerController>().CanDashLeft = true;
            animator.SetBool("IsDash", false);
            animator.SetBool("CanDashFall", true);
        }
        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftControl) || (Input.GetKey(KeyCode.LeftShift))) && animator.GetComponent<PlayerController>().CanDashLeft == false && animator.GetComponent<PlayerController>().CanDashJump == true && animator.GetComponent<PlayerController>().GravityChange == true && animator.GetComponent<PlayerController>().CanDash == true && animator.GetBool("CanDashFall") == false)
        {
            JumpTest.isJumping = false;

            animator.GetComponent<PlayerController>().CanDashRight = true;
            animator.SetBool("IsDash", false);
            animator.SetBool("CanDashFall", true);
        }
        #endregion
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
