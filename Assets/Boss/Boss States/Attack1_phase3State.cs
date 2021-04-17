using UnityEngine;

public class Attack1_phase3State : StateMachineBehaviour
{
    Waypoints3Phase waypoints3Phase;
    [SerializeField] int n;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waypoints3Phase = animator.GetComponent<Waypoints3Phase>();
        waypoints3Phase.i = 0;
        waypoints3Phase.ground = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waypoints3Phase.Attack3();

        if (waypoints3Phase.ground == n)
            animator.SetTrigger("GoToIdle");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
