using UnityEngine;

public class WaypointAttack2State : StateMachineBehaviour
{
    WaypointsAttack2 waypointsAttack2;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waypointsAttack2 = animator.GetComponent<WaypointsAttack2>();
        waypointsAttack2.i = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waypointsAttack2.Attack2();
        if (waypointsAttack2.i == waypointsAttack2.waypoints.Length)
            animator.SetTrigger("GoToIdle");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("GoToIdle");
    }
}
