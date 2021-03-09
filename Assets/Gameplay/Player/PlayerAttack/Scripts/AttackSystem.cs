using UnityEngine;
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
                //collision.GetComponent<EnemyManager>().ResetTimerStaggeredEnemy = 0;
                collision.GetComponent<Animator>().SetTrigger("DamageReceived");
                collision.GetComponentInParent<Animator>().SetInteger("Life", collision.GetComponent<EnemyData>().Life);
                if (collision.GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponent<EnemyData>().MaxCountPoiseEnemy)
                {
                    //animator.GetComponent<EnemyManager>().isStaggeredEnemy = true;
                    //collision.GetComponentInParent<Animator>().SetBool("IsStagger", true);
                    collision.GetComponentInParent<Animator>().SetBool("PSM-IsStagger", true);
                }
                print("Light");
                GetComponentInParent<PlayerController>().CurrentEnergy += GetComponentInParent<PlayerController>().LightEnergyAmount;
                print("Energy" + GetComponentInParent<PlayerController>().CurrentEnergy);
            }
            if (playerInput.isHeavyAttack == true)
            {
                playerInput.isHeavyAttack = false;
                collision.GetComponent<EnemyData>().Life -= HeavyDamage;
                collision.GetComponent<EnemyData>().CountHit++;
                collision.GetComponent<EnemyData>().CountPoiseEnemy++;
                //collision.GetComponent<EnemyManager>().ResetTimerStaggeredEnemy = 0;
                collision.GetComponent<Animator>().SetTrigger("DamageReceived");
                collision.GetComponentInParent<Animator>().SetInteger("Life", collision.GetComponent<EnemyData>().Life);
                if (collision.GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponent<EnemyData>().MaxCountPoiseEnemy)
                {
                    //animator.GetComponent<EnemyManager>().isStaggeredEnemy = true;
                    //collision.GetComponentInParent<Animator>().SetBool("IsStagger", true);
                    collision.GetComponentInParent<Animator>().SetBool("PSM-IsStagger", true);
                }
                print("Heavy");
                GetComponentInParent<PlayerController>().CurrentEnergy += GetComponentInParent<PlayerController>().HeavyEnergyAmount;
                print("Energy" + GetComponentInParent<PlayerController>().CurrentEnergy);
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
                //collision.GetComponent<EnemyManager>().ResetTimerStaggeredEnemy = 0;
                collision.GetComponent<Animator>().SetTrigger("DamageReceived");
                collision.GetComponentInParent<Animator>().SetInteger("Life", collision.GetComponent<EnemyData>().Life);
                if (collision.GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponent<EnemyData>().MaxCountPoiseEnemy)
                {
                    //animator.GetComponent<EnemyManager>().isStaggeredEnemy = true;
                    //collision.GetComponentInParent<Animator>().SetBool("IsStagger", true);
                    collision.GetComponentInParent<Animator>().SetBool("PSM-IsStagger", true);
                }
                print("Special");
                GetComponentInParent<PlayerController>().CurrentEnergy += GetComponentInParent<PlayerController>().SpecialEnergyAmount;
                print("Energy" + GetComponentInParent<PlayerController>().CurrentEnergy);
            }
        }
        
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(attackTimer);
        //playerInput.isAttack = false;
        playerInput.CooldownAttack = true;
        gameObject.SetActive(false);
        //GetComponentInParent<PlayerController>().isInAttack = false;
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
