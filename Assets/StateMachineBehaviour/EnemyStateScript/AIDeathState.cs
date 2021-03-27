using UnityEngine;

public class AIDeathState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if(FindObjectOfType<ScoreSystem>(true).SpecialType == true)
        //{
        //    FindObjectOfType<ScoreSystem>(true).ScoreAssignedEnemyDestroy((int)animator.GetComponent<EnemyData>().TypeEnemy,3);
        //}
        //else
        //{
        //    FindObjectOfType<ScoreSystem>(true).ScoreAssignedEnemyDestroy((int)animator.GetComponent<EnemyData>().TypeEnemy, 3);
        //}
        animator.GetComponent<EnemyData>().gameObject.SetActive(false);
        FindObjectOfType<KilledEnemyCounter>().killedEnemyCounter++; //27/03/21
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
