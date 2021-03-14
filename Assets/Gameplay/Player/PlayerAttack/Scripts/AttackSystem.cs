﻿using UnityEngine;
using System.Collections;
using SwordGame;
public class AttackSystem : MonoBehaviour
{
    [Tooltip("Timer Collider Acceso - Tempo in cui il collider di attacco è attivo")]
    [SerializeField] float attackTimer;

    PlayerInput playerInput;

    [SerializeField] int LightDamage;
    [SerializeField] int HeavyDamage;
    [SerializeField] int SpecialDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HIT" + collision.name);
        if(collision.gameObject.tag == "Enemy")
        {
            Knockback.ActiveKnockback = true;
            if(playerInput.isLightAttack == true)
            {
                playerInput.isLightAttack = false;
                collision.GetComponent<EnemyData>().Life -= LightDamage;
                collision.GetComponent<EnemyData>().CountHit++;
                collision.GetComponent<EnemyData>().CountPoiseEnemy++;
                collision.GetComponent<Animator>().SetTrigger("DamageReceived");
                collision.GetComponentInParent<Animator>().SetInteger("Life", collision.GetComponent<EnemyData>().Life);
                if (collision.GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponent<EnemyData>().MaxCountPoiseEnemy)
                {
                    collision.GetComponentInParent<Animator>().SetBool("PSM-IsStagger", true);
                }
                print("Light");
                GetComponentInParent<PSMController>().CurrentEnergy += GetComponentInParent<PSMController>().LightEnergyAmount;
                print("Energy" + GetComponentInParent<PSMController>().CurrentEnergy);
            }
            if (playerInput.isHeavyAttack == true)
            {
                playerInput.isHeavyAttack = false;
                collision.GetComponent<EnemyData>().Life -= HeavyDamage;
                collision.GetComponent<EnemyData>().CountHit++;
                collision.GetComponent<EnemyData>().CountPoiseEnemy++;
                collision.GetComponent<Animator>().SetTrigger("DamageReceived");
                collision.GetComponentInParent<Animator>().SetInteger("Life", collision.GetComponent<EnemyData>().Life);
                if (collision.GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponent<EnemyData>().MaxCountPoiseEnemy)
                {
                    collision.GetComponentInParent<Animator>().SetBool("PSM-IsStagger", true);
                }
                print("Heavy");
                GetComponentInParent<PSMController>().CurrentEnergy += GetComponentInParent<PSMController>().HeavyEnergyAmount;
                print("Energy" + GetComponentInParent<PSMController>().CurrentEnergy);
            }
            if (playerInput.isSpecialAttack == true)
            {
                playerInput.isSpecialAttack = false;
                collision.GetComponent<EnemyData>().Life -= SpecialDamage;
                if (collision.GetComponent<EnemyData>().Life <= 0)
                {
                    FindObjectOfType<ScoreSystem>(true).SpecialType = true;
                }
                collision.GetComponent<EnemyData>().CountHit++;
                collision.GetComponent<EnemyData>().CountPoiseEnemy++;
                collision.GetComponent<Animator>().SetTrigger("DamageReceived");
                collision.GetComponentInParent<Animator>().SetInteger("Life", collision.GetComponent<EnemyData>().Life);
                if (collision.GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponent<EnemyData>().MaxCountPoiseEnemy)
                {
                    collision.GetComponentInParent<Animator>().SetBool("PSM-IsStagger", true);
                }
                print("Special");
                GetComponentInParent<PSMController>().CurrentEnergy += GetComponentInParent<PSMController>().SpecialEnergyAmount;
                print("Energy" + GetComponentInParent<PSMController>().CurrentEnergy);
            }
        }
        
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(attackTimer);
        playerInput.CooldownAttack = true;
        gameObject.SetActive(false);
    }


    void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
    }

    void OnEnable()
    {
        StartCoroutine(Attack());
    }
}
