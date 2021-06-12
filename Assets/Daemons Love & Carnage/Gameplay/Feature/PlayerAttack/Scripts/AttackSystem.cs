﻿using SwordGame;
using UnityEngine;
public class AttackSystem : MonoBehaviour
{
    //[Tooltip("Timer Collider Acceso - Tempo in cui il collider di attacco è attivo")]
    //[SerializeField] float attackTimer;

    //PlayerInput playerInput;

    [SerializeField] float LightDamage;
    [SerializeField] float HeavyDamage;
    [SerializeField] float SpecialDamage;

    [SerializeField] GameObject hitAnimation; //25/03/21


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Breakable") //10/04
        {
            Knockback.ActiveKnockback = true;//10/04
        }

        if (collision.gameObject.tag == "Boss" && Boss.instance.canGetDamage == true) //16/04
        {
            ColorChangeController colorChangeController = collision.GetComponent<ColorChangeController>();
            colorChangeController.isAttacked = true;

            if (GetComponentInParent<PSMController>().IsLightAttack == true)
            {
                collision.GetComponent<Boss>().life -= LightDamage * collision.GetComponent<Boss>().DMG_Reduction;
            }
            if (GetComponentInParent<PSMController>().IsHeavyAttack == true)
            {
                collision.GetComponent<Boss>().life -= HeavyDamage * collision.GetComponent<Boss>().DMG_Reduction;
            }
            if (GetComponentInParent<PSMController>().IsSpecialAttack == true)
            {
                collision.GetComponent<Boss>().life -= SpecialDamage * collision.GetComponent<Boss>().DMG_Reduction;
            }
        }

        //Debug.Log("Passa qui HIT" + collision.name);
        if (collision.gameObject.tag == "Enemy")
        {
            ColorChangeController colorChangeController = collision.GetComponent<ColorChangeController>();
            colorChangeController.isAttacked = true;

            if (hitAnimation != null) //27/03/21
                hitAnimation.SetActive(true); //25/03/21

            collision.GetComponentInChildren<EnemyParticleController>().PlayBlood();

            Knockback.ActiveKnockback = true;


            if (GetComponentInParent<PSMController>().IsLightAttack == true)
            {
                if (FeedbackManager.instance.isTimeStopped == false)
                {
                    //StartCoroutine(FeedbackManager.instance.StopTimeLight());
                }
                //GetComponentInParent<PSMController>().IsLightAttack = false;
                collision.GetComponent<EnemyData>().Life -= LightDamage * collision.GetComponent<EnemyData>().EnemyCoeffReduceDamageLight;
                collision.GetComponent<EnemyData>().CountHit++;
                collision.GetComponent<EnemyData>().CountPoiseEnemy += GetComponentInParent<PSMController>().ValuePoiseLight;
                collision.GetComponent<Animator>().SetTrigger("DamageReceived");
                //collision.GetComponentInParent<Animator>().SetInteger("Life", collision.GetComponent<EnemyData>().Life);
                collision.GetComponentInParent<Animator>().SetFloat("Life", collision.GetComponent<EnemyData>().Life);
                if (collision.GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponent<EnemyData>().MaxCountPoiseEnemy)
                {
                    collision.GetComponentInParent<Animator>().SetBool("IsStagger", true);
                }
                GetComponentInParent<PSMController>().CurrentEnergy += GetComponentInParent<PSMController>().LightEnergyAmount;
                //print("Energy" + GetComponentInParent<PSMController>().CurrentEnergy);
            }
            if (GetComponentInParent<PSMController>().IsHeavyAttack == true)
            {
                if (FeedbackManager.instance.isTimeStopped == false)
                {
                    //StartCoroutine(FeedbackManager.instance.StopTimeHeavy());
                }

                //GetComponentInParent<PSMController>().IsHeavyAttack = false;
                collision.GetComponent<EnemyData>().Life -= HeavyDamage * collision.GetComponent<EnemyData>().EnemyCoeffReduceDamageHeavy;
                collision.GetComponent<EnemyData>().CountHit += GetComponentInParent<PSMController>().ValuePoiseHeavy;
                collision.GetComponent<EnemyData>().CountPoiseEnemy++;
                collision.GetComponent<Animator>().SetTrigger("DamageReceived");
                //collision.GetComponentInParent<Animator>().SetInteger("Life", collision.GetComponent<EnemyData>().Life);
                collision.GetComponentInParent<Animator>().SetFloat("Life", collision.GetComponent<EnemyData>().Life);
                if (collision.GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponent<EnemyData>().MaxCountPoiseEnemy)
                {
                    collision.GetComponentInParent<Animator>().SetBool("IsStagger", true);
                }
                //print("Heavy");
                GetComponentInParent<PSMController>().CurrentEnergy += GetComponentInParent<PSMController>().HeavyEnergyAmount;
                //print("Energy" + GetComponentInParent<PSMController>().CurrentEnergy);
            }
            if (GetComponentInParent<PSMController>().IsSpecialAttack == true)
            {
                //GetComponentInParent<PSMController>().IsSpecialAttack = false;
                collision.GetComponent<EnemyData>().Life -= SpecialDamage * collision.GetComponent<EnemyData>().EnemyCoeffReduceDamageSpecial;
                if (collision.GetComponent<EnemyData>().Life <= 0)
                {
                    FindObjectOfType<ScoreSystem>(true).SpecialType = true;
                }
                collision.GetComponent<EnemyData>().CountHit++;
                collision.GetComponent<EnemyData>().CountPoiseEnemy += GetComponentInParent<PSMController>().ValuePoiseSpecial;
                collision.GetComponent<Animator>().SetTrigger("DamageReceived");
                //collision.GetComponentInParent<Animator>().SetInteger("Life", collision.GetComponent<EnemyData>().Life);
                collision.GetComponentInParent<Animator>().SetFloat("Life", collision.GetComponent<EnemyData>().Life);
                if (collision.GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponent<EnemyData>().MaxCountPoiseEnemy)
                {
                    collision.GetComponentInParent<Animator>().SetBool("IsStagger", true);
                }
                print("Special");
                GetComponentInParent<PSMController>().CurrentEnergy += GetComponentInParent<PSMController>().SpecialEnergyAmount;
                print("Energy" + GetComponentInParent<PSMController>().CurrentEnergy);
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponentInParent<PSMController>().IsLightAttack = false;
        GetComponentInParent<PSMController>().IsHeavyAttack = false;
        GetComponentInParent<PSMController>().IsSpecialAttack = false;
        if (hitAnimation != null)    //27/03/21
            hitAnimation.SetActive(false); //25/03/21
    }
    //IEnumerator Attack()
    //{
    //    yield return new WaitForSeconds(attackTimer);
    //    playerInput.CooldownAttack = true;
    //    gameObject.SetActive(false);
    //}
    //
    //
    //void Awake()
    //{
    //    playerInput = FindObjectOfType<PlayerInput>();
    //}
    //
    //void OnEnable()
    //{
    //    StartCoroutine(Attack());
    //}
}
