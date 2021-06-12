using UnityEngine;

public class Smash3State : StateMachineBehaviour
{
    Smash3 smash3;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss.canDamage = true;
        smash3 = animator.GetComponent<Smash3>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        smash3.Smash();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
