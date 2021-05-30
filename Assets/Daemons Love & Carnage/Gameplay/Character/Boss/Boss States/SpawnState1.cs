﻿using UnityEngine;

public class SpawnState1 : StateMachineBehaviour
{
    SpawnManager spawnManager;
    SpawnMinionWaypoint spawnMinion;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        spawnManager.StartWave1();
        spawnMinion = animator.GetComponent<SpawnMinionWaypoint>();
        spawnMinion.i = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spawnMinion.Move();
        spawnManager.ControlWave();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("GoToSmash", false);
    }
}
