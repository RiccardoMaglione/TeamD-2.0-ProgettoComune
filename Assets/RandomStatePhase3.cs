using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStatePhase3 : StateMachineBehaviour
{
    [SerializeField] [Range(1, 100)] float originalMed1 = 33;
    [SerializeField] [Range(1, 100)] float med1 = 33;
    
    [SerializeField] [Range(1, 100)] float originalMed2 = 66;
    [SerializeField] [Range(1, 100)] float med2 = 66;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float rand = Random.Range(1, 100);

        if (rand < med1)
        {
            animator.SetTrigger("Attack1");

            if (med1 > originalMed1)
            {
                med1 = originalMed1;
                med2 = originalMed2;
            }
                
            med1 /= 2;
            med2 = (100 - med1) / 2;
        }


        if (rand >= med1 && rand < med2)
        {
            animator.SetTrigger("Attack2");

            if (med1 < originalMed1 || med2 > originalMed2)
            {
                med1 = originalMed1;
                med2 = originalMed2;
            }            
           
            med1 = ((50 - med1) / 2) + med1;
            med2 = med2 - ((med2 - 50) / 2);
        }


        if (rand >= med2)
        {
            animator.SetTrigger("Attack3");

            if (med2 < originalMed2)
            {
                med1 = originalMed1;
                med2 = originalMed2;
            }
                       
            med1 = med2 / 2;
            med2 = ((100 - med2) / 2) + med2;
        }        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack1");
        animator.ResetTrigger("Attack2");
        animator.ResetTrigger("Attack3");
        animator.ResetTrigger("GoToIdle");

        Boss.canDamage = true;
    }
}
