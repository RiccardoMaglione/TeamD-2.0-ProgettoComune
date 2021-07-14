using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class SpecialArrow : MonoBehaviour
{
    public Vector3 KnockbackDirection;
    public int DamageArrow;
    public float thrust;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")    
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((transform.right + transform.InverseTransformDirection(KnockbackDirection)).normalized * thrust, ForceMode2D.Impulse);
            ColorChangeController colorChangeController = collision.GetComponent<ColorChangeController>();
            colorChangeController.isAttacked = true;

            collision.GetComponentInChildren<EnemyParticleController>().PlayBlood();

            Knockback.ActiveKnockback = true;

            if (FeedbackManager.instance.isTimeStopped == false)
            {
                //StartCoroutine(FeedbackManager.instance.StopTimeLight());
            }

            #region Conteggio Damage e Poise
            collision.GetComponent<EnemyData>().Life -= DamageArrow * collision.GetComponent<EnemyData>().EnemyCoeffReduceDamageLight;
            collision.GetComponent<EnemyData>().CountHit++;
            collision.GetComponent<EnemyData>().CountPoiseEnemy += ChangeFollow.StaticPlayerTemp.GetComponentInParent<PSMController>().ValuePoiseLight;
            //collision.GetComponent<EnemyData>().GetComponent<Animator>().SetInteger("Life", collision.GetComponent<EnemyData>().Life);
            collision.GetComponent<EnemyData>().GetComponent<Animator>().SetFloat("Life", collision.GetComponent<EnemyData>().Life);
            collision.GetComponent<Animator>().SetTrigger("DamageReceived");
            
            if (collision.GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponent<EnemyData>().MaxCountPoiseEnemy)
            {
                collision.GetComponent<EnemyData>().GetComponent<Animator>().SetBool("IsStagger", true);
            }
            #endregion
            
            Destroy(gameObject.transform.root.gameObject);
            /*Manca aggiungere energia alla barra del player*/
        }

        else if (collision.tag == "Floor")
        {
            Destroy(gameObject.transform.root.gameObject);
        }

        if (collision.tag == "Boss" && Boss.instance.canGetDamage == true)
        {
            ColorChangeController colorChangeController = collision.GetComponentInParent<ColorChangeController>();
            colorChangeController.isAttacked = true;
            AudioManager.instance.Play("Sfx_boss_damage_light");
            collision.GetComponentInParent<Boss>().life -= DamageArrow * collision.GetComponentInParent<Boss>().DMG_Reduction;         
            Destroy(gameObject.transform.root.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            Destroy(gameObject.transform.root.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            Destroy(gameObject.transform.root.gameObject);
        }
    }
}
