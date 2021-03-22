using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnState2 : StateMachineBehaviour
{
    SpawnManager spawnManager;
    SpawnMinionWaypoint spawnMinion;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        spawnManager.StartWave2();
        spawnMinion = animator.GetComponent<SpawnMinionWaypoint>();
        spawnMinion.i = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spawnMinion.Move();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
