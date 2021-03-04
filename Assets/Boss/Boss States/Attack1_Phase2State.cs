using DG.Tweening;
using UnityEngine;

public class Attack1_Phase2State : StateMachineBehaviour
{
    ArcMovement arcMovement;
    int i = 0;
    bool isMove;
    float initialPosition;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        arcMovement = animator.GetComponent<ArcMovement>();
        arcMovement.Arc();
        initialPosition = animator.transform.position.y;
        i = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(i < 4 && isMove == false)
        {
            arcMovement.Arc();
            isMove = true;
        }
             
        if (animator.transform.position.y >= arcMovement.height)
        {
            animator.transform.DOMoveY(initialPosition, 0.5f);
        }

        if (animator.transform.position.y == initialPosition && isMove == true)
        {
            i++;
            isMove = false;
        }      
        
        if(i == 4)
            animator.SetTrigger("GoToIdle");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
