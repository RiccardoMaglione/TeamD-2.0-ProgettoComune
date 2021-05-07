using UnityEngine;

public class InstantiateStomps : StateMachineBehaviour
{
    SpecialAttack specialAttack;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        specialAttack = animator.GetComponent<SpecialAttack>();
        if (specialAttack.i < specialAttack.obj.Length)
        {
            specialAttack.InstantiateStomps();
            animator.SetTrigger("Move");
        }

        else
        {
            animator.SetTrigger("Stop");
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
