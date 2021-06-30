using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoriousKnightSpecialCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponentInParent<EnemyData>().Life -= GetComponentInParent<BoriousKnightSpecialAttack>().damage;
            collision.GetComponentInParent<Animator>().SetFloat("Life", collision.GetComponentInParent<EnemyData>().Life);
            if(AudioManager.instance != null)
            {
                AudioManager.instance.Play("Sfx_BK_S_atk");
            }
        }
    }
}
