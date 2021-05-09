using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordGame
{
    public class EnemyArrow : MonoBehaviour
    {
        public int DamageArrow;
        public int ValuePoiseArrow;
        public GameObject ArrowParent;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<PSMController>().ResetTimerStaggered = 0;
                collision.GetComponent<PSMController>().PoisePlayer += ValuePoiseArrow;
                collision.GetComponent<PSMController>().CurrentHealth -= (int)(DamageArrow * collision.GetComponent<PSMController>().CoeffReduceDamageLight);
                Knockback.ActiveKnockback = true;
                StartCoroutine(FeedbackManager.instance.Vibration());
                if (collision.GetComponent<PSMController>().PoisePlayer >= collision.GetComponent<PSMController>().MaxPoisePlayer)
                {
                    collision.GetComponent<PSMController>().GetComponent<Animator>().SetBool("PSM-IsStagger", true);
                }
                Destroy(ArrowParent);
            }

        }
    }
}