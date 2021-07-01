using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class BoriousKnightSpecialCollider : MonoBehaviour
{
    BasePlayerParticles basePlayerParticles;

    void OnEnable()
    {
        basePlayerParticles = gameObject.transform.root.GetComponentInChildren<BasePlayerParticles>();        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {     
            collision.GetComponent<EnemyData>().CountPoiseEnemy += 50;
            collision.GetComponent<Animator>().SetTrigger("DamageReceived");
            if (collision.GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponent<EnemyData>().MaxCountPoiseEnemy)
            {
                collision.GetComponentInParent<Animator>().SetBool("IsStagger", true);
            }

            collision.GetComponentInParent<EnemyData>().Life -= GetComponentInParent<BoriousKnightSpecialAttack>().damage;
            collision.GetComponentInParent<Animator>().SetFloat("Life", collision.GetComponentInParent<EnemyData>().Life);
            ColorChangeController colorChangeController = collision.GetComponent<ColorChangeController>();
            colorChangeController.isAttacked = true;
            collision.GetComponentInChildren<EnemyParticleController>().PlayBlood();
            AudioManager.instance.Play("Sfx_BK_p_H_atk");
            GameObject go = collision.gameObject;
            basePlayerParticles.PlayHit(go);
        }
    }
}
