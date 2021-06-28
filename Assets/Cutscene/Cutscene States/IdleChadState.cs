using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleChadState : StateMachineBehaviour
{
    [SerializeField] float time;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CutsceneControllerDeathBoss cutsceneControllerDeathBoss = FindObjectOfType<CutsceneControllerDeathBoss>();
        cutsceneControllerDeathBoss.StartCoroutine(cutsceneControllerDeathBoss.TriggerDialogue(time));
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
}
