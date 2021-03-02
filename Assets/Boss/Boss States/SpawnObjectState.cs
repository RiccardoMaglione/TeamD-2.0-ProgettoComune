using UnityEngine;

public class SpawnObjectState : StateMachineBehaviour
{
    [SerializeField] GameObject prefab1;
    [SerializeField] GameObject prefab2;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Instantiate(prefab1, animator.gameObject.transform.position, animator.gameObject.transform.rotation);
        Instantiate(prefab2, animator.gameObject.transform.position, animator.gameObject.transform.rotation);
        
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger("GoToNext"); 
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("GoToNext");
    }
}
