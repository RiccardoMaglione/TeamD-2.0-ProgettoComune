using UnityEngine;

public class RandomAttackState : StateMachineBehaviour
{
    [SerializeField] [Range(1, 100)] float originalMed = 50;
    [SerializeField] [Range(1, 100)] float med = 50;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float rand = Random.Range(1, 100);

        if(rand < med)
        {
            animator.SetTrigger("Attack1");
            
            if(med > originalMed)
                med = originalMed;              
            
            med /= 2;
        }

        else
        {
            animator.SetTrigger("Attack2");
            
            if (med < originalMed)
                med = originalMed;
                           
            med = ((100 - med) / 2) + med;
        }       
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack1");
        animator.ResetTrigger("Attack2");
        animator.ResetTrigger("GoToIdle");
        
        Boss.canDamage = true;
    }
}
