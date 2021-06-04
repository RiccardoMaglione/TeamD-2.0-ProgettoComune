using UnityEngine;

public class Smash1State : StateMachineBehaviour
{
    Smash1 smash1;
    CutsceneController cutsceneController;
    GameObject player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss.canDamage = true;
        smash1 = animator.GetComponent<Smash1>();
        cutsceneController = FindObjectOfType<CutsceneController>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        smash1.Smash();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cutsceneController.StartCoroutine(cutsceneController.ShowBossfightImage());
        player.GetComponent<Animator>().enabled = true;
    }
}
