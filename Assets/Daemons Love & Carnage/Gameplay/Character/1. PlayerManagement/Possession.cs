using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class Possession : MonoBehaviour
{
    #region Variables
    [Space(5)]
    [Header("Animator Zone - Enemy Animator ------------------------------------------------------------------------------------------")]

    [Space(10)]
    [Header("------------------------ Possession Variables Inheritance -----------------------------------------------------------------------------------------------------------------------------")]

    public RuntimeAnimatorController FatKnightEnemyAnimator;
    public RuntimeAnimatorController BoriousEnemyAnimator;
    public RuntimeAnimatorController BabushkaEnemyAnimator;
    public RuntimeAnimatorController ThiefEnemyAnimator;

    [Space(5)]
    [Header("Animator Zone - Player Animator ------------------------------------------------------------------------------------------")]

    public RuntimeAnimatorController FatKnightPlayerAnimator;
    public RuntimeAnimatorController BoriousKnightPlayerAnimator;
    public RuntimeAnimatorController BabushkaPlayerAnimator;
    public RuntimeAnimatorController ThiefPlayerAnimator;

    [Space(5)]
    [Header("Material Zone - Change Variables ------------------------------------------------------------------------------------------")]

    public PhysicsMaterial2D MaterialNoFriction;
    public PhysicsMaterial2D MaterialYesFriction;

    [Space(5)]
    [Header("Particle Zone - Change Variables ------------------------------------------------------------------------------------------")]

    public GameObject EnemyParticle;
    public GameObject PlayerParticle;
    #endregion

    #region Method Zone
    /// <summary>
    /// Cambiare tag all'area della possessione
    /// </summary>
    /// <param name="PlayerToEnemy"></param>
    /// <param name="EnemyToPlayer"></param>
    public void ChangeTagArea(GameObject PlayerToEnemy, GameObject EnemyToPlayer)
    {
        PlayerToEnemy.GetComponentInChildren<TriggerPossession>(true).gameObject.tag = "Untagged";
        EnemyToPlayer.GetComponentInChildren<TriggerPossession>(true).gameObject.tag = "PlayerPossession";
    }

    /// <summary>
    /// Cambiare tag al player e al nemico
    /// </summary>
    /// <param name="PlayerToEnemy"></param>
    /// <param name="EnemyToPlayer"></param>
    public void ChangeTagObject(GameObject PlayerToEnemy, GameObject EnemyToPlayer)
    {
        PlayerToEnemy.tag = "Enemy";
        EnemyToPlayer.tag = "Player";
    }

    /// <summary>
    /// Cambiare layer al player e al nemico
    /// </summary>
    /// <param name="PlayerToEnemy"></param>
    /// <param name="EnemyToPlayer"></param>
    public void ChangeLayerObject(GameObject PlayerToEnemy, GameObject EnemyToPlayer)
    {
        PlayerToEnemy.layer = 9;
        EnemyToPlayer.layer = 8;
    }

    /// <summary>
    /// Cambiare layer prompt al player e al nemico
    /// </summary>
    /// <param name="PlayerToEnemy"></param>
    /// <param name="EnemyToPlayer"></param>
    public void ChangeLayerPrompt(GameObject PlayerToEnemy, GameObject EnemyToPlayer)
    {
        PlayerToEnemy.GetComponentInChildren<TriggerPossession>(true).PromptEnemy.layer = 9;
        EnemyToPlayer.GetComponentInChildren<TriggerPossession>(true).PromptEnemy.layer = 9;
    }

    /// <summary>
    /// Cambiare il sorting layer al player e al nemico
    /// </summary>
    /// <param name="PlayerToEnemy"></param>
    /// <param name="EnemyToPlayer"></param>
    public void ChangeSortingLayer(GameObject PlayerToEnemy, GameObject EnemyToPlayer)
    {
        PlayerToEnemy.GetComponent<SpriteRenderer>().sortingOrder = EnemyToPlayer.GetComponent<SpriteRenderer>().sortingOrder;
        EnemyToPlayer.GetComponent<SpriteRenderer>().sortingOrder = 9;
    }

    /// <summary>
    /// Cabiare materiale fisico
    /// </summary>
    /// <param name="PlayerToEnemy"></param>
    /// <param name="EnemyToPlayer"></param>
    /// <param name="MaterialYesFriction"></param>
    /// <param name="MaterialNoFriction"></param>
    public void ChangePhysicsMaterial(GameObject PlayerToEnemy, GameObject EnemyToPlayer)
    {
        PlayerToEnemy.GetComponent<Rigidbody2D>().sharedMaterial = MaterialYesFriction;
        EnemyToPlayer.GetComponent<Rigidbody2D>().sharedMaterial = MaterialNoFriction;
    }

    /// <summary>
    /// Cambio animator da player a enemy
    /// </summary>
    /// <param name="PlayerToEnemy"></param>
    /// <param name="FatKnightEnemyAnimator"></param>
    /// <param name="BoriousEnemyAnimator"></param>
    /// <param name="BabushkaEnemyAnimator"></param>
    /// <param name="ThiefEnemyAnimator"></param>
    public void ChangeAnimatorOfPlayer(GameObject PlayerToEnemy)
    {
        switch (PlayerToEnemy.GetComponent<EnemyData>().TypeEnemy)
        {
            case TypeEnemies.FatKnight:
                PlayerToEnemy.GetComponent<Animator>().runtimeAnimatorController = FatKnightEnemyAnimator;
                break;
            case TypeEnemies.BoriusKnight:
                PlayerToEnemy.GetComponent<Animator>().runtimeAnimatorController = BoriousEnemyAnimator;
                break;
            case TypeEnemies.Babushka:
                PlayerToEnemy.GetComponent<Animator>().runtimeAnimatorController = BabushkaEnemyAnimator;
                break;
            case TypeEnemies.Thief:
                PlayerToEnemy.GetComponent<Animator>().runtimeAnimatorController = ThiefEnemyAnimator;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Cambio animator da enemy a player
    /// </summary>
    /// <param name="EnemyToPlayer"></param>
    /// <param name="FatKnightPlayerAnimator"></param>
    /// <param name="BoriousKnightPlayerAnimator"></param>
    /// <param name="BabushkaPlayerAnimator"></param>
    /// <param name="ThiefPlayerAnimator"></param>
    public void ChangeAnimatorOfEnemy(GameObject EnemyToPlayer)
    {
        switch (EnemyToPlayer.GetComponent<PSMController>().TypeCharacter)
        {
            case TypePlayer.FatKnight:
                EnemyToPlayer.GetComponent<Animator>().runtimeAnimatorController = FatKnightPlayerAnimator;
                break;
            case TypePlayer.BoriousKnight:
                EnemyToPlayer.GetComponent<Animator>().runtimeAnimatorController = BoriousKnightPlayerAnimator;
                break;
            case TypePlayer.Babushka:
                EnemyToPlayer.GetComponent<Animator>().runtimeAnimatorController = BabushkaPlayerAnimator;
                break;
            case TypePlayer.Thief:
                EnemyToPlayer.GetComponent<Animator>().runtimeAnimatorController = ThiefPlayerAnimator;

                EnemyToPlayer.GetComponent<BoxCollider2D>().size = new Vector2(EnemyToPlayer.GetComponent<BoxCollider2D>().size.x, 1.717764f);
                EnemyToPlayer.GetComponent<BoxCollider2D>().offset = new Vector2(EnemyToPlayer.GetComponent<BoxCollider2D>().offset.x, -0.1982318f);

                EnemyToPlayer.GetComponent<EnemyData>().SpawnArrow.transform.localPosition = new Vector3(1, -0.413f, 0);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Disattivazione range collider
    /// </summary>
    /// <param name="EnemyToPlayer"></param>
    public void DisableRangeCollider(GameObject EnemyToPlayer)
    {
        EnemyToPlayer.GetComponent<EnemyData>().RangeMelee.SetActive(false);
        EnemyToPlayer.GetComponent<EnemyData>().RangeRanged.SetActive(false);
    }

    /// <summary>
    /// Disattivazione collider di attacco
    /// </summary>
    /// <param name="PlayerToEnemy"></param>
    /// <param name="EnemyToPlayer"></param>
    public void DisableAttackCollider(GameObject PlayerToEnemy, GameObject EnemyToPlayer)
    {
        PlayerToEnemy.GetComponent<PSMController>().LightAttackCollider.SetActive(false);
        PlayerToEnemy.GetComponent<PSMController>().HeavyAttackCollider.SetActive(false);
        EnemyToPlayer.GetComponent<EnemyData>().LightAttackCollider.SetActive(false);
        EnemyToPlayer.GetComponent<EnemyData>().HeavyAttackCollider.SetActive(false);
    }

    /// <summary>
    /// Attivazione e disattivazione dell'oggeto con nome Aggro - WIP
    /// </summary>
    /// <param name="PlayerToEnemy"></param>
    /// <param name="EnemyToPlayer"></param>
    public void EnableDisableAggro(GameObject PlayerToEnemy, GameObject EnemyToPlayer)
    {
        PlayerToEnemy.transform.Find("Aggro").gameObject.SetActive(true);
        EnemyToPlayer.transform.Find("Aggro").gameObject.SetActive(false);
    }

    /// <summary>
    /// Attivazione e disattivazione particellare
    /// </summary>
    /// <param name="PlayerToEnemy"></param>
    /// <param name="EnemyToPlayer"></param>
    public void EnableDisableParticles(GameObject PlayerToEnemy, GameObject EnemyToPlayer)
    {
        PlayerToEnemy.GetComponentInChildren<TriggerPossession>(true).EnemyParticle.SetActive(true);
        PlayerToEnemy.GetComponentInChildren<TriggerPossession>(true).PlayerParticle.SetActive(false);
        EnemyToPlayer.GetComponentInChildren<TriggerPossession>(true).PlayerParticle.SetActive(true);
        EnemyToPlayer.GetComponentInChildren<TriggerPossession>(true).EnemyParticle.SetActive(false);
    }

    /// <summary>
    /// Attivazione e disattivazione dello script EnemyData
    /// </summary>
    /// <param name="PlayerToEnemy"></param>
    /// <param name="EnemyToPlayer"></param>
    public void EnableDisableEnemyData(GameObject PlayerToEnemy, GameObject EnemyToPlayer)
    {
        PlayerToEnemy.GetComponent<EnemyData>().enabled = true;
        EnemyToPlayer.GetComponent<EnemyData>().enabled = false;
    }

    /// <summary>
    /// Attivazione e disattivazione dello script PSMController
    /// </summary>
    /// <param name="PlayerToEnemy"></param>
    /// <param name="EnemyToPlayer"></param>
    public void EnableDisablePSMController(GameObject PlayerToEnemy, GameObject EnemyToPlayer)
    {
        PlayerToEnemy.GetComponent<PSMController>().enabled = false;
        EnemyToPlayer.GetComponent<PSMController>().enabled = true;
    }

    /// <summary>
    /// Settare il materiale originale
    /// </summary>
    /// <param name="PlayerToEnemy"></param>
    /// <param name="EnemyToPlayer"></param>
    public void SetOriginalMaterial(GameObject EnemyToPlayer)
    {
        EnemyToPlayer.GetComponent<SpriteRenderer>().material = EnemyToPlayer.GetComponent<ColorChangeController>().originalMaterial;
    }

    /// <summary>
    /// Si occupa di settare varie cose della vita
    /// </summary>
    /// <param name="PlayerToEnemy"></param>
    /// <param name="EnemyToPlayer"></param>
    public void SetLife(GameObject PlayerToEnemy, GameObject EnemyToPlayer)
    {
        if (EnemyToPlayer.GetComponent<PSMController>().HealthSlider != null)
        {
            EnemyToPlayer.GetComponent<PSMController>().HealthSlider.MaxHealth(EnemyToPlayer.GetComponent<PSMController>().MaxHealth);
        }

        PlayerToEnemy.GetComponent<EnemyData>().Life = 0;

        //PlayerToEnemy.GetComponent<Animator>().SetInteger("Life", PlayerToEnemy.GetComponent<EnemyData>().Life);    //Viene uguagliato lo stesso in un altro script, controllare dove e togliere questo
        PlayerToEnemy.GetComponent<Animator>().SetFloat("Life", PlayerToEnemy.GetComponent<EnemyData>().Life);    //Viene uguagliato lo stesso in un altro script, controllare dove e togliere questo
    }

    /// <summary>
    /// Setta alcuni parametri e variabili del player che diventa nemico
    /// </summary>
    /// <param name="PlayerToEnemy"></param>
    public void SetParametersPlayerToEnemy(GameObject PlayerToEnemy)
    {
        PlayerToEnemy.GetComponent<EnemyData>().isStun = true;
        PlayerToEnemy.GetComponent<Animator>().SetBool("CanPossession", true);
    }

    /// <summary>
    /// Setta alcuni parametri e variabili del nemico che diventa player
    /// </summary>
    /// <param name="EnemyToPlayer"></param>
    public void SetParametersEnemyToPlayer(GameObject EnemyToPlayer)
    {
        EnemyToPlayer.GetComponent<EnemyData>().isPossessed = true;
        EnemyToPlayer.GetComponent<Animator>().SetBool("CanPossession", false);
        EnemyToPlayer.GetComponent<PSMController>().PoisePlayer = 0;
    }

    /// <summary>
    /// Inizializza le velocità delle animazioni in modo tale da riportarle alla normalità senza sfasarle
    /// </summary>
    /// <param name="PlayerToEnemy"></param>
    /// <param name="EnemyToPlayer"></param>
    public void SetVelocityAnimator(GameObject PlayerToEnemy, GameObject EnemyToPlayer)
    {
        PlayerToEnemy.GetComponent<EnemyData>().InitializeSpeedAnimation();
        EnemyToPlayer.GetComponent<PSMController>().InitializeSpeedAnimation();
    }

    /// <summary>
    /// Blocca la velocità del player che per diventare nemico, in modo tale da bloccarlo e di non farlo muovere senza attrito
    /// </summary>
    /// <param name="PlayerToEnemy"></param>
    public void SetVelocityPlayer(GameObject PlayerToEnemy)
    {
        PlayerToEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
    #endregion
}