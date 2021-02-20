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
            if(playerInput.isLightAttack == true)
            {
                playerInput.isLightAttack = false;
                collision.GetComponent<EnemyData>().Life -= LightDamage;
                collision.GetComponent<EnemyData>().CountHit++;
                collision.GetComponent<EnemyData>().CountPoiseEnemy++;
                //collision.GetComponent<EnemyManager>().ResetTimerStaggeredEnemy = 0;



                if (collision.GetComponentInParent<Animator>().GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponentInParent<Animator>().GetComponent<EnemyData>().MaxCountPoiseEnemy)
                {
                    //animator.GetComponent<EnemyManager>().isStaggeredEnemy = true;
                    collision.GetComponentInParent<Animator>().SetBool("IsStagger", true);
                }
                collision.GetComponentInParent<Animator>().SetInteger("Life", GetComponentInParent<Animator>().GetComponent<EnemyData>().Life);
                //collision.GetComponent<Animator>().SetTrigger("DamageReceived");




                print("Light");
                GetComponentInParent<PlayerManager>().CurrentEnergy += GetComponentInParent<PlayerManager>().LightEnergyAmount;
                print("Energy" + GetComponentInParent<PlayerManager>().CurrentEnergy);
            }
            if (playerInput.isHeavyAttack == true)
            {
                playerInput.isHeavyAttack = false;
                collision.GetComponent<EnemyData>().Life -= HeavyDamage;
                collision.GetComponent<EnemyData>().CountHit++;
                collision.GetComponent<EnemyData>().CountPoiseEnemy++;
                //collision.GetComponent<EnemyManager>().ResetTimerStaggeredEnemy = 0;



                if (collision.GetComponentInParent<Animator>().GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponentInParent<Animator>().GetComponent<EnemyData>().MaxCountPoiseEnemy)
                {
                    //animator.GetComponent<EnemyManager>().isStaggeredEnemy = true;
                    collision.GetComponentInParent<Animator>().SetBool("IsStagger", true);
                }
                collision.GetComponentInParent<Animator>().SetInteger("Life", GetComponentInParent<Animator>().GetComponent<EnemyData>().Life);
                //collision.GetComponent<Animator>().SetTrigger("DamageReceived");



                print("Heavy");
                GetComponentInParent<PlayerManager>().CurrentEnergy += GetComponentInParent<PlayerManager>().HeavyEnergyAmount;
                print("Energy" + GetComponentInParent<PlayerManager>().CurrentEnergy);
            }
            if (playerInput.isSpecialAttack == true)
            {
                playerInput.isSpecialAttack = false;
                collision.GetComponent<EnemyData>().Life -= SpecialDamage;
                collision.GetComponent<EnemyData>().CountHit++;
                collision.GetComponent<EnemyData>().CountPoiseEnemy++;
                //collision.GetComponent<EnemyManager>().ResetTimerStaggeredEnemy = 0;


                if (collision.GetComponentInParent<Animator>().GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponentInParent<Animator>().GetComponent<EnemyData>().MaxCountPoiseEnemy)
                {
                    //animator.GetComponent<EnemyManager>().isStaggeredEnemy = true;
                    collision.GetComponentInParent<Animator>().SetBool("IsStagger", true);
                }
                collision.GetComponentInParent<Animator>().SetInteger("Life", GetComponentInParent<Animator>().GetComponent<EnemyData>().Life);
                //collision.GetComponent<Animator>().SetTrigger("DamageReceived");
                
                
                
                print("Special");
                GetComponentInParent<PlayerManager>().CurrentEnergy += GetComponentInParent<PlayerManager>().SpecialEnergyAmount;
                print("Energy" + GetComponentInParent<PlayerManager>().CurrentEnergy);
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
