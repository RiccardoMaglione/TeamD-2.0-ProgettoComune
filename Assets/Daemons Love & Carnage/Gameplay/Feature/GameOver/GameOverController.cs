using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SwordGame
{
    public class GameOverController : MonoBehaviour
    {
        #region Variables
        int RndScreen;                                                                                  //Valore che verrà definito nel random

        [Space(5)]
        [Header("-------------------------- Gestione dei pannelli del Game Over -------------------------------------")]
        [Tooltip("Lista delle possibili varianti del pannello di gameover")]
        public List<GameObject> ListScreen = new List<GameObject>();                                    //Lista delle possibili varianti del pannello di gameover

        [Space(5)]
        [Header("-------------------------- Gestione dei pulsanti ---------------------------------------------------")]
        [Tooltip("Pannello contenente i bottoni")]
        public GameObject ButtonScreen;                                                                 //Pannello contenente i bottoni
        [Tooltip("Tempo di attesa per il richiamo del pannello dei bottoni")]
        public float TimerInvokeButton;                                                                 //Tempo di attesa per il richiamo del pannello dei bottoni, senza contare il fade

        [Space(5)]
        [Header("-------------------------- Temp - Variabili inerenti il caricamento --------------------------------")]
        [Tooltip("Lista degli sprite del caricamento")]
        public List<Sprite> ListEye = new List<Sprite>();                                               //Lista degli sprite del caricamento
        [Tooltip("Lista delle immagini base da sostituire la sprite")]
        public List<Image> ImageEye;                                                                    //Lista delle immagini base da sostituire la sprite
        [Tooltip("Tempo di attesa tra una sprite e l'altra")]
        public float TimerEye;                                                                          //Tempo di attesa tra una sprite e l'altra
        #endregion

        void Start()
        {
            StartCoroutine(AnimationEye());                                                             //Parte la coroutine dell'animazione dell'occhio
            RandomScreenGameOver();                                                                     //Richiama il metodo per scegliere il random della schermata del gameover
            StartCoroutine(ScreenDeactive());                                                           //Parte la coroutine del fade
        }

        #region Method

        /// <summary>
        /// Viene attivata tramite un random un pannello casuale del gameover
        /// </summary>
        public void RandomScreenGameOver()
        {
            RndScreen = Random.Range(0, ListScreen.Count);                                              //Estraggo un numero random tra 0 e il massimo della lista dei pannelli del gameover
            ListScreen[RndScreen].SetActive(true);                                                      //Attivo il pannello che ha come indice il random
        }

        /// <summary>
        /// Carica la scena in base al nome
        /// </summary>
        /// <param name="NameScene">Nome della scena</param>
        public void ReturnMenu(string NameScene)
        {
            SceneManager.LoadScene(NameScene);                                                          //Carica la scena definita dal nome nella stringa NameScene
        }

        /// <summary>
        /// Viene ricaricata la scena di gameover
        /// </summary>
        public void ReloadScene()
        {
            SceneManager.LoadScene("GameOver");                                                         //Ricarica la scena di gameover
        }

        #endregion

        #region Coroutine

        /// <summary>
        /// Coroutine temporanea per l'animazione dell'occhio per il caricamento
        /// </summary>
        /// <returns></returns>
        public IEnumerator AnimationEye()
        {
            while (true)                                                                                //Mentre è attivo
            {
                for (int i = 0; i < ListEye.Count; i++)                                                 //Per la lungezza della lista ListEye
                {
                    ImageEye[RndScreen].sprite = ListEye[i];                                            //Sostituisco lo sprite
                    yield return new WaitForSeconds(TimerEye);                                          //Aspetto il tempo TimerEye per passare allo sprite successivo
                }
            }
        }

        /// <summary>
        /// Coroutine per il processo di fade tra il gameover e il button screen
        /// </summary>
        /// <returns></returns>
        public IEnumerator ScreenDeactive()
        {
            yield return new WaitForSeconds(Fade.FadeInstance.FadeOutTime + TimerInvokeButton);         //Aspetto il tempo di fade out più il tempo di invoke del button screen
            Fade.FadeInstance.FadeIn();                                                                 //Richiamo il fade in
            yield return new WaitForSeconds(Fade.FadeInstance.FadeInTime);                              //Aspetto il tempo di fade in
            ListScreen[RndScreen].SetActive(false);                                                     //Disattivo il pannello random di gameover
            Fade.FadeInstance.FadeOut();                                                                //Richiamo il fade out
            ButtonScreen.SetActive(true);                                                               //Attivo il button screen
            if (AudioManager.instance != null)
                AudioManager.instance.Play("Sfx_You_Died");
            yield return new WaitForSeconds(Fade.FadeInstance.FadeOutTime);                             //Aspetto il tempo di fade out
            Fade.FadeInstance.DeactiveFadePanel();                                                      //Richiamo la disattivazione del pannello di fade
        }

        #endregion

        public void ContinueCheckpointYes()
        {
            if (PlayerPrefs.GetInt("IDCheckpoint", -1) > -1)
            {
                CheckpointManager.ContinueGame = true;
            }
            else
            {
                CheckpointManager.ContinueGame = false;
                PlayerPrefs.SetInt("IDCheckpoint", -1);
            }
        }
        public void ContinueCheckpointNo()
        {
            CheckpointManager.ContinueGame = false;
            PlayerPrefs.SetInt("IDCheckpoint", -1);
        }
    }
}
