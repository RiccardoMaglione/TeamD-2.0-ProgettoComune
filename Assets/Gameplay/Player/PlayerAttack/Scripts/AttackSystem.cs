using UnityEngine;
using System.Collections;
using SwordGame;
public class AttackSystem : MonoBehaviour
{
    //[Tooltip("Timer Collider Acceso - Tempo in cui il collider di attacco è attivo")]
    //[SerializeField] float attackTimer;

    //PlayerInput playerInput;

    [SerializeField] int LightDamage;
    [SerializeField] int HeavyDamage;
    [SerializeField] int SpecialDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Passa qui HIT" + collision.name);
        if(collision.gameObject.tag == "Enemy")
        {
            Knockback.ActiveKnockback = true;
            if (GetComponentInParent<PSMController>().IsLightAttack == true)
            {
                GetComponentInParent<PSMController>().IsLightAttack = false;
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
            if (GetComponentInParent<PSMController>().IsHeavyAttack == true)
            {
                GetComponentInParent<PSMController>().IsHeavyAttack = false;
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
            if (GetComponentInParent<PSMController>().IsSpecialAttack == true)
            {
                GetComponentInParent<PSMController>().IsSpecialAttack = false;
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
