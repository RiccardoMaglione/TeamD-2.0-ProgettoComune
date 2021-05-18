using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBKAttack : StateMachineBehaviour
{
    BoriousKnightSpecialAttack boriousKnight;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boriousKnight = animator.GetComponent<BoriousKnightSpecialAttack>();
        boriousKnight.StartCoroutine(boriousKnight.Attack());
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {      
        boriousKnight.Move();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
