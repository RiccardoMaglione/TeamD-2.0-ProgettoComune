using UnityEngine;

public class SpawnState2 : StateMachineBehaviour
{
    SpawnManager spawnManager;
    SpawnMinionWaypoint spawnMinion;
    Boss boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        spawnManager.StartWave2();
        spawnMinion = animator.GetComponent<SpawnMinionWaypoint>();
        spawnMinion.i = 0;
        boss = animator.GetComponent<Boss>();
        boss.canGetDamage = false;

        AudioManager.instance.Stop("Sfx_boss_recovery");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spawnMinion.Move();
        spawnManager.ControlWave();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("GoToSmash", false);
        boss.canGetDamage = true;
    }
}
