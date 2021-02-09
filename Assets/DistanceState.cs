using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyManager>().GetComponent<SpriteRenderer>().color = Color.cyan;
        animator.GetComponent<EnemyManager>().CanAttack = true;
        if (animator.GetComponent<EnemyManager>().PlayerEnemy != null)
        {
            float Distance = Vector2.Distance(animator.gameObject.transform.position, animator.GetComponent<EnemyManager>().PlayerEnemy.transform.position);
            if (Distance >= 1.5f)
            {
                animator.SetBool("Distance", true);
            }
            else
            {
                animator.SetBool("Distance", false);
            }
        }
        else
        {
            animator.SetBool("Distance", true);
        }
        Debug.Log("aaarandom" + animator.GetComponent<EnemyManager>().CanAttack);
        Debug.Log("aaarandom" + animator.GetComponent<EnemyManager>().CanVisible);
        Debug.Log("aaarandom2" + animator.GetComponent<EnemyManager>().isStun);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("aaaAttack" + animator.GetComponent<EnemyManager>().CanAttack);
        if (animator.GetComponent<EnemyManager>().CanAttack == true)
        {
            animator.GetComponent<EnemyManager>().random = Random.Range(0, 101);
            animator.GetComponent<EnemyManager>().CanAttack = false;
            Debug.Log("aaaCiao" + animator.GetComponent<EnemyManager>().CanVisible);
            Debug.Log("aaaCiao2" + animator.GetComponent<EnemyManager>().isStun);

        }
        if (animator.GetComponent<EnemyManager>().CanVisible == true && animator.GetComponent<EnemyManager>().isStun == false)
        {
            Debug.Log("aaaprova");
            if (animator.GetComponent<EnemyManager>().random <= animator.GetComponent<EnemyManager>().PercentuageAttack)
            {
                Debug.Log("aaaleggero");
                animator.SetTrigger("LightAttack");
                animator.SetBool("CanAttack", true);
            }
            else
            {
                Debug.Log("aaaPesante");
                animator.SetTrigger("HeavyAttack");
                animator.SetBool("CanAttack", true);
            }
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
