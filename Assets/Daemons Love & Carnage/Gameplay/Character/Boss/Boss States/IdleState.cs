using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    Boss boss;
    [SerializeField] private float threshold1;
    [SerializeField] private float threshold2;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();

        Boss.canDamage = false;

        if (boss.life <= 0)
        {
            VictoryScreen.win = true;
            animator.SetBool("GoToDeath", true);
            animator.SetBool("GoToPhase2", false);
            animator.SetBool("GoToPhase3", false);
            animator.SetBool("Laser", false);
        }

        if (boss.life < threshold2 && boss.life > 0)
        {
            animator.SetBool("GoToPhase2", false);
            animator.SetBool("GoToPhase3", true);
        }

        if (boss.life < threshold1 && boss.life > threshold2 - 1)
        {
            animator.SetBool("GoToPhase2", true);
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("GoToPhase2", false);
        animator.SetBool("GoToPhase3", false);
    }
}
