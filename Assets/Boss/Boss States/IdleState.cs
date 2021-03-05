using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    Boss boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();

        if (boss.life < 70 && boss.life > 29)
            animator.SetBool("GoToPhase2", true);
        
        if (boss.life < 30)
        {
            animator.SetBool("GoToPhase2", false);
            animator.SetBool("GoToPhase3", true);
        }
  

        int rand = Random.Range(1, 3);
        
        if (rand == 1)
            animator.SetTrigger("Attack1");
        else
            animator.SetTrigger("Attack2");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
