using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SwordGame
{
    public class AggroPortable : MonoBehaviour
    {
        [ReadOnly] public GameObject PlayerAggroPortable;                               //GameObject che conterrà il player identificato

        private void OnDisable()
        {
            PlayerAggroPortable = null;                                                 //Setto il PlayerAggroPortable uguale a null
        }

        /// <summary>
        /// Setto vari parametri per rendere vera o falsa lo stato di following
        /// </summary>
        /// <param name="CanVisible"></param>
        /// <param name="isFollowing"></param>
        /// <param name="CanReset"></param>
        public void SetFollowing(bool CanVisible, bool isFollowing, bool CanReset)
        {
            if (GetComponentInParent<EnemyData>() != null)
                GetComponentInParent<EnemyData>().CanVisible = CanVisible;                  //Setto la variabile CanVisible uguale alla variabile locale CanVisible
            if (GetComponentInParent<Animator>() != null)
                GetComponentInParent<Animator>().SetBool("IsFollowing", isFollowing);       //Setto il parametro IsFollowing uguale alla variabile locale IsFollowing
            if (GetComponentInParent<EnemyData>() != null)
                GetComponentInParent<EnemyData>().CanReset = CanReset;                      //Setto la variabile CanReset uguale alla variabile locale CanReset
        }

        /// <summary>
        /// Trigger di entrata usato per detectare il player dentro il collider usato come aggro
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")                                              //Se l'oggetto colliso è il player
            {
                PlayerAggroPortable = collision.gameObject;                             //Setto il PlayerAggroPortable uguale all'oggetto colliso
                SetFollowing(true, true, false);                                        //Richiamo il metodo
            }
        }

        /// <summary>
        /// Trigger stazionario usato per mantenere la referenza del player
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == "Player")                                               //Se l'oggetto colliso è il player
            {
                PlayerAggroPortable = collision.gameObject;                             //Setto il PlayerAggroPortable uguale all'oggetto colliso
                GetComponentInParent<EnemyData>().PlayerEnemy = PlayerAggroPortable;    //Setto il PlayerEnemy uguale al PlayerAggroPortable
                SetFollowing(true, true, false);                                        //Richiamo il metodo
            }
        }

        /// <summary>
        /// Trigger di uscita usato per resettare i valori
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")                                              //Se l'oggetto colliso è il player
            {
                SetFollowing(false, false, true);                                       //Richiamo il metodo
                if (GetComponentInParent<EnemyData>() != null)
                {
                    GetComponentInParent<EnemyData>().PlayerEnemy = null;               //Setto il PlayerEnemy uguale a null
                    GetComponentInParent<EnemyData>().CanMove = true;                   //Rendo vero CanMove per farlo ritornare a muovere normalmente
                }
                PlayerAggroPortable = null;                                             //Setto il PlayerAggroPortable uguale a null
            }
        }
    }
}