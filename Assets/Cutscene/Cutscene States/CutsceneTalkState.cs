using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTalkState : StateMachineBehaviour
{
    CutsceneController cutsceneController;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cutsceneController = animator.GetComponent<CutsceneController>();
        cutsceneController.TriggerDialogue();
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
