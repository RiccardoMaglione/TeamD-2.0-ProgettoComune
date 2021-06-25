using UnityEngine;

public class AIStunState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<EnemyData>().timerStun == 0 && animator.name != "PlayerFatKnight")
        {
            FindObjectOfType<KilledEnemyCounter>().killedEnemyCounter++; //1/06/21
        }

        animator.GetComponentInChildren<EnemyParticleController>().PlayStun();

        animator.SetBool("AI-IsStun", true);
        //animator.GetComponent<EnemyData>().GetComponent<SpriteRenderer>().color = Color.red;       //MVC: View
        animator.GetComponent<EnemyData>().isStun = true;
        animator.GetComponent<EnemyData>().CountHit = 0;
        animator.GetComponent<EnemyData>().LightAttackCollider.SetActive(false);
        animator.GetComponent<EnemyData>().HeavyAttackCollider.SetActive(false);//1/06/21

        animator.GetComponentInChildren<EnemyParticleController>().PlayStun();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.GetComponent<EnemyData>().GetComponent<SpriteRenderer>().color = Color.red;
        if (animator.GetComponent<EnemyData>().isStun == true && animator.GetComponent<EnemyData>().isPossessed == false)
        {
            animator.GetComponent<EnemyData>().timerStun += Time.deltaTime;
            if (animator.GetComponent<EnemyData>().CountHit >= animator.GetComponent<EnemyData>().MaxCountHit)
            {
                animator.SetTrigger("IsDeath");
            }
            if (animator.GetComponent<EnemyData>().timerStun >= animator.GetComponent<EnemyData>().DurationStun)
            {
                animator.SetTrigger("IsDeath");
            }
        }
        animator.GetComponent<EnemyData>().GetComponent<Rigidbody2D>().velocity = new Vector2(0, animator.GetComponent<EnemyData>().GetComponent<Rigidbody2D>().velocity.y);
        animator.GetComponent<EnemyData>().AreaPossession.SetActive(true);
        //animator.GetComponent<EnemyData>().AreaPossession.GetComponent<CircleCollider2D>().radius = animator.GetComponent<TriggerPossession>().RadiusArea;
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
