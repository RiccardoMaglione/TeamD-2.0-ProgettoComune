using UnityEngine;

public class SpawnState1 : StateMachineBehaviour
{
    SpawnManager spawnManager;
    SpawnMinionWaypoint spawnMinion;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        spawnManager.StartWave1();
        spawnMinion = animator.GetComponent<SpawnMinionWaypoint>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spawnMinion.Move();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
