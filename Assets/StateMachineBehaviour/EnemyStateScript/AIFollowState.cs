using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class AIFollowState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyData>().GetComponent<SpriteRenderer>().color = Color.white;       //MVC: View
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("IsFollowing") == true && animator.GetComponent<EnemyData>().isStun == false/* && CanMoveAttack == true*/)
        {
            if (animator.GetComponent<EnemyData>().PlayerEnemy != null)
            {
                if (animator.GetComponent<EnemyData>().PlayerEnemy.transform.position.x + 1f > animator.GetComponent<EnemyData>().transform.position.x)
                {
                    animator.GetComponent<EnemyData>().transform.position = Vector2.MoveTowards(animator.GetComponent<EnemyData>().transform.position, new Vector2(animator.GetComponent<EnemyData>().PlayerEnemy.transform.position.x - 1, animator.GetComponent<EnemyData>().transform.position.y), animator.GetComponent<EnemyData>().Speed * Time.deltaTime);
                }
                if (animator.GetComponent<EnemyData>().PlayerEnemy.transform.position.x > animator.GetComponent<EnemyData>().transform.position.x)
                {
                    animator.GetComponent<EnemyData>().transform.rotation = Quaternion.Euler(animator.GetComponent<EnemyData>().transform.rotation.x, 0, animator.GetComponent<EnemyData>().transform.rotation.z);           //Destra
                }
                if (animator.GetComponent<EnemyData>().PlayerEnemy.transform.position.x - 1f < animator.GetComponent<EnemyData>().transform.position.x)
                {
                    animator.GetComponent<EnemyData>().transform.position = Vector2.MoveTowards(animator.GetComponent<EnemyData>().transform.position, new Vector2(animator.GetComponent<EnemyData>().PlayerEnemy.transform.position.x + 1, animator.GetComponent<EnemyData>().transform.position.y), animator.GetComponent<EnemyData>().Speed * Time.deltaTime);
                }
                if (animator.GetComponent<EnemyData>().PlayerEnemy.transform.position.x < animator.GetComponent<EnemyData>().transform.position.x)
                {
                    animator.GetComponent<EnemyData>().transform.rotation = Quaternion.Euler(animator.GetComponent<EnemyData>().transform.rotation.x, -180, animator.GetComponent<EnemyData>().transform.rotation.z);         //Sinistra
                }

                if (animator.GetComponent<EnemyData>().transform.position.x == animator.GetComponent<EnemyData>().PlayerEnemy.transform.position.x + 1f)
                {
                    animator.GetComponent<EnemyData>().transform.rotation = Quaternion.Euler(animator.GetComponent<EnemyData>().transform.rotation.x, -180, animator.GetComponent<EnemyData>().transform.rotation.z);           //Destra
                    animator.GetComponent<EnemyData>().CanMove = false;
                }
                else
                {
                    animator.GetComponent<EnemyData>().CanMove = true;
                }
                if (animator.GetComponent<EnemyData>().transform.position.x == animator.GetComponent<EnemyData>().PlayerEnemy.transform.position.x - 1f)
                {
                    animator.GetComponent<EnemyData>().transform.rotation = Quaternion.Euler(animator.GetComponent<EnemyData>().transform.rotation.x, 0, animator.GetComponent<EnemyData>().transform.rotation.z);           //Destra
                    animator.GetComponent<EnemyData>().CanMove = false;
                }
                else
                {
                    animator.GetComponent<EnemyData>().CanMove = true;
                }
            }
        }

        if (animator.GetComponent<EnemyData>().CanAttack == true)
        {
            animator.GetComponent<EnemyData>().random = Random.Range(0, 101);
            animator.GetComponent<EnemyData>().CanAttack = false;
            Debug.Log("aaarandom"+ animator.GetComponent<EnemyData>().CanVisible);
            Debug.Log("aaarandom2" + animator.GetComponent<EnemyData>().isStun);
        
        }
        if (animator.GetComponent<EnemyData>().CanVisible == true && animator.GetComponent<EnemyData>().isStun == false)
        {
            Debug.Log("aaaprova");
            if (animator.GetComponent<EnemyData>().random <= animator.GetComponent<EnemyData>().PercentuageAttack)
            {
                if (animator.GetComponentInChildren<RangeAttack>().isMelee == true)
                {
                    Debug.Log("aaaleggero");
                    animator.SetTrigger("LightAttack");
                    animator.SetBool("CanAttack", true);
                }
            }
            else
            {
                if (animator.GetComponentInChildren<RangeAttack>().isRanged == true)
                {
                    Debug.Log("aaaPesante");
                    animator.SetTrigger("HeavyAttack");
                    animator.SetBool("CanAttack", true);
                }
            }
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