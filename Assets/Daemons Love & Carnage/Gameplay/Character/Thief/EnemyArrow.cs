﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordGame
{
    public class EnemyArrow : MonoBehaviour
    {
        public int DamageArrow;
        public int ValuePoiseArrow;
        public GameObject ArrowParent;

        public float thrust;
        public Vector3 KnockbackDirection;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce((transform.right + transform.InverseTransformDirection(KnockbackDirection)).normalized * thrust, ForceMode2D.Impulse);
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
            else if(collision.tag == "Floor")
            {
                Destroy(ArrowParent);
            }

        }
    }
}