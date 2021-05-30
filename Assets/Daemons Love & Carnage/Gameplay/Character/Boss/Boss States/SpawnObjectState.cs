using UnityEngine;

public class SpawnObjectState : StateMachineBehaviour
{
    [SerializeField] GameObject prefab1;
    [SerializeField] GameObject prefab2;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Instantiate(prefab1, new Vector2(animator.gameObject.transform.position.x-2.7f, animator.gameObject.transform.position.y - 1.5f), animator.gameObject.transform.rotation);
        Instantiate(prefab2, new Vector2(animator.gameObject.transform.position.x+2.7f, animator.gameObject.transform.position.y - 1.5f), animator.gameObject.transform.rotation);     
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger("GoToIdle"); 
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
