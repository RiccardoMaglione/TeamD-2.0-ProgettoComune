using UnityEngine;
using DG.Tweening;

public class FollowState : StateMachineBehaviour
{
    Transform player;

    [Tooltip("Più piccolo è il valore più è veloce")]
    [SerializeField] float bossChaseSpeed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.transform.DOMove(new Vector3(player.position.x, player.position.y + 5, 0), bossChaseSpeed);
        
        animator.SetTrigger("GoToNext");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("GoToNext");
    }
}
