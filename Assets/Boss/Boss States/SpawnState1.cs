using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnState1 : StateMachineBehaviour
{
    SpawnManager spawnManager;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        spawnManager.StartWave1();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
