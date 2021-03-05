using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSMDash : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        #region Left Dash
        Debug.Log("PlayerState - State Dash");
        if (animator.GetComponent<PSMController>().CooldownDashDirectional == false && animator.GetBool("CanDashInAir") == false)    //Se CanDashInAir è falso entra sempre, altrimenti entra solo 1 volta
        {
            Debug.Log("PlayerState - Initial dash");
            if (/*Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftControl) || (Input.GetKey(KeyCode.LeftShift))) && */animator.GetComponent<PSMController>().CanDashRight == false)
            {
                Debug.Log("PlayerState - Dash sinistro");
                animator.GetComponent<PSMController>().CanDashLeft = true;
                animator.GetComponent<PSMController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PSMController>().transform.rotation.x, -180, animator.GetComponent<PSMController>().transform.rotation.z);
                //animator.GetComponent<PlayerController>().EffectDash();
            }
            if (animator.GetComponent<PSMController>().CanDashLeft == true && animator.GetComponent<PSMController>().TimerDash <= animator.GetComponent<PSMController>().LimitTimerDash)
            {
                animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(-animator.GetComponent<PSMController>().ValueMovement.Speed * 5, 0);
                animator.GetComponent<PSMController>().TimerDash += Time.deltaTime;
                if (animator.GetComponent<PSMController>().TimerDash >= animator.GetComponent<PSMController>().LimitTimerDash)
                {
                    animator.GetComponent<PSMController>().CooldownDashDirectional = true;
                    Debug.Log("PlayerState - Entra nel cooldown - Dash sinistro");
                    animator.SetBool("PSM-CanDash", false);
                    if (animator.GetBool("PSM-IsGrounded") == false)        //Se non tocca il pavimento
                    {
                        animator.SetBool("PSM-CanDashInAir", true);         //Blocco la possibilità di rientrare nel dash dallo stato di caduta
                        Debug.Log("PlayerState - Air dash - Dash destro");
                    }
                    //animator.GetComponent<PlayerController>().StartCoroutine(animator.GetComponent<PlayerController>().CooldownDash());
                }
            }
            #endregion

            #region Right Dash
            if (/*Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftControl) || (Input.GetKey(KeyCode.LeftShift))) &&*/ animator.GetComponent<PSMController>().CanDashLeft == false)
            {
                Debug.Log("PlayerState - Dash Destro");
                animator.GetComponent<PSMController>().CanDashRight = true;
                animator.GetComponent<PSMController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PSMController>().transform.rotation.x, 0, animator.GetComponent<PSMController>().transform.rotation.z);
                //animator.GetComponent<PlayerController>().EffectDash();
            }
            if (animator.GetComponent<PSMController>().CanDashRight == true && animator.GetComponent<PSMController>().TimerDash <= animator.GetComponent<PSMController>().LimitTimerDash && animator.GetBool("PSM-CanDash") == true)
            {
                animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(animator.GetComponent<PSMController>().ValueMovement.Speed * 5, 0);
                animator.GetComponent<PSMController>().TimerDash += Time.deltaTime;
                if (animator.GetComponent<PSMController>().TimerDash >= animator.GetComponent<PSMController>().LimitTimerDash)
                {
                    animator.GetComponent<PSMController>().CooldownDashDirectional = true;
                    Debug.Log("PlayerState - Entra nel cooldown - Dash destro");
                    animator.SetBool("PSM-CanDash", false);
                    if (animator.GetBool("PSM-IsGrounded") == false)        //Se non tocca il pavimento
                    {
                        animator.SetBool("PSM-CanDashInAir", true);         //Blocco la possibilità di rientrare nel dash dallo stato di caduta
                        Debug.Log("PlayerState - Air dash - Dash destro");
                    }
                    //animator.GetComponent<PlayerController>().StartCoroutine(animator.GetComponent<PlayerController>().CooldownDash());
                }
            }
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
