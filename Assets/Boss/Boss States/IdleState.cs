using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    Boss boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();

        if (boss.life <= 0)
        {
            animator.SetBool("GoToDeath", true);
            animator.SetBool("GoToPhase2", false);
            animator.SetBool("GoToPhase3", false);
            animator.SetBool("Laser", false);
        }
        
        if (boss.life < 30 && boss.life > 0)
        {
            animator.SetBool("GoToPhase2", false);
            animator.SetBool("GoToPhase3", true);
        }


        if (boss.life < 70 && boss.life > 29)
            animator.SetBool("GoToPhase2", true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
