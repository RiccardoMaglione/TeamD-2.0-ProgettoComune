﻿using DG.Tweening;
using UnityEngine;

public class ParabolaAttackState : StateMachineBehaviour
{
    ArcMovement arcMovement;
    float initialPosition;

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
            animator.transform.DOMoveY(initialPosition, 0.5f);
        }

        if (animator.transform.position.y == initialPosition)
            animator.SetTrigger("GoToIdle");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
