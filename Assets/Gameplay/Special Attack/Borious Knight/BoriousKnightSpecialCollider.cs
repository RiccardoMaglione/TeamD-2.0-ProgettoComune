using UnityEngine;

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
            GameObject go = collision.gameObject;
            basePlayerParticles.PlayHit(go);
            if (AudioManager.instance != null)
            {
                AudioManager.instance.Play("Sfx_BK_S_atk");
            }
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            if (collision.GetComponentInParent<Boss>().canGetDamage == true)
                collision.GetComponentInParent<Boss>().life -= GetComponentInParent<BoriousKnightSpecialAttack>().damage * collision.GetComponent<Boss>().DMG_Reduction;
        }
    }
}
