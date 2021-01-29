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
                collision.GetComponent<EnemyManager>().Life -= LightDamage;
                collision.GetComponent<EnemyManager>().CountHit++;
                print("Light");
                GetComponentInParent<PlayerManager>().CurrentEnergy += GetComponentInParent<PlayerManager>().LightEnergyAmount;
                print("Energy" + GetComponentInParent<PlayerManager>().CurrentEnergy);
            }
            if (playerInput.isHeavyAttack == true)
            {
                playerInput.isHeavyAttack = false;
                collision.GetComponent<EnemyManager>().Life -= HeavyDamage;
                collision.GetComponent<EnemyManager>().CountHit++;
                print("Heavy");
                GetComponentInParent<PlayerManager>().CurrentEnergy += GetComponentInParent<PlayerManager>().HeavyEnergyAmount;
                print("Energy" + GetComponentInParent<PlayerManager>().CurrentEnergy);
            }
            if (playerInput.isSpecialAttack == true)
            {
                playerInput.isSpecialAttack = false;
                collision.GetComponent<EnemyManager>().Life -= SpecialDamage;
                collision.GetComponent<EnemyManager>().CountHit++;
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
