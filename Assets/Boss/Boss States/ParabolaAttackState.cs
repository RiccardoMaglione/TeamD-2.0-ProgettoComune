using DG.Tweening;
using UnityEngine;

public class ParabolaAttackState : StateMachineBehaviour
{
    ArcMovement arcMovement;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        arcMovement = animator.GetComponent<ArcMovement>();
        arcMovement.Arc();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.transform.position.y == arcMovement.initialPosition + arcMovement.height)
        {
            animator.transform.DOMoveY(arcMovement.initialPosition, 0.5f);
        }

        if(animator.transform.position.y == arcMovement.initialPosition)
            animator.SetTrigger("GoToIdle");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
