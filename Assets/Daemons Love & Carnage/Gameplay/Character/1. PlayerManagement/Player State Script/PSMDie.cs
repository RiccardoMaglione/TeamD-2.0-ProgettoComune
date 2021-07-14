using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class PSMDie : StateMachineBehaviour
{
    public bool OnlyOnce;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Stop("Sfx_player_walk");
        }

        animator.GetComponent<PSMController>().LightAttackCollider.SetActive(false);
        animator.GetComponent<PSMController>().HeavyAttackCollider.SetActive(false);
        animator.GetComponent<PSMController>().RB2D.velocity = Vector2.zero;

        if (OnlyOnce == false)
        {
            OnlyOnce = true;
            switch (animator.GetComponent<PSMController>().TypeCharacter)
            {
                case TypePlayer.FatKnight:
                    if(AudioManager.instance != null)
                    {
                        AudioManager.instance.Play("Sfx_FK_death");
                    }
                    break;
                case TypePlayer.BoriousKnight:
                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.Play("Sfx_BK_death");
                    }
                    break;
                case TypePlayer.Babushka:
                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.Play("Sfx_B_death");
                    }
                    break;
                case TypePlayer.Thief:
                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.Play("Sfx_T_death");
                    }
                    break;
                default:
                    break;


            }
        }

        if (animator.GetComponent<PSMController>().DashColliderBabushka != null)
            animator.GetComponent<PSMController>().DashColliderBabushka.SetActive(false);

        if (animator.GetComponent<PSMController>().DashColliderBorious != null)
            animator.GetComponent<PSMController>().DashColliderBorious.SetActive(false);

        if (animator.GetComponent<PSMController>().DashKnockbackFatKnight != null)
            animator.GetComponent<PSMController>().DashKnockbackFatKnight.SetActive(false);
        
        if(animator.GetComponent<PSMController>().TypeCharacter == TypePlayer.Thief)
            animator.GetComponentInChildren<ThiefParticlesController>().StopDash();

        //Destroy(animator.gameObject);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
