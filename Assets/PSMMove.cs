using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSMMove : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        #region Movement Zone
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
            animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(0, animator.GetComponent<PSMController>().RB2D.velocity.y);                                                                                  //Setto a 0 la velocità sulla x (Orizzontale)
            animator.SetBool("PSM-CanMove", false);                                                                                                                                                                              //Ritorno in idle
        }
        #endregion

        #region Jump Zone
        if (Input.GetKey(KeyCode.Space))     //Se schiaccio spazio
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

        #region Dash Zone
        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift)) && animator.GetBool("PSM-CanDash") == false && animator.GetComponent<PSMController>().CooldownDashDirectional == false)
        {
            animator.SetBool("PSM-CanDash", true);
        }
        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift)) && animator.GetBool("PSM-CanDash") == false && animator.GetComponent<PSMController>().CooldownDashDirectional == false)
        {
            animator.SetBool("PSM-CanDash", true);
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


//Posso entrare in quest o stato solo se sto toccando il terreno, quindi possibile if che ricopre la parte sopra