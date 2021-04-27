using UnityEngine;

public class WaypointAttack1State : StateMachineBehaviour
{
    WaypointsAttack1 waypointsAttack1;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waypointsAttack1 = animator.GetComponent<WaypointsAttack1>();
        waypointsAttack1.i = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waypointsAttack1.Attack1();
        if (waypointsAttack1.i == waypointsAttack1.waypoints.Length)
            animator.SetTrigger("GoToIdle");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("GoToIdle");
    }
}
