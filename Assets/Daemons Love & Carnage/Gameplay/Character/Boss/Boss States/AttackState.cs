using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    [SerializeField] float FallSpeed;
    Transform player;
    ArcMovement shake;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shake = animator.GetComponent<ArcMovement>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.gameObject.transform.position.y >= 22.5f)
        {
            animator.gameObject.transform.Translate(Vector3.down * FallSpeed * Time.deltaTime);
        }

        else
        {
            AudioManager.instance.Play("Sfx_boss_stomp");
            shake.cameraShake.ShakeElapsedTime = shake.cameraShake.ShakeDuration;
            animator.SetTrigger("GoToNext");
        }
            
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        animator.ResetTrigger("GoToNext");
    }
}
