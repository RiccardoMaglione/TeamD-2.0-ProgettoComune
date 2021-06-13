﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class SpecialThiefIdle : StateMachineBehaviour
{
    PSMController psmController;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        psmController = animator.GetComponentInParent<PSMController>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ((Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Joystick1Button1)) && psmController.CurrentEnergy >= psmController.MaxEnergy && animator.GetComponentInParent<PSMController>().enabled == true)
        {
            psmController.CurrentEnergy = 0;
            animator.SetBool("IsAttack", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
}
