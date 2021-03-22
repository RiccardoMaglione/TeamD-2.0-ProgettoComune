using UnityEngine;

public class FollowState : StateMachineBehaviour
{
    Transform player;

    [SerializeField] float bossChaseSpeed;
    [SerializeField] float chaseTime;
    [SerializeField] float waitTime;
    float time;
    float time2;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        time = 0;
        time2 = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time += Time.deltaTime;
        
        if(time < chaseTime)
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, new Vector2(player.position.x, player.position.y + 8), bossChaseSpeed * Time.deltaTime);
       
        else
        {
            time2 += Time.deltaTime;
            
            if(time2 > waitTime)
                animator.SetTrigger("GoToNext");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("GoToNext");
    }
}
