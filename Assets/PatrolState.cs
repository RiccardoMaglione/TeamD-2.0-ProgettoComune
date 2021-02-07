using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<EnemyManager>().WaypointIndex <= animator.GetComponent<EnemyManager>().WaypointEnemy.Length - 1 && animator.GetBool("IsFollowing") == false && animator.GetComponent<EnemyManager>().CanMove == true && animator.GetComponent<EnemyManager>().isStun == false/* && CanMoveAttack == true*/)
        {
            animator.GetComponent<EnemyManager>().transform.position = Vector2.MoveTowards(animator.GetComponent<EnemyManager>().transform.position, new Vector2(animator.GetComponent<EnemyManager>().WaypointEnemy[animator.GetComponent<EnemyManager>().WaypointIndex].transform.position.x, animator.GetComponent<EnemyManager>().transform.position.y), animator.GetComponent<EnemyManager>().Speed * Time.deltaTime);
            if (animator.GetComponent<EnemyManager>().WaypointEnemy[animator.GetComponent<EnemyManager>().WaypointIndex].transform.position.x > animator.GetComponent<EnemyManager>().transform.position.x)
            {
                animator.GetComponent<EnemyManager>().transform.rotation = Quaternion.Euler(animator.GetComponent<EnemyManager>().transform.rotation.x, 0, animator.GetComponent<EnemyManager>().transform.rotation.z);           //Destra
            }
            else
            {
                animator.GetComponent<EnemyManager>().transform.rotation = Quaternion.Euler(animator.GetComponent<EnemyManager>().transform.rotation.x, -180, animator.GetComponent<EnemyManager>().transform.rotation.z);         //Sinistra
            }
            if (animator.GetComponent<EnemyManager>().transform.position.x == animator.GetComponent<EnemyManager>().WaypointEnemy[animator.GetComponent<EnemyManager>().WaypointIndex].transform.position.x)
            {
                animator.GetComponent<EnemyManager>().WaypointIndex += 1;
                if (animator.GetComponent<EnemyManager>().WaypointIndex == animator.GetComponent<EnemyManager>().WaypointEnemy.Length)
                {
                    animator.GetComponent<EnemyManager>().WaypointIndex = 0;
                }
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
