using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class PSMMove : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        switch (animator.GetComponent<PSMController>().TypeCharacter)
        {
            case TypePlayer.FatKnight:
                animator.GetComponentInChildren<FatKnightParticleController>().PlayRun();
                break;
            case TypePlayer.BoriousKnight:
                animator.GetComponentInChildren<BoriousKnightParticlesController>().PlayRun();
                break;
            case TypePlayer.Babushka:
                animator.GetComponentInChildren<BabushkaParticleController>().PlayRun();
                break;
            case TypePlayer.Thief:
                animator.GetComponentInChildren<ThiefParticlesController>().PlayRun();
                break;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {  
        #region Move Zone - Compito principale dello script di movimento
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("DPad X") < 0) && (DialogueType1.StaticTutorial != -1 && DialogueType1.StaticTutorial2 != 2 && DialogueType1.StaticTutorial != 4 && DialogueType1.StaticTutorial != 6))                                                                                                                                                                                        //Se schiaccio A vado a sinistra
        {
            animator.GetComponent<PSMController>().CalculateSpeed();                                                                                                                                                        //Calcolo la velocità
            animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(-animator.GetComponent<PSMController>().ValueMovement.Speed, animator.GetComponent<PSMController>().RB2D.velocity.y);                        //Aumento la velocità
            animator.GetComponent<PSMController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PSMController>().transform.rotation.x, -180, animator.GetComponent<PSMController>().transform.rotation.z);   //Ruoto il player
            //Debug.Log("PlayerState - Vai a sinistra");
        }
        else if ((Input.GetKey(KeyCode.RightArrow)|| Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("DPad X") > 0) && (DialogueType1.StaticTutorial != -1 && DialogueType1.StaticTutorial2 != 2 && DialogueType1.StaticTutorial != 4 && DialogueType1.StaticTutorial != 6))                                                                                                                                                                                   //Se schiaccio D vado a destra
        {
            animator.GetComponent<PSMController>().CalculateSpeed();                                                                                                                                                        //Calcolo la velocità
            animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(animator.GetComponent<PSMController>().ValueMovement.Speed, animator.GetComponent<PSMController>().RB2D.velocity.y);                         //Aumento la velocità
            animator.GetComponent<PSMController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PSMController>().transform.rotation.x, 0, animator.GetComponent<PSMController>().transform.rotation.z);      //Ruoto il player
            //Debug.Log("PlayerState - Vai a destra");
        }
        else                                                                                                                                                                                                                //Se non premo A e D
        {
            #region - Da "Player Idle State" da "Player Fall State"
            animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(0, animator.GetComponent<PSMController>().RB2D.velocity.y);                                                                                  //Setto a 0 la velocità sulla x (Orizzontale)
            animator.SetBool("PSM-CanMove", false);                                                                                                                                                                    //Ritorno in "Player Idle State" da "Player Move State"
            #endregion
        }
        #endregion

        #region Jump Zone - Da "Player Move State" da "Player Jump State"
        if ((Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.Joystick1Button0)) && DialogueType1.StaticTutorial != 1 && DialogueType1.StaticTutorial2 != 2 && DialogueType1.StaticTutorial != 4 && DialogueType1.StaticTutorial != 6)                                                                                                                                //Se schiaccio spazio
        {
            //Debug.Log("PlayerState - Vai nello stato 'PSMJump'");                                                                                                           //Debuggo in console cosa fa
            animator.SetTrigger("PSM-CanJump");                                                                                                                             //Setto attivo il trigger - Prima condizione per il cambio stato in "Player Jump State"
            if (animator.GetBool("PSM-IsGrounded") == true && animator.GetComponent<PSMController>().OnceJump == false)                                                     //Se tocca terra ed è il primo ciclo (OnceJump non dovrebbe servire ma è stato messo per sicurezza)
            {
                //animator.GetComponent<PSMController>().InitialPos = animator.transform.position;
                animator.GetComponent<PSMController>().OnceJump = true;                                                                                                     //Controllo di sicurezza per eseguirlo solo una volta
                animator.GetComponent<PSMController>().RB2D.AddForce(Vector2.up * animator.GetComponent<PSMController>().ValueJump.InitialJumpForce, ForceMode2D.Impulse);  //Spinta iniziale per evitare un salto non visibili
            }
        }
        #endregion

        #region Fall Zone - Da "Player Move State" da "Player Fall State"
        if (animator.GetComponent<PSMController>().RB2D.velocity.y < 0)                                         //Se la velocità di y è minore di 0 - Non minore e uguale perché lo stato di move sta sempre uguale a 0
        {
            //Debug.Log("PlayerState - Vai in 'Player Fall State'");                                              //Debuggo in console cosa fa
            animator.SetBool("PSM-IsGrounded", false);                                                          //Setto la prima condizione del tocco del terreno a falso, per entrare in "Player Fall State" da "Player Move State"
            animator.SetTrigger("PSM-IsInFall");                                                                //Setto la seconda condizione, un trigger, attivo, per entrare in "Player Fall State" da "Player Move State"
        }
        #endregion

        #region Dash Zone - Da "Player Move State" da "Player Dash State"
        if ((Input.GetKey(KeyCode.LeftArrow) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift)) || (Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("DPad X") < 0) && (Input.GetKey(KeyCode.Joystick1Button5))) && animator.GetBool("PSM-CanDash") == false && animator.GetComponent<PSMController>().CooldownDashDirectional == false)       //Controllo delle condizioni per l'esecuzione del dash: Se schiaccio determinati pulsanti - se il parametro booleano PSM-CanDash è uguale a falso, quindi che non è in corso un altro dash - Se il cooldown del dash è falso, quindi non è in corso un precedente dash
        {
            animator.SetBool("PSM-CanDash", true);                                      //Setto la prima condizione per il dash a vero, mi sposto da "Player Move State" a "Player Dash State"
            animator.GetComponent<PSMController>().CanDashLeft = true;                  //Setto la direzione del dash a sinistra
        }
        if ((Input.GetKey(KeyCode.RightArrow) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift)) || (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("DPad X") > 0) && (Input.GetKey(KeyCode.Joystick1Button5))) && animator.GetBool("PSM-CanDash") == false && animator.GetComponent<PSMController>().CooldownDashDirectional == false)       //Controllo delle condizioni per l'esecuzione del dash: Se schiaccio determinati pulsanti - se il parametro booleano PSM-CanDash è uguale a falso, quindi che non è in corso un altro dash - Se il cooldown del dash è falso, quindi non è in corso un precedente dash
        {
            animator.SetBool("PSM-CanDash", true);                                      //Setto la prima condizione per il dash a vero, mi sposto da "Player Move State" a "Player Dash State"
            animator.GetComponent<PSMController>().CanDashRight = true;                 //Setto la direzione del dash a destra
        }
        #endregion
    }

    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}


//Posso entrare in quest o stato solo se sto toccando il terreno, quindi possibile if che ricopre la parte sopra