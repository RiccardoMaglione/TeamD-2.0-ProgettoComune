using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwordGame
{
    public class Fade : MonoBehaviour
    {
        #region Variables
        public static Fade FadeInstance;                                                    //Creo un istanza statica richiamabile in altri script

        [Tooltip("Pannello usato per il fade")]
        public Image FadePanel;                                                             //Pannello usato per il fade
        [Tooltip("Tempo del fade in ingresso")]
        public float FadeInTime = 2;                                                        //Tempo del fade in ingresso
        [Tooltip("Tempo del fade in uscita")]
        public float FadeOutTime = 2;                                                       //Tempo del fade in uscita
        #endregion
    
        private void Awake()
        {
            FadeInstance = this;                                                            //Assegno l'istanza
        }
    
        void Start()
        {
            FadeOut();                                                                      //Richiamo il metodo di FadeOut
        }
    
        #region Method

        /// <summary>
        /// Fade di ingresso - A = Da 0 a 1
        /// </summary>
        public void FadeIn()
        {
            FadePanel.CrossFadeAlpha(1, FadeInTime, false);                                 //Rendo visibile il pannello del fade portando l'alpha a 1
        }

        /// <summary>
        /// Fade di uscita - A = Da 1 a 0
        /// </summary>
        public void FadeOut()
        {
            FadePanel.GetComponent<Image>().CrossFadeAlpha(0, FadeOutTime, false);          //Rendo invisibile il pannello del fade portando l'alpha a 0
        }

        /// <summary>
        /// Disattivazione del pannello di fade
        /// </summary>
        public void DeactiveFadePanel()
        {
            FadePanel.gameObject.SetActive(false);                                          //Disattivo il gameobject collegato alla immagine del pannello del fade
        }

        #endregion
    }
}