using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class PSMJump : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerParticlesController.instance.PlayJump();
        Debug.Log("PlayerState - Grounded'" + animator.GetBool("PSM-IsGrounded"));                      //Debuggo lo stato di grounded per verificare se toccava o non toccava terra (Default: true)
        animator.GetComponent<PSMController>().JumpFollow = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        #region Jump - Compito principale dello script di movimento
        if (Input.GetKey(KeyCode.Space) && animator.GetBool("PSM-IsGrounded") == true)                                                                                                                  //Se Schiaccio spazio (è un getkey e non un getkeydown perché altrimenti non avrebbe preso l'input) e verifico grounded
        {
            //animator.GetComponent<PSMController>().RB2D.AddForce(Vector2.up * animator.GetComponent<PSMController>().ValueJump.jumpForce, ForceMode2D.Impulse);                                         //Applico una forza di tipo impulso con un direzione precisa (UP) e moltiplico per una determinata forza
            animator.SetBool("PSM-IsGrounded", false);                                                                                                                                                  //Setto grounded a falso per due motivi - 1. Il player non tocca più il terreno - 2. Blocco l'entrata al'if precedente per evitare salti infiniti/multipli
            Debug.Log("PlayerState - Secondo passaggio del salto'");                                                                                                                                    //Debuggo in console cosa fa - Secondo passaggio per verificare quante volte ci entra
        }
        else if (animator.GetComponent<PSMController>().RB2D.velocity.y > 1 && !Input.GetButton("Jump"))                                                                                                //Altrimenti se la velocità è maggiore di 1 e non sto più schiacciando il pulsante spazio - Da un minimo di velocà di salto minimo - Permette di fare salti graduali
        {
            animator.GetComponent<PSMController>().RB2D.velocity += Vector2.up * Physics2D.gravity.y * (animator.GetComponent<PSMController>().ValueJump.lowJumpMultiplier - 1) * Time.deltaTime;       //Calcola la velocità definendo una direzione iniziale (UP) e moltiplicando per una gravitò maggiorata minore è il tempo di pressione del tasto
        }
        else if (animator.GetComponent<PSMController>().RB2D.velocity.y < 4 && animator.GetComponent<PSMController>().RB2D.velocity.y > 0)                                                              //Altrimenti se la velocità è compresa tra due valori - Evita la fluttuazione del salto tagliandolo prima
        {
            animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(animator.GetComponent<PSMController>().RB2D.velocity.x, 0);                                                              //Setto la velocità di y uguale a 0, in modo tale che da qui in poi, posso solo scendere, quindi andare in "Player Fall State"
        }
        #endregion

        #region Fall Zone - Da "Player Jump State" da "Player Fall State"
        if (animator.GetComponent<PSMController>().RB2D.velocity.y <= 0)                //Se la velocità di y è minore o uguale a 0 - Minore e uguale perché potrebbe capitare un salto che potrebbe buggare senza l'uguaglianza
        {
            /*Test*/animator.SetBool("PSM-IsGrounded", false);                                  
            Debug.Log("PlayerState - Vai in 'Player Fall State'");                      //Debuggo in console cosa fa
            animator.SetTrigger("PSM-IsInFall");                                        //Setto la prima condizione, un trigger, attivo, per entrare in "Player Fall State" da "Player Jump State"
        }
        #endregion

        #region Move Zone - Permette il movimento direzionale del salto
        if (Input.GetKey(KeyCode.A))                                                                                                                                                                                        //Se schiaccio A vado a sinistra
        {
            animator.GetComponent<PSMController>().CalculateSpeed();                                                                                                                                                        //Calcolo la velocità
            animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(-animator.GetComponent<PSMController>().ValueMovement.Speed, animator.GetComponent<PSMController>().RB2D.velocity.y);                        //Aumento la velocità
            animator.GetComponent<PSMController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PSMController>().transform.rotation.x, -180, animator.GetComponent<PSMController>().transform.rotation.z);   //Ruoto il player
            Debug.Log("PlayerState - Vai a sinistra");
        }
        else if (Input.GetKey(KeyCode.D))                                                                                                                                                                                   //Se schiaccio D vado a destra
        {
            animator.GetComponent<PSMController>().CalculateSpeed();                                                                                                                                                        //Calcolo la velocità
            animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(animator.GetComponent<PSMController>().ValueMovement.Speed, animator.GetComponent<PSMController>().RB2D.velocity.y);                         //Aumento la velocità
            animator.GetComponent<PSMController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PSMController>().transform.rotation.x, 0, animator.GetComponent<PSMController>().transform.rotation.z);      //Ruoto il player
            Debug.Log("PlayerState - Vai a destra");
        }
        else                                                                                                                                                                                                                //Se non premo A e D
        {
            animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(0, animator.GetComponent<PSMController>().RB2D.velocity.y);                                                                                  //Setto a 0 la velocità sulla x (Orizzontale)                                                                                                                                                                              //Ritorno in idle
        }
        #endregion

        #region Dash Zone - Da "Player Jump State" da "Player Fall State"
        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift)) && animator.GetBool("PSM-CanDash") == false && animator.GetComponent<PSMController>().CooldownDashDirectional == false && animator.GetBool("PSM-CanDashInAir") == false)      //Controllo delle condizioni per l'esecuzione del dash: Se schiaccio determinati pulsanti - se il parametro booleano PSM-CanDash è uguale a falso, quindi che non è in corso un altro dash - Se il cooldown del dash è falso, quindi non è in corso un precedente dash - Faccio un ulteriore controllo bloccare i dash in aria ad uno
        {
            animator.SetBool("PSM-CanDash", true);                                                  //Setto la prima condizione per il dash a vero, mi sposto da "Player Jump State" a "Player Dash State"
            animator.GetComponent<PSMController>().CanDashLeft = true;                              //Setto la direzione del dash a sinistra
        }
        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift)) && animator.GetBool("PSM-CanDash") == false && animator.GetComponent<PSMController>().CooldownDashDirectional == false && animator.GetBool("PSM-CanDashInAir") == false)      //Controllo delle condizioni per l'esecuzione del dash: Se schiaccio determinati pulsanti - se il parametro booleano PSM-CanDash è uguale a falso, quindi che non è in corso un altro dash - Se il cooldown del dash è falso, quindi non è in corso un precedente dash - Faccio un ulteriore controllo bloccare i dash in aria ad uno
        {
            animator.SetBool("PSM-CanDash", true);                                                  //Setto la prima condizione per il dash a vero, mi sposto da "Player Jump State" a "Player Dash State"
            animator.GetComponent<PSMController>().CanDashRight = true;                             //Setto la direzione del dash a destra
        }
        #endregion


        //Blocca il salto e lo butta giù - Possibile soluzione per il salto alto
        //Referenza riga 77 nello script PSMController
        //Referenza riga 48 nello script PSMMove
        //Referenza riga 34nello script PSMIdle
        /*if (animator.transform.position.y >= animator.GetComponent<PSMController>().InitialPos.y + 3)
        {
            //Blocca il salto e lo butta giù
            animator.SetBool("PSM-IsGrounded", false);
            animator.SetTrigger("PSM-IsInFall");
            //animator.Play("Player Fall State");       //In caso le condizioni di prima non bastino
        }*/
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PSMController>().JumpFollow = false;
    }

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
