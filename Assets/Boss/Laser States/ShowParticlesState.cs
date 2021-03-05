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
        
        laserManager.particle1.SetActive(false);
        laserManager.particle2.SetActive(false);
        laserManager.particle3.SetActive(false);
    }
}
