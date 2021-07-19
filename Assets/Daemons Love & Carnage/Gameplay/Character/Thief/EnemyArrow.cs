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
            if (collision.tag == "Player" && PSMController.isBoriousDash == false && collision.GetComponent<PSMController>().Invulnerability == false)
            {
                GetHitScript.getHitScript.gameObject.SetActive(false);
                GetHitScript.getHitScript.gameObject.SetActive(true);

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
                Destroy(ArrowParent, 0.2f);
                GetComponentInParent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;

                if (collision.GetComponent<PSMController>().CurrentHealth > 0)
                {
                    if (collision.GetComponent<PSMController>().TypeCharacter == TypePlayer.Babushka)
                    {
                        AudioManager.instance.Play("Sfx_B_hit");
                    }

                    if (collision.GetComponent<PSMController>().TypeCharacter == TypePlayer.BoriousKnight)
                    {
                        AudioManager.instance.Play("Sfx_BK_hit");
                    }

                    if (collision.GetComponent<PSMController>().TypeCharacter == TypePlayer.FatKnight)
                    {
                        AudioManager.instance.Play("Sfx_FK_hit");
                    }

                    if (collision.GetComponent<PSMController>().TypeCharacter == TypePlayer.Thief)
                    {
                        AudioManager.instance.Play("Sfx_T_hit");
                    }
                }
            }
            
            else if (collision.tag == "Floor")
            {
                Destroy(ArrowParent);
            }
        }
    }
}
