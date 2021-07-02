using UnityEngine;

public class SpawnState1 : StateMachineBehaviour
{
    SpawnManager spawnManager;
    SpawnMinionWaypoint spawnMinion;
    Boss boss;
    GameObject bossHPBar;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossHPBar = GameObject.Find("Boss Life Slider");
        bossHPBar.SetActive(false);
        spawnManager = FindObjectOfType<SpawnManager>();
        spawnManager.StartWave1();
        spawnMinion = animator.GetComponent<SpawnMinionWaypoint>();
        spawnMinion.i = 0;
        boss = animator.GetComponent<Boss>();
        boss.canGetDamage = false;

        AudioManager.instance.Stop("Sfx_boss_recovery");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spawnMinion.Move();
        spawnMinion.ChangeColor();
        spawnManager.ControlWave();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("GoToSmash", false);
        boss.canGetDamage = true;
        bossHPBar.SetActive(true);

    }
}
