using SwordGame;
using UnityEngine;

public class PSMAttack : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("PSM-Attack", false);
        //animator.GetComponent<PSMController>().RB2D.velocity = Vector2.zero;
        animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(0, animator.GetComponent<PSMController>().RB2D.velocity.y);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.gameObject.GetComponent<PSMController>().TypeCharacter == TypePlayer.BoriousKnight)
        {
            if (animator.gameObject.GetComponentInChildren<BoriousKnightSpecialAttack>().gameObject != null && animator.GetComponentInChildren<BoriousKnightSpecialAttack>().SpecialActivated == false)//.SpecialActivated == false)  //23/05
            {
                animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(0, animator.GetComponent<PSMController>().RB2D.velocity.y);
            }
        }
        //animator.GetComponent<PSMController>().RB2D.velocity = Vector2.zero;

        if ((Input.GetKey(KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyLeft)) || Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("DPad X") < 0) && (DialogueType1.StaticTutorial != -1 && DialogueType1.StaticTutorial2 != 2 && DialogueType1.StaticTutorial != 4 && DialogueType1.StaticTutorial != 6))                                                                                                                                                                                        //Se schiaccio A vado a sinistra
        {
            animator.GetComponent<PSMController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PSMController>().transform.rotation.x, -180, animator.GetComponent<PSMController>().transform.rotation.z);   //Ruoto il player
        }
        else if ((Input.GetKey(KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyRight)) || Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("DPad X") > 0) && (DialogueType1.StaticTutorial != -1 && DialogueType1.StaticTutorial2 != 2 && DialogueType1.StaticTutorial != 4 && DialogueType1.StaticTutorial != 6))                                                                                                                                                                                   //Se schiaccio D vado a destra
        {
            animator.GetComponent<PSMController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PSMController>().transform.rotation.x, 0, animator.GetComponent<PSMController>().transform.rotation.z);      //Ruoto il player
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player Special Attack State"))
        {
            #region Jump
            if ((Input.GetKeyDown(KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyUp)) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && DialogueType1.StaticTutorial != 1 && DialogueType1.StaticTutorial2 != 2 && DialogueType1.StaticTutorial != 4 && DialogueType1.StaticTutorial != 6)     //Se schiaccio spazio una volta
            {
                if (animator.GetBool("PSM-IsGrounded") == true && animator.GetComponent<PSMController>().OnceJump == false)                     //Se tocca terra ed è il primo ciclo (OnceJump non dovrebbe servire ma è stato messo per sicurezza)
                {
                    animator.GetComponent<PSMController>().OnceJump = true;                                                                                                             //Controllo di sicurezza per eseguirlo solo una volta
                    animator.GetComponent<PSMController>().RB2D.AddForce(Vector2.up * animator.GetComponent<PSMController>().ValueJump.InitialJumpForce, ForceMode2D.Impulse);          //Spinta iniziale per evitare un salto non visibile
                }
            }
            #endregion

            #region Jump - Compito principale dello script di movimento
            if ((Input.GetKey(KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyUp)) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && animator.GetBool("PSM-IsGrounded") == true && (DialogueType1.StaticTutorial != -1 && DialogueType1.StaticTutorial2 != 2 && DialogueType1.StaticTutorial != 4))                                                                                                                  //Se Schiaccio spazio (è un getkey e non un getkeydown perché altrimenti non avrebbe preso l'input) e verifico grounded
            {
                //animator.GetComponent<PSMController>().RB2D.AddForce(Vector2.up * animator.GetComponent<PSMController>().ValueJump.jumpForce, ForceMode2D.Impulse);                                         //Applico una forza di tipo impulso con un direzione precisa (UP) e moltiplico per una determinata forza
                animator.SetBool("PSM-IsGrounded", false);                                                                                                                                                  //Setto grounded a falso per due motivi - 1. Il player non tocca più il terreno - 2. Blocco l'entrata al'if precedente per evitare salti infiniti/multipli
                                                                                                                                                                                                            //Debug.Log("PlayerState - Secondo passaggio del salto'");                                                                                                                                    //Debuggo in console cosa fa - Secondo passaggio per verificare quante volte ci entra
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
                animator.GetComponent<PSMController>().OnceJump = false;
            }
            #endregion

            if (animator.GetComponent<PSMController>().TypeCharacter == TypePlayer.Thief)
            {
                #region Move Zone - Compito principale dello script di movimento
                if ((Input.GetKey(KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyLeft)) || Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("DPad X") < 0) && (DialogueType1.StaticTutorial != -1 && DialogueType1.StaticTutorial2 != 2 && DialogueType1.StaticTutorial != 4 && DialogueType1.StaticTutorial != 6))                                                                                                                                                                                        //Se schiaccio A vado a sinistra
                {
                    if (SpecialBKIdle.BoriousMove == true)
                    {
                        animator.GetComponent<PSMController>().CalculateSpeed();                                                                                                                                                        //Calcolo la velocità
                        animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(-animator.GetComponent<PSMController>().ValueMovement.Speed, animator.GetComponent<PSMController>().RB2D.velocity.y);                        //Aumento la velocità
                    }
                    animator.GetComponent<PSMController>().transform.rotation = Quaternion.Euler(animator.GetComponent<PSMController>().transform.rotation.x, -180, animator.GetComponent<PSMController>().transform.rotation.z);   //Ruoto il player
                                                                                                                                                                                                                                    //Debug.Log("PlayerState - Vai a sinistra");
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
                }
                else                                                                                                                                                                                                                //Se non premo A e D
                {
                    #region - Da "Player Idle State" da "Player Fall State"
                    animator.GetComponent<PSMController>().RB2D.velocity = new Vector2(0, animator.GetComponent<PSMController>().RB2D.velocity.y);                                                                                  //Setto a 0 la velocità sulla x (Orizzontale)
                    animator.SetBool("PSM-CanMove", false);                                                                                                                                                                    //Ritorno in "Player Idle State" da "Player Move State"
                    #endregion
                }
                #endregion
            }
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("PSM-CanAttack", true);
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
