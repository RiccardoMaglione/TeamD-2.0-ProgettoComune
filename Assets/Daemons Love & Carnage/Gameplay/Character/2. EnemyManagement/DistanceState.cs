using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class DistanceState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyData>().CanAttack = true;
        if (animator.GetComponent<EnemyData>().PlayerEnemy != null)
        {
            float Distance = Vector2.Distance(animator.gameObject.transform.position, animator.GetComponent<EnemyData>().PlayerEnemy.transform.position);
            if (Distance >= animator.GetComponent<EnemyData>().DistanceFollow + 0.5f)
            {
                animator.SetBool("Distance", true);
            }
            else
            {
                animator.SetBool("Distance", false);
                animator.SetBool("CanAttack", true);
            }
        }
        else
        {
            animator.SetBool("Distance", true);
        }
        //Debug.Log("aaarandom" + animator.GetComponent<EnemyData>().CanAttack);
        //Debug.Log("aaarandom" + animator.GetComponent<EnemyData>().CanVisible);
        //Debug.Log("aaarandom2" + animator.GetComponent<EnemyData>().isStun);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        Debug.Log("Ranged: " + animator.GetComponentInChildren<RangeAttack>().isRanged + "e Melee: " + animator.GetComponentInChildren<RangeAttack>().isMelee);
      //  Debug.Log("aaaAttack" + animator.GetComponent<EnemyData>().CanAttack);
        if (animator.GetComponent<EnemyData>().CanAttack == true && (animator.GetComponentInChildren<RangeAttack>().isMelee == true || animator.GetComponentInChildren<RangeAttack>().isRanged == true))
        {
            animator.GetComponent<EnemyData>().random = Random.Range(0, 101);
            animator.GetComponent<EnemyData>().CanAttack = false;
            //Debug.Log("aaaCiao" + animator.GetComponent<EnemyData>().CanVisible);
            //Debug.Log("aaaCiao2" + animator.GetComponent<EnemyData>().isStun);

        }


        if (animator.GetComponent<EnemyData>().CanVisible == true && animator.GetComponent<EnemyData>().isStun == false && (animator.GetComponentInChildren<RangeAttack>().isMelee == true || animator.GetComponentInChildren<RangeAttack>().isRanged == true))
        {
            //Debug.Log("aaaprova");
            if (animator.GetComponent<EnemyData>().random <= animator.GetComponent<EnemyData>().PercentuageAttack)
            {
                //if (animator.GetComponentInChildren<RangeAttack>().isMelee == true)
                //{
                    Debug.Log("aaaleggero");
                    animator.SetTrigger("LightAttack");
                    animator.SetBool("CanAttack", true);
                //}
            }
            else
            {
                //if (animator.GetComponentInChildren<RangeAttack>().isRanged == true)
                //{
                    Debug.Log("aaaPesante");
                    animator.SetTrigger("HeavyAttack");
                    animator.SetBool("CanAttack", true);
                //}
            }
        }








        if (animator.GetComponent<EnemyData>().PlayerEnemy.transform.position.x + 0.5f > animator.GetComponent<EnemyData>().transform.position.x)
        {
            animator.GetComponent<EnemyData>().transform.rotation = Quaternion.Euler(animator.GetComponent<EnemyData>().transform.rotation.x, 0, animator.GetComponent<EnemyData>().transform.rotation.z);           //Destra
        }
        else if (animator.GetComponent<EnemyData>().PlayerEnemy.transform.position.x - 0.5f < animator.GetComponent<EnemyData>().transform.position.x)
        {
            animator.GetComponent<EnemyData>().transform.rotation = Quaternion.Euler(animator.GetComponent<EnemyData>().transform.rotation.x, -180, animator.GetComponent<EnemyData>().transform.rotation.z);         //Sinistra
        }

        if (animator.GetComponent<EnemyData>().transform.position.x == animator.GetComponent<EnemyData>().PlayerEnemy.transform.position.x + animator.GetComponent<EnemyData>().DistanceFollow)
        {
            animator.GetComponent<EnemyData>().transform.rotation = Quaternion.Euler(animator.GetComponent<EnemyData>().transform.rotation.x, -180, animator.GetComponent<EnemyData>().transform.rotation.z);           //Destra
        }
        if (animator.GetComponent<EnemyData>().transform.position.x == animator.GetComponent<EnemyData>().PlayerEnemy.transform.position.x - animator.GetComponent<EnemyData>().DistanceFollow)
        {
            animator.GetComponent<EnemyData>().transform.rotation = Quaternion.Euler(animator.GetComponent<EnemyData>().transform.rotation.x, 0, animator.GetComponent<EnemyData>().transform.rotation.z);           //Destra
        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
