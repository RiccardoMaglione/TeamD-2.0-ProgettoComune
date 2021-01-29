using UnityEngine;
using System.Collections;

public class AttackSystem : MonoBehaviour
{
    [Tooltip("Velocità attacco")]
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
            }
            if (playerInput.isHeavyAttack == true)
            {
                playerInput.isHeavyAttack = false;
                collision.GetComponent<EnemyManager>().Life -= HeavyDamage;
                collision.GetComponent<EnemyManager>().CountHit++;
                print("Heavy");
            }
            if (playerInput.isSpecialAttack == true)
            {
                playerInput.isSpecialAttack = false;
                collision.GetComponent<EnemyManager>().Life -= SpecialDamage;
                collision.GetComponent<EnemyManager>().CountHit++;
                print("Special");
            }
        }
        
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(attackTimer);
        playerInput.isAttack = false;
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
