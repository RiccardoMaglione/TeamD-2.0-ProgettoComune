using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class TriggerPossession : Possession
{
    #region Variables
    [Space(10)]
    [Header("------------------------ Trigger Possession Variables -----------------------------------------------------------------------------------------------------------------------------")]
    [Space(20)]

    [ReadOnly] public GameObject Player;

    [ReadOnly] public GameObject InspectorEnemy;
    public static GameObject Enemy;

    public GameObject PromptEnemy;

    public float RadiusArea = 1;            //Inutilizzato - Modalità di utilizzo = Settare la circonferenza del collider e richiamarlo nello stato stun
    #endregion

    void Update()
    {
        InspectorEnemy = Enemy;

        if (Enemy != GetComponentInParent<EnemyData>().gameObject)
        {
            PromptEnemy.SetActive(false);
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button4)) && Enemy == GetComponentInParent<EnemyData>().gameObject & !Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Player Die State"))
        {
            if (AudioManager.instance != null)
                AudioManager.instance.Play("Sfx_possesion");

            Possession(Player, Enemy);
        }
    }

    private void OnDisable()
    {
        PromptEnemy.SetActive(false);
        Player = null;
        Enemy = null;
        InspectorEnemy = Enemy;
    }

    /// <summary>
    /// Metodo che attiva la possessione tra il player attuale e il nemico individuato
    /// </summary>
    /// <param name="PlayerToEnemy"></param>
    /// <param name="EnemyToPlayer"></param>
    public void Possession(GameObject PlayerToEnemy, GameObject EnemyToPlayer)
    {
        ReturnPlayer.CanDestroy = false;
        ReturnPlayer.timerDestroy = 0;

        FindObjectOfType<ChangeFollow>().NewPlayer = EnemyToPlayer;
        
        IncrementCount();
        SetParametersEnemyToPlayer(EnemyToPlayer);
        ChangeTagArea(PlayerToEnemy, EnemyToPlayer);
        ChangeTagObject(PlayerToEnemy, EnemyToPlayer);
        ChangeLayerObject(PlayerToEnemy, EnemyToPlayer);
        ChangeLayerPrompt(PlayerToEnemy, EnemyToPlayer);
        ChangeSortingLayer(PlayerToEnemy, EnemyToPlayer);
        ChangePhysicsMaterial(PlayerToEnemy, EnemyToPlayer);
        ChangeAnimatorOfPlayer(PlayerToEnemy);
        ChangeAnimatorOfEnemy(EnemyToPlayer);
        SetParametersPlayerToEnemy(PlayerToEnemy);
        DisableRangeCollider(EnemyToPlayer);
        DisableAttackCollider(PlayerToEnemy, EnemyToPlayer);
        EnableDisableAggro(PlayerToEnemy, EnemyToPlayer);
        EnableDisableParticles(PlayerToEnemy, EnemyToPlayer);
        EnableDisableEnemyData(PlayerToEnemy, EnemyToPlayer);
        EnableDisablePSMController(PlayerToEnemy, EnemyToPlayer);
        SetOriginalMaterial(EnemyToPlayer);
        SetLife(PlayerToEnemy, EnemyToPlayer);
        SetEnergy(PlayerToEnemy, EnemyToPlayer);
        SetVelocityAnimator(PlayerToEnemy, EnemyToPlayer);
        SetVelocityPlayer(PlayerToEnemy);
        CheckTypePlayer(EnemyToPlayer);
        /**/EnableDisableSpecialAttack(PlayerToEnemy, EnemyToPlayer);
        /**/ResetPlatform(PlayerToEnemy);
        ChangeIconPlayer(EnemyToPlayer, UIPortrait.StaticPortrait);

        ReturnPlayer.PlayerNow = EnemyToPlayer;
        ReturnPlayer.LastDetectList.Add(PlayerToEnemy);
        ReturnPlayer.TimerDestroyList.Add(0);
        ReturnPlayer.CanDestroyList.Add(true);
        ReturnPlayer.CanDestroy = true;

        PlayerToEnemy.GetComponentInChildren<TriggerPossession>(true).enabled = true;
        EnemyToPlayer.GetComponentInChildren<TriggerPossession>(true).enabled = false;
    }

    /// <summary>
    /// Trigger di entrata in cui setto la variabili della possessione
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10 && collision.gameObject.tag == "PlayerPossession")                          //Se l'oggetto colliso è sul layer 10 (Possession) e l'oggetto colliso ha come tag "PlayerPossession"
        {
            Player = collision.GetComponentInParent<PSMController>().gameObject;                                        //Definisco il player come l'oggetto parent dello script PSMController
            Enemy = gameObject.GetComponentInParent<EnemyData>().gameObject;                                            //Definisco l'enemy come l'oggetto parent dello script EnemyData
            Enemy.GetComponentInChildren<TriggerPossession>().PromptEnemy.SetActive(true);                              //Attivo il prompt del tasto all'enemy
        }
    }

    /// <summary>
    /// Trigger stazionario in cui setto le variabili della possessione in caso di molteplici aree possession
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10 && collision.gameObject.tag == "PlayerPossession")                         //Se l'oggetto colliso è sul layer 10 (Possession) e l'oggetto colliso ha come tag "PlayerPossession"
        {
            Player = collision.GetComponentInParent<PSMController>().gameObject;                                        //Definisco il player come l'oggetto parent dello script PSMController
            Enemy = gameObject.GetComponentInParent<EnemyData>().gameObject;                                            //Definisco l'enemy come l'oggetto parent dello script EnemyData
            Enemy.GetComponentInChildren<TriggerPossession>().PromptEnemy.SetActive(true);                              //Attivo il prompt del tasto all'enemy
        }
    }

    /// <summary>
    /// Trigger di uscita in cui disattivo le variabili della possessione
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10 && collision.gameObject.tag == "PlayerPossession")                         //Se l'oggetto colliso è sul layer 10 (Possession) e l'oggetto colliso ha come tag "PlayerPossession" 
        {
            if (Enemy != null)                                                                                          //Se il nemico è definito e quindi non è null - Non ci entra quando un nemico muore
            {
                Enemy.GetComponentInChildren<TriggerPossession>(true).PromptEnemy.SetActive(false);                     //Disattivo il prompt dell'enemy
            }
            Player = null;                                                                                              //Setto a null il player
            Enemy = null;                                                                                               //Setto a null l'enemy
        }
    }
}