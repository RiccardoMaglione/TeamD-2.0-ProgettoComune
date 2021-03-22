using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    [SerializeField] float FallSpeed;
    Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.gameObject.transform.position.y >= -2)
        {
            animator.gameObject.transform.Translate(Vector3.down * FallSpeed * Time.deltaTime);
        }

        else
            animator.SetTrigger("GoToNext");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("GoToNext");
    }
}
