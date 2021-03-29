using System.Collections.Generic;
using UnityEngine;

namespace SwordGame
{
    public class Knockback : MonoBehaviour
    {
        public float thrust;                                              //Spinta aggiuntiva
        public List<Rigidbody2D> RB2DList = new List<Rigidbody2D>();    //Lista rigidbody nemici nel trigger
        public static bool ActiveKnockback;                             //Variabile che indica quando attivare l'impulso
        [Tooltip("Davanti del player + Vettore direzione local")]
        public Vector3 KnockbackDirection;

        void Update()
        {
            if (ActiveKnockback == true)                                                //Se la variabile è attiva vuol dire che il player sta attaccando
            {
                ActiveKnockback = false;                                                //Setta a falso per evitare possibili danni multipli
                foreach (Rigidbody2D item in RB2DList)                                  //Per ogni oggetti nella lista dei rigidbody nemici
                {
                    print("Normallize" + ((transform.right + transform.InverseTransformDirection(KnockbackDirection).normalized)));
                    item.AddForce((transform.right + transform.InverseTransformDirection(KnockbackDirection)).normalized * thrust, ForceMode2D.Impulse);       //All'oggetto si aggiunge una forza di tipologia impulso per affligere un knockback verso il davanti del player
                }
            }
        }

        /// <summary>
        /// Quando il nemico entra nell'area del trigger dell'attacco con knockback viene aggiunto ad una lista
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
                RB2DList.Add(collision.GetComponent<Rigidbody2D>());
            }
        }

        /// <summary>
        /// Quando il nemico esce dall'area del trigger dell'attacco con knockback viene rimosso dalla lista
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
                RB2DList.Remove(collision.GetComponent<Rigidbody2D>());
            }
        }
    }
}
