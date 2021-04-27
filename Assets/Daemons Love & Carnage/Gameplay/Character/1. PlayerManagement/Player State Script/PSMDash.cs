using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class PSMDash : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        switch (animator.GetComponent<PSMController>().TypeCharacter)
        {
            case TypePlayer.FatKnight:
                animator.GetComponentInChildren<FatKnightParticleController>().PlayDash();
                break;
            case TypePlayer.BoriousKnight:
                animator.GetComponentInChildren<BoriousKnightParticlesController>().PlayDash();
                break;
            case TypePlayer.Babushka:
                animator.GetComponentInChildren<BabushkaParticleController>().PlayDash();
                break;
            case TypePlayer.Thief:
                animator.GetComponentInChildren<ThiefParticlesController>().PlayDash();
                break;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("PlayerState - State Dash");                                                                                          //Debuggo in console cosa fa e il punto in cui è arrivato
        if (animator.GetComponent<PSMController>().CooldownDashDirectional == false && animator.GetBool("CanDashInAir") == false)       //Se CanDashInAir è falso entra sempre, altrimenti entra solo 1 volta
        {
            #region Left Dash - Dash del Player verso sinistra - Possibili cambi di stato: da "Player Dash State" a "Player Move State" o a "Player Fall State"
            //Debug.Log("PlayerState - Initial dash");                                                                                    //Debuggo in console cosa fa e il punto in cui è arrivato
            if (animator.GetComponent<PSMController>().CanDashRight == false)                                                           //Se la direzione destra è falsa, entro nel dash sinistro
            {
                //Debug.Log("PlayerState - Dash sinistro");                                                                               //Debuggo in console cosa fa e il punto in cui è arrivato
                animator.GetComponent<PSMController>().CanDashLeft = true;                                                              //Setto a vero la direzione Sinistra
                animator.GetComponent<PSMController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PSMController>().transform.rotation.x, -180, animator.GetComponent<PSMController>().transform.rotation.z);       //Setto la rotazione del player verso sinistra
                //animator.GetComponent<PlayerController>().EffectDash();
            }
            if (animator.GetComponent<PSMController>().CanDashLeft == true && animator.GetComponent<PSMController>().TimerDash <= animator.GetComponent<PSMController>().LimitTimerDash && animator.GetBool("PSM-CanDash") == true)    //Se può dashare a sinistra e il timer non è ancora terminato e la condizione di poter dashare è vera
            {
                animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(-animator.GetComponent<PSMController>().ValueMovement.Speed * animator.GetComponent<PSMController>().VelocityDash, 0);     //Aumento la velocità di x di *5 (Valore da modifica da inspector)
                animator.GetComponent<PSMController>().TimerDash += Time.deltaTime;
                if (animator.GetComponent<PSMController>().TimerDash >= animator.GetComponent<PSMController>().LimitTimerDash)          //Se la durata del dash è scaduta
                {
                    animator.GetComponent<PSMController>().CooldownDashDirectional = true;                                              //Setto a vero la condizione per entrare nella fase di cooldown del dash
                    //Debug.Log("PlayerState - Entra nel cooldown - Dash sinistro");                                                      //Debuggo in console cosa fa e il punto in cui è arrivato
                    animator.SetBool("PSM-CanDash", false);
                    if (animator.GetBool("PSM-IsGrounded") == false)                                                                    //Se non tocca il pavimento
                    {
                        animator.SetBool("PSM-CanDashInAir", true);                                                                     //Blocco la possibilità di rientrare nel dash dallo stato di caduta
                        //Debug.Log("PlayerState - Air dash - Dash destro");                                                              //Debuggo in console cosa fa e il punto in cui è arrivato
                    }
                }
            }
            #endregion

            #region Right Dash - Dash del Player verso destra - Possibili cambi di stato: da "Player Dash State" a "Player Move State" o a "Player Fall State"
            if (animator.GetComponent<PSMController>().CanDashLeft == false)                                                            //Se la direzione sinistra è falsa, entro nel dash destro
            {
                //Debug.Log("PlayerState - Dash Destro");                                                                                 //Debuggo in console cosa fa e il punto in cui è arrivato
                animator.GetComponent<PSMController>().CanDashRight = true;                                                             //Setto a vero la direzione destra
                animator.GetComponent<PSMController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PSMController>().transform.rotation.x, 0, animator.GetComponent<PSMController>().transform.rotation.z);              //Setto la rotazione del player verso destra
                //animator.GetComponent<PlayerController>().EffectDash();
            }
            if (animator.GetComponent<PSMController>().CanDashRight == true && animator.GetComponent<PSMController>().TimerDash <= animator.GetComponent<PSMController>().LimitTimerDash && animator.GetBool("PSM-CanDash") == true)    //Se può dashare a destra e il timer non è ancora terminato e la condizione di poter dashare è vera
            {
                animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(animator.GetComponent<PSMController>().ValueMovement.Speed * animator.GetComponent<PSMController>().VelocityDash, 0);      //Aumento la velocità di x di *5 (Valore da modifica da inspector)
                animator.GetComponent<PSMController>().TimerDash += Time.deltaTime;
                if (animator.GetComponent<PSMController>().TimerDash >= animator.GetComponent<PSMController>().LimitTimerDash)          //Se la durata del dash è scaduta
                {
                    animator.GetComponent<PSMController>().CooldownDashDirectional = true;                                              //Setto a vero la condizione per entrare nella fase di cooldown del dash
                    //Debug.Log("PlayerState - Entra nel cooldown - Dash destro");                                                        //Debuggo in console cosa fa e il punto in cui è arrivato
                    animator.SetBool("PSM-CanDash", false);
                    if (animator.GetBool("PSM-IsGrounded") == false)                                                                    //Se non tocca il pavimento
                    {
                        animator.SetBool("PSM-CanDashInAir", true);                                                                     //Blocco la possibilità di rientrare nel dash dallo stato di caduta
                        //Debug.Log("PlayerState - Air dash - Dash destro");                                                              //Debuggo in console cosa fa e il punto in cui è arrivato
                    }
                }
            }
            #endregion
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
