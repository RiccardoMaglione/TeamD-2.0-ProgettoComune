using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<EnemyData>().WaypointIndex <= animator.GetComponent<EnemyData>().WaypointEnemy.Length - 1 && animator.GetBool("IsFollowing") == false && animator.GetComponent<EnemyData>().CanMove == true && animator.GetComponent<EnemyData>().isStun == false/* && CanMoveAttack == true*/)
        {
            animator.GetComponent<EnemyData>().transform.position = Vector2.MoveTowards(animator.GetComponent<EnemyData>().transform.position, new Vector2(animator.GetComponent<EnemyData>().WaypointEnemy[animator.GetComponent<EnemyData>().WaypointIndex].transform.position.x, animator.GetComponent<EnemyData>().transform.position.y), animator.GetComponent<EnemyData>().Speed * Time.deltaTime);
            if (animator.GetComponent<EnemyData>().WaypointEnemy[animator.GetComponent<EnemyData>().WaypointIndex].transform.position.x > animator.GetComponent<EnemyData>().transform.position.x)
            {
                animator.GetComponent<EnemyData>().transform.rotation = Quaternion.Euler(animator.GetComponent<EnemyData>().transform.rotation.x, 0, animator.GetComponent<EnemyData>().transform.rotation.z);           //Destra
            }
            else
            {
                animator.GetComponent<EnemyData>().transform.rotation = Quaternion.Euler(animator.GetComponent<EnemyData>().transform.rotation.x, -180, animator.GetComponent<EnemyData>().transform.rotation.z);         //Sinistra
            }
            if (animator.GetComponent<EnemyData>().transform.position.x == animator.GetComponent<EnemyData>().WaypointEnemy[animator.GetComponent<EnemyData>().WaypointIndex].transform.position.x)
            {
                animator.GetComponent<EnemyData>().WaypointIndex += 1;
                if (animator.GetComponent<EnemyData>().WaypointIndex == animator.GetComponent<EnemyData>().WaypointEnemy.Length)
                {
                    animator.GetComponent<EnemyData>().WaypointIndex = 0;
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
