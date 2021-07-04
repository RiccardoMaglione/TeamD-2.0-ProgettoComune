using UnityEngine;
using SwordGame;

public class FatKnightStartAttack : StateMachineBehaviour
{
    PSMController psmController;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        psmController = animator.GetComponentInParent<PSMController>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ((Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Joystick1Button1)) && psmController.CurrentEnergy >= psmController.MaxEnergy && animator.GetComponentInParent<PSMController>().enabled == true && animator.GetComponentInParent<PSMController>().IsSpecialAttack == true)
        {
            animator.SetTrigger("Start");
            psmController.GetComponent<Animator>().SetBool("PSM-SpecialAttack", false);
        }        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

}
