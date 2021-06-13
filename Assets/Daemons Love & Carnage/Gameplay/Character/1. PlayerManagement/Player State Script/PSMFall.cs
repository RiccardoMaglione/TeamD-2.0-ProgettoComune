using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class PSMFall : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PSMController>().OnceJump = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        #region Fall Zone - Compito principale dello script della caduta
        animator.GetComponent<PSMController>().RB2D.velocity += Vector2.up * Physics2D.gravity.y * (animator.GetComponent<PSMController>().ValueJump.fallMultiplier - 1) * Time.deltaTime;  //Cade gradualmente più velocemente
        #endregion

        #region Move - Permette il movimento all'interno del fall - Contiene passaggi tra "Player Fall State" e "Player Move State" o "Player Idle State"
        if ((Input.GetKey(KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyLeft)) || Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("DPad X") < 0) && (DialogueType1.StaticTutorial != -1 && DialogueType1.StaticTutorial2 != 2 && DialogueType1.StaticTutorial != 4 && DialogueType1.StaticTutorial != 6))                                                                                                                                                                                        //Se schiaccio A vado a sinistra
        {
            if (SpecialBKIdle.BoriousMove == true)
            {
                animator.GetComponent<PSMController>().CalculateSpeed();                                                                                                                                                        //Calcolo la velocità
                animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(-animator.GetComponent<PSMController>().ValueMovement.Speed, animator.GetComponent<PSMController>().RB2D.velocity.y);                        //Aumento la velocità
            }
            animator.GetComponent<PSMController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PSMController>().transform.rotation.x, -180, animator.GetComponent<PSMController>().transform.rotation.z);   //Ruoto il player
            //Debug.Log("PlayerState - Vai a sinistra");
            #region - Da "Player Fall State" in "Player Move State" - Permette una transizione più fluida senza passare da "Player Idle State"
            animator.SetBool("PSM-CanMove", true);
            #endregion
        }
        else if ((Input.GetKey(KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyRight)) || Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("DPad X") > 0) && (DialogueType1.StaticTutorial != -1 && DialogueType1.StaticTutorial2 != 2 && DialogueType1.StaticTutorial != 4 && DialogueType1.StaticTutorial != 6))                                                                                                                                                                                   //Se schiaccio D vado a destra
        {
            if (SpecialBKIdle.BoriousMove == true)
            {
                animator.GetComponent<PSMController>().CalculateSpeed();                                                                                                                                                        //Calcolo la velocità
                animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(animator.GetComponent<PSMController>().ValueMovement.Speed, animator.GetComponent<PSMController>().RB2D.velocity.y);                         //Aumento la velocità
            }
            animator.GetComponent<PSMController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PSMController>().transform.rotation.x, 0, animator.GetComponent<PSMController>().transform.rotation.z);      //Ruoto il player
            //Debug.Log("PlayerState - Vai a destra");
            #region - Da "Player Fall State" in "Player Move State" - Permette una transizione più fluida senza passare da "Player Idle State"
            animator.SetBool("PSM-CanMove", true);
            #endregion
        }
        else                                                                                                                                                                                                                //Se non premo A e D
        {
            #region - Da "Player Fall State" in "Player Idle State"
            animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(0, animator.GetComponent<PSMController>().RB2D.velocity.y);                                                                                  //Setto a 0 la velocità sulla x (Orizzontale)            
            animator.SetBool("PSM-CanMove", false);                                                                                                                                                                         //Rende veritiera la condizione per il passaggio tra "Player Fall State" e "Player Idle State"
            #endregion
        }
        #endregion

        #region Dash Zone - Da "Player Fall State" in "Player Dash State"
        if ((Input.GetKey(KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyLeft)) && (Input.GetKey(KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyDash)) || Input.GetKey(KeyCode.LeftShift)) || (Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("DPad X") < 0) && (Input.GetKey(KeyCode.Joystick1Button5))) && animator.GetBool("PSM-CanDash") == false && animator.GetComponent<PSMController>().CooldownDashDirectional == false && animator.GetBool("PSM-CanDashInAir") == false)      //Entra solo 1 volta per CanDashInAir + Controllo delle condizioni per l'esecuzione del dash: Se schiaccio determinati pulsanti - se il parametro booleano PSM-CanDash è uguale a falso, quindi che non è in corso un altro dash - Se il cooldown del dash è falso, quindi non è in corso un precedente dash - Faccio un ulteriore controllo bloccare i dash in aria ad uno
        {
            animator.SetBool("PSM-CanDash", true);                                              //Setto la prima condizione per il dash a vero, mi sposto da "Player Jump State" a "Player Dash State"
            animator.GetComponent<PSMController>().CanDashLeft = true;                          //Setto la direzione del dash a sinistra
        }
        else if ((animator.gameObject.transform.rotation.y == 1 && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift)) || (Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("DPad X") < 0) && (Input.GetKey(KeyCode.Joystick1Button5))) && animator.GetBool("PSM-CanDash") == false && animator.GetComponent<PSMController>().CooldownDashDirectional == false)       //Controllo delle condizioni per l'esecuzione del dash: Se schiaccio determinati pulsanti - se il parametro booleano PSM-CanDash è uguale a falso, quindi che non è in corso un altro dash - Se il cooldown del dash è falso, quindi non è in corso un precedente dash
        {
            animator.SetBool("PSM-CanDash", true);                                      //Setto la prima condizione per il dash a vero, mi sposto da "Player Move State" a "Player Dash State"
            animator.GetComponent<PSMController>().CanDashLeft = true;                  //Setto la direzione del dash a sinistra
        }
        if ((Input.GetKey(KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyRight)) && (Input.GetKey(KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyDash)) || Input.GetKey(KeyCode.LeftShift)) || (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("DPad X") > 0) && (Input.GetKey(KeyCode.Joystick1Button5))) && animator.GetBool("PSM-CanDash") == false && animator.GetComponent<PSMController>().CooldownDashDirectional == false && animator.GetBool("PSM-CanDashInAir") == false)      //Entra solo 1 volta per CanDashInAir + Controllo delle condizioni per l'esecuzione del dash: Se schiaccio determinati pulsanti - se il parametro booleano PSM-CanDash è uguale a falso, quindi che non è in corso un altro dash - Se il cooldown del dash è falso, quindi non è in corso un precedente dash - Faccio un ulteriore controllo bloccare i dash in aria ad uno
        {
            animator.SetBool("PSM-CanDash", true);                                              //Setto la prima condizione per il dash a vero, mi sposto da "Player Fall State" a "Player Dash State"
            animator.GetComponent<PSMController>().CanDashRight = true;                         //Setto la direzione del dash a destra
        }
        else if ((animator.gameObject.transform.rotation.y == 0 && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift)) || (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("DPad X") > 0) && (Input.GetKey(KeyCode.Joystick1Button5))) && animator.GetBool("PSM-CanDash") == false && animator.GetComponent<PSMController>().CooldownDashDirectional == false)       //Controllo delle condizioni per l'esecuzione del dash: Se schiaccio determinati pulsanti - se il parametro booleano PSM-CanDash è uguale a falso, quindi che non è in corso un altro dash - Se il cooldown del dash è falso, quindi non è in corso un precedente dash
        {
            animator.SetBool("PSM-CanDash", true);                                      //Setto la prima condizione per il dash a vero, mi sposto da "Player Move State" a "Player Dash State"
            animator.GetComponent<PSMController>().CanDashRight = true;                 //Setto la direzione del dash a destra
        }



        #endregion
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        switch (animator.GetComponent<PSMController>().TypeCharacter)
        {
            case TypePlayer.FatKnight:
                animator.GetComponentInChildren<FatKnightParticleController>().PlayLanding();
                break;
            case TypePlayer.BoriousKnight:
                animator.GetComponentInChildren<BoriousKnightParticlesController>().PlayLanding();
                break;
            case TypePlayer.Babushka:
                animator.GetComponentInChildren<BabushkaParticleController>().PlayLanding();
                break;
            case TypePlayer.Thief:
                animator.GetComponentInChildren<ThiefParticlesController>().PlayLanding();
                break;
        }
    }
}