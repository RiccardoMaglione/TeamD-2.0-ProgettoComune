using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordGame
{
    public class PlayerArrow : MonoBehaviour
    {
        public int DamageArrow;
        public GameObject ArrowParent;

        public float thrust;
        public Vector3 KnockbackDirection;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")                                                                           //Aggiungere booleano per DummyScript, PiecesBehaviour, manca HitAnimation 
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce((transform.right + transform.InverseTransformDirection(KnockbackDirection)).normalized * thrust, ForceMode2D.Impulse);
                ColorChangeController colorChangeController = collision.GetComponent<ColorChangeController>();
                colorChangeController.isAttacked = true;

                /*Aggiungere HitAnimation*/

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
                if(ThiefSpecialAttack.instance.isSpecialActive == false)
                {
                    if (ChangeFollow.StaticPlayerTemp.GetComponentInParent<PSMController>().CurrentEnergy + ChangeFollow.StaticPlayerTemp.GetComponentInParent<PSMController>().LightEnergyAmount > ChangeFollow.StaticPlayerTemp.GetComponentInParent<PSMController>().MaxEnergy)
                    {
                        ChangeFollow.StaticPlayerTemp.GetComponentInParent<PSMController>().CurrentEnergy = ChangeFollow.StaticPlayerTemp.GetComponentInParent<PSMController>().MaxEnergy;
                        if (AudioManager.instance != null && AttackSystem.SoundOnlyOnceEnergy == false)
                        {
                            AudioManager.instance.Play("Sfx_special_bar_fill");
                            AttackSystem.SoundOnlyOnceEnergy = true;
                        }
                    }
                    else
                    {
                        ChangeFollow.StaticPlayerTemp.GetComponentInParent<PSMController>().CurrentEnergy += ChangeFollow.StaticPlayerTemp.GetComponentInParent<PSMController>().LightEnergyAmount;
                    }
                }
                Destroy(ArrowParent);
                /*Manca aggiungere energia alla barra del player*/
            }

            else if(collision.tag == "Floor")
            {
                Destroy(ArrowParent);
            }

            if(collision.tag == "Boss")
            {
                collision.GetComponentInParent<Boss>().life -= DamageArrow * collision.GetComponentInParent<Boss>().DMG_Reduction;
                if (ThiefSpecialAttack.instance.isSpecialActive == false)
                {
                    if (ChangeFollow.StaticPlayerTemp.GetComponentInParent<PSMController>().CurrentEnergy + ChangeFollow.StaticPlayerTemp.GetComponentInParent<PSMController>().LightEnergyAmount > ChangeFollow.StaticPlayerTemp.GetComponentInParent<PSMController>().MaxEnergy)
                    {
                        ChangeFollow.StaticPlayerTemp.GetComponentInParent<PSMController>().CurrentEnergy = ChangeFollow.StaticPlayerTemp.GetComponentInParent<PSMController>().MaxEnergy;
                        if (AudioManager.instance != null && AttackSystem.SoundOnlyOnceEnergy == false)
                        {
                            AudioManager.instance.Play("Sfx_special_bar_fill");
                            AttackSystem.SoundOnlyOnceEnergy = true;
                        }
                    }
                    else
                    {
                        ChangeFollow.StaticPlayerTemp.GetComponentInParent<PSMController>().CurrentEnergy += ChangeFollow.StaticPlayerTemp.GetComponentInParent<PSMController>().LightEnergyAmount;
                    }
                }
                Destroy(ArrowParent);
            }            
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == "Floor")
            {
                Destroy(ArrowParent);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Floor")
            {
                Destroy(ArrowParent);
            }
        }
    }
}
