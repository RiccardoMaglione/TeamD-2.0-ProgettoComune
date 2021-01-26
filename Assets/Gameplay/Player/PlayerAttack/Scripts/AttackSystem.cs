using UnityEngine;
using System.Collections;

public class AttackSystem : MonoBehaviour
{
    [Tooltip("Velocità attacco")]
    [SerializeField] float attackTimer;
    
    PlayerInput playerInput;   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HIT" + collision.name);
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
