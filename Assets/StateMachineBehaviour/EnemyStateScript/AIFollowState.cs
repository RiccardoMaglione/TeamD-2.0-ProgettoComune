using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("IsFollowing") == true && animator.GetComponent<EnemyManager>().isStun == false/* && CanMoveAttack == true*/)
        {
            if (animator.GetComponent<EnemyManager>().PlayerEnemy != null)
            {
                if (animator.GetComponent<EnemyManager>().PlayerEnemy.transform.position.x + 1 > animator.GetComponent<EnemyManager>().transform.position.x)
                {
                    animator.GetComponent<EnemyManager>().transform.rotation = Quaternion.Euler(animator.GetComponent<EnemyManager>().transform.rotation.x, 0, animator.GetComponent<EnemyManager>().transform.rotation.z);           //Destra
                    animator.GetComponent<EnemyManager>().transform.position = Vector2.MoveTowards(animator.GetComponent<EnemyManager>().transform.position, new Vector2(animator.GetComponent<EnemyManager>().PlayerEnemy.transform.position.x - 1, animator.GetComponent<EnemyManager>().transform.position.y), animator.GetComponent<EnemyManager>().Speed * Time.deltaTime);
                }
                else if (animator.GetComponent<EnemyManager>().PlayerEnemy.transform.position.x - 1 < animator.GetComponent<EnemyManager>().transform.position.x)
                {
                    animator.GetComponent<EnemyManager>().transform.rotation = Quaternion.Euler(animator.GetComponent<EnemyManager>().transform.rotation.x, -180, animator.GetComponent<EnemyManager>().transform.rotation.z);         //Sinistra
                    animator.GetComponent<EnemyManager>().transform.position = Vector2.MoveTowards(animator.GetComponent<EnemyManager>().transform.position, new Vector2(animator.GetComponent<EnemyManager>().PlayerEnemy.transform.position.x + 1, animator.GetComponent<EnemyManager>().transform.position.y), animator.GetComponent<EnemyManager>().Speed * Time.deltaTime);
                }

                if (animator.GetComponent<EnemyManager>().transform.position.x == animator.GetComponent<EnemyManager>().PlayerEnemy.transform.position.x + 1)
                {
                    animator.GetComponent<EnemyManager>().CanMove = false;
                }
                else
                {
                    animator.GetComponent<EnemyManager>().CanMove = true;
                }
                if (animator.GetComponent<EnemyManager>().transform.position.x == animator.GetComponent<EnemyManager>().PlayerEnemy.transform.position.x - 1)
                {
                    animator.GetComponent<EnemyManager>().CanMove = false;
                }
                else
                {
                    animator.GetComponent<EnemyManager>().CanMove = true;
                }
            }
        }

        if (animator.GetComponent<EnemyManager>().CanAttack == true)
        {
            animator.GetComponent<EnemyManager>().random = Random.Range(0, 101);
            animator.GetComponent<EnemyManager>().CanAttack = false;
            Debug.Log("aaarandom"+ animator.GetComponent<EnemyManager>().CanVisible);
            Debug.Log("aaarandom2" + animator.GetComponent<EnemyManager>().isStun);
        
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