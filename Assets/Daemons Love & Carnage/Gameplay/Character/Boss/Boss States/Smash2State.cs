using UnityEngine;

public class Smash2State : StateMachineBehaviour
{
    Smash2 smash2;
    SpawnMinionWaypoint spawnMinion;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss.canDamage = true;
        smash2 = animator.GetComponent<Smash2>();
        spawnMinion = animator.GetComponent<SpawnMinionWaypoint>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        smash2.Smash();
        spawnMinion.ReturnNormalColor();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
