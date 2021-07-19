using UnityEngine;

public class Crossbow_Shoot_State : StateMachineBehaviour
{

    CrossbowTrap crossbowTrap;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (AudioManager.instance != null)
            AudioManager.instance.Play("Sfx_ballista_shots");


        crossbowTrap = animator.GetComponentInParent<CrossbowTrap>();
        animator.SetBool("Shooting", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (crossbowTrap.playerInRange && crossbowTrap.aiming == false)
            crossbowTrap.StartCoroutine("Shoot");

    }

}
