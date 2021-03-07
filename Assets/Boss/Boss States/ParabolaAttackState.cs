using DG.Tweening;
using UnityEngine;

public class ParabolaAttackState : StateMachineBehaviour
{
    ArcMovement arcMovement;
    float initialPosition;
    bool isUp = false;
    [SerializeField] float arcSpeed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        arcMovement = animator.GetComponent<ArcMovement>();
        arcMovement.Arc();
        initialPosition = animator.transform.position.y;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.transform.position.y >= arcMovement.height)
        {
            isUp = true;
        }

        if (isUp)
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, new Vector3(animator.transform.position.x,
                                                                                                        initialPosition,
                                                                                                        animator.transform.position.z),
                                                                                                        arcSpeed * Time.deltaTime);

        if (animator.transform.position.y == initialPosition)
        {
            animator.SetTrigger("GoToIdle");
            isUp = false;
        }
            
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
