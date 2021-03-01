using UnityEngine;
using DG.Tweening;

public class PositioningState : StateMachineBehaviour
{
    Transform player;
    float timer = 0;
    [SerializeField] float positioningTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.transform.DOMove(new Vector3(player.position.x, player.position.y + 5, 0), positioningTime);

        if (timer < positioningTime)
        {
            timer += Time.deltaTime;
        }
        
        else
            animator.SetTrigger("GoToNext");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("GoToNext");
    }
}
