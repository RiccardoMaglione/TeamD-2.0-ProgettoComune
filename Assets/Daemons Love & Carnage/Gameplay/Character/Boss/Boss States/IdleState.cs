using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    [SerializeField] private float threshold1;
    [SerializeField] private float threshold2;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss.canDamage = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("GoToPhase2", false);
        animator.SetBool("GoToPhase3", false);
    }
}
