using UnityEngine;

public class InstantiateStomps : StateMachineBehaviour
{
    FatKnightSpecialAttack specialAttack;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        specialAttack = animator.GetComponent<FatKnightSpecialAttack>();
        if (specialAttack.i < specialAttack.enemyList.Count)
        {
            specialAttack.InstantiateStomps();
            animator.SetTrigger("Move");
        }

        else
        {
            animator.SetTrigger("Stop");
            specialAttack.enemyList.Clear();
            specialAttack.i = 0;
        }

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
}
