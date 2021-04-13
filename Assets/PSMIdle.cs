using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class PSMIdle : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PSMController>().OnceJump = false;
        PlayerParticlesController.instance.StopRun();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        #region Move Zone - Da "Player Idle State" da "Player Move State"
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))                                                                             //Se schiaccio A o D
        {
            Debug.Log("PlayerState - Vai nello stato 'PSMMove'");                                                                           //Debuggo in console cosa fa
            animator.SetBool("PSM-CanMove", true);                                                                                          //Cambio stato da "Player Idle State" in "Player Move State"
        }

        animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(0, animator.GetComponent<PSMController>().RB2D.velocity.y);      //Per sicurezza blocca il movimento - non dovrebbe servire
        #endregion

        #region Jump Zone - Da "Player Idle State" da "Player Jump State"
        if (Input.GetKeyDown(KeyCode.Space))                                                                                                //Se schiaccio spazio una volta
        {
            Debug.Log("PlayerState - Vai nello stato 'PSMJump'");                                                                           //Debuggo in console cosa fa
            animator.SetTrigger("PSM-CanJump");                                                                                             //Setto attivo il trigger - Prima condizione per il cambio stato da "Player Idle State" in "Player Jump State"
            if (animator.GetBool("PSM-IsGrounded") == true && animator.GetComponent<PSMController>().OnceJump == false)                     //Se tocca terra ed è il primo ciclo (OnceJump non dovrebbe servire ma è stato messo per sicurezza)
            {
                //animator.GetComponent<PSMController>().InitialPos = animator.transform.position;
                animator.GetComponent<PSMController>().OnceJump = true;                                                                                                             //Controllo di sicurezza per eseguirlo solo una volta
                animator.GetComponent<PSMController>().RB2D.AddForce(Vector2.up * animator.GetComponent<PSMController>().ValueJump.InitialJumpForce, ForceMode2D.Impulse);          //Spinta iniziale per evitare un salto non visibile
                Debug.Log("PlayerState - Primo passaggio del salto'");                                                                      //Debuggo in console il numero del passaggio
            }
        }
        #endregion

        #region Fall Zone - Da "Player Idle State" da "Player Fall State"
        if (animator.GetComponent<PSMController>().RB2D.velocity.y < 0)                                                                     //Se la velocità di y è minore di 0 - Non minore e uguale perché lo stato di idle sta sempre uguale a 0
        {
            Debug.Log("PlayerState - Vai in 'Player Fall State'");                                                                          //Debuggo in console cosa fa
            animator.SetBool("PSM-IsGrounded", false);                                                                                      //Setto la prima condizione del tocco del terreno a falso, per entrare in "Player Fall State" da "Player Idle State"
            animator.SetTrigger("PSM-IsInFall");                                                                                            //Setto la seconda condizione, un trigger, attivo, per entrare in "Player Fall State" da "Player Idle State"
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
