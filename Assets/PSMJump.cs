using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSMJump : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if(animator.GetBool("PSM-IsGrounded") == true)
        //{
        //    animator.GetComponent<PSMController>().RB2D.AddForce(Vector2.up * animator.GetComponent<PSMController>().ValueJump.InitialJumpForce, ForceMode2D.Impulse);
        //}
        Debug.Log("PlayerState - Grounded'" + animator.GetBool("PSM-IsGrounded"));
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        #region Jump
        if (Input.GetKey(KeyCode.Space) && animator.GetBool("PSM-IsGrounded") == true)
        {
            animator.GetComponent<PSMController>().RB2D.AddForce(Vector2.up * animator.GetComponent<PSMController>().ValueJump.jumpForce, ForceMode2D.Impulse);
            animator.SetBool("PSM-IsGrounded", false);
        }
        else if (animator.GetComponent<PSMController>().RB2D.velocity.y > 1 && !Input.GetButton("Jump")) //If Jump
        {
            animator.GetComponent<PSMController>().RB2D.velocity += Vector2.up * Physics2D.gravity.y * (animator.GetComponent<PSMController>().ValueJump.lowJumpMultiplier - 1) * Time.deltaTime;
        }
        else if (animator.GetComponent<PSMController>().RB2D.velocity.y < 4 && animator.GetComponent<PSMController>().RB2D.velocity.y > 0)
        {
            animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(animator.GetComponent<PSMController>().RB2D.velocity.x, 0);
        }
        #endregion

        #region Fall
        if (animator.GetComponent<PSMController>().RB2D.velocity.y <= 0)
        {
            Debug.Log("PlayerState - Vai in 'Player Fall State'");
            animator.SetTrigger("PSM-IsInFall");
        }
        #endregion

        #region Move
        if (Input.GetKey(KeyCode.A))                                                                                                                                                                                        //Se schiaccio A vado a sinistra
        {
            animator.GetComponent<PSMController>().CalculateSpeed();                                                                                                                                                        //Calcolo la velocità
            animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(-animator.GetComponent<PSMController>().ValueMovement.Speed, animator.GetComponent<PSMController>().RB2D.velocity.y);                        //Aumento la velocità
            animator.GetComponent<PSMController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PSMController>().transform.rotation.x, -180, animator.GetComponent<PSMController>().transform.rotation.z);   //Ruoto il player
            Debug.Log("PlayerState - Vai a sinistra");
        }
        else if (Input.GetKey(KeyCode.D))                                                                                                                                                                                   //Se schiaccio D vado a destra
        {
            animator.GetComponent<PSMController>().CalculateSpeed();                                                                                                                                                        //Calcolo la velocità
            animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(animator.GetComponent<PSMController>().ValueMovement.Speed, animator.GetComponent<PSMController>().RB2D.velocity.y);                         //Aumento la velocità
            animator.GetComponent<PSMController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PSMController>().transform.rotation.x, 0, animator.GetComponent<PSMController>().transform.rotation.z);      //Ruoto il player
            Debug.Log("PlayerState - Vai a destra");
        }
        else                                                                                                                                                                                                                //Se non premo A e D
        {
            animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(0, animator.GetComponent<PSMController>().RB2D.velocity.y);                                                                                  //Setto a 0 la velocità sulla x (Orizzontale)                                                                                                                                                                              //Ritorno in idle
        }
        #endregion

        #region Dash Zone
        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift)) && animator.GetBool("PSM-CanDash") == false && animator.GetComponent<PSMController>().CooldownDashDirectional == false && animator.GetBool("PSM-CanDashInAir") == false)
        {
            animator.SetBool("PSM-CanDash", true);
            animator.GetComponent<PSMController>().CanDashLeft = true;
        }
        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift)) && animator.GetBool("PSM-CanDash") == false && animator.GetComponent<PSMController>().CooldownDashDirectional == false && animator.GetBool("PSM-CanDashInAir") == false)
        {
            animator.SetBool("PSM-CanDash", true);
            animator.GetComponent<PSMController>().CanDashRight = true;
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
