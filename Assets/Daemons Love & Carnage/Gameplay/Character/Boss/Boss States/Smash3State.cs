using UnityEngine;

public class Smash3State : StateMachineBehaviour
{
    Smash3 smash3;
    SpawnMinionWaypoint spawnMinion;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss.canDamage = true;
        smash3 = animator.GetComponent<Smash3>();
        spawnMinion = animator.GetComponent<SpawnMinionWaypoint>();

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        smash3.Smash();
        spawnMinion.ReturnNormalColor();

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
