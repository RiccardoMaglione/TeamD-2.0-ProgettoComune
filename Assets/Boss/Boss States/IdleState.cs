using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int rand = Random.Range(1, 3);
        if (rand == 1)
            animator.SetTrigger("WaypointAttack1");
        else
            animator.SetTrigger("WaypointAttack2");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
