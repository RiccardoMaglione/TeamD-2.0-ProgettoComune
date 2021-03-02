using DG.Tweening;
using UnityEngine;

public class FollowState : StateMachineBehaviour
{
    Transform player;

    [Tooltip("Più piccolo è il valore più è veloce")]
    [SerializeField] float bossChaseSpeed;
    [SerializeField] float dropTime = 1f;
    float time;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.transform.DOMove(new Vector3(player.position.x, player.position.y + 5, 0), bossChaseSpeed);
        if (time >= dropTime)
        {
            animator.SetTrigger("GoToNext");
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("GoToNext");
    }
}
