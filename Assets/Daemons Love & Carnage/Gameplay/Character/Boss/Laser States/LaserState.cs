using UnityEngine;

public class LaserState : StateMachineBehaviour
{
    LaserManager laserManager;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        laserManager = animator.GetComponent<LaserManager>();

        if (laserManager.rand == 1)
            laserManager.laser1.SetActive(true);

        if (laserManager.rand == 2)
            laserManager.laser2.SetActive(true);

        if (laserManager.rand == 3)
            laserManager.laser3.SetActive(true);

        animator.SetTrigger("GoToParticle");

        AudioManager.instance.Play("Sfx_boss_geyser_active");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
            laserManager.laser1.SetActive(false);
            laserManager.laser2.SetActive(false);
            laserManager.laser3.SetActive(false);
    }
}
