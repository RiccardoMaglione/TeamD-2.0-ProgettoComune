﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordGame
{
    public class PlayerArrow : MonoBehaviour
    {
        public int DamageArrow;
        public GameObject ArrowParent;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")                                                                           //Aggiungere booleano per DummyScript, PiecesBehaviour, manca HitAnimation 
            {
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
                collision.GetComponent<EnemyData>().GetComponent<Animator>().SetInteger("Life", collision.GetComponent<EnemyData>().Life);
                collision.GetComponent<Animator>().SetTrigger("DamageReceived");
                if (collision.GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponent<EnemyData>().MaxCountPoiseEnemy)
                {
                    collision.GetComponent<EnemyData>().GetComponent<Animator>().SetBool("IsStagger", true);
                }
                #endregion
                ChangeFollow.StaticPlayerTemp.GetComponentInParent<PSMController>().CurrentEnergy += ChangeFollow.StaticPlayerTemp.GetComponentInParent<PSMController>().LightEnergyAmount;
                Destroy(ArrowParent);
                /*Manca aggiungere energia alla barra del player*/
            }
        }
    }
}
