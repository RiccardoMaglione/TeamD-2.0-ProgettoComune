using UnityEngine;

public class ShowParticlesState : StateMachineBehaviour
{
    LaserManager laserManager;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        laserManager = animator.GetComponent<LaserManager>();
        laserManager.DoRandom();
        animator.SetTrigger("GoToLaser");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {       
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("GoToLaser");
    }
}
