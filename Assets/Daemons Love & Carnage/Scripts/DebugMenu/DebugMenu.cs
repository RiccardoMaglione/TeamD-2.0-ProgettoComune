using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SwordGame
{
    public class DebugMenu : MonoBehaviour
    {
        private void Start()
        {
            EnableTutorial();
        }

        #region Scene
        public void ReloadScene(string NameScene)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(NameScene);
        }
        #endregion

        #region Invulnerability
        public void Invulnerability()
        {
            GameObject Player = ChangeFollow.StaticPlayerTemp;
            Player.GetComponent<PSMController>().MaxHealth = float.MaxValue;
            Player.GetComponent<PSMController>().CurrentHealth = float.MaxValue;
        }
        #endregion

        #region Boss
        [SerializeField] GameObject[] cameras;
        [SerializeField] GameObject[] cameraConfiners;
        [SerializeField] GameObject Enemies0;
        [SerializeField] GameObject graphicsToEnable1;
        [SerializeField] GameObject graphicsToEnable2;

        public void GoToBoss()
        {
            GameObject Player = ChangeFollow.StaticPlayerTemp;

            if (Enemies0 != null)
                Enemies0.SetActive(false);
            
            for (int i = 0; i < cameraConfiners.Length; i++)
            {
                if (i < 22)
                    cameraConfiners[i].SetActive(false);
                if (i == 22)
                {
                    cameraConfiners[22].SetActive(true);
                }
            }
            for (int i = 0; i < cameras.Length; i++)
            {
                if (i < 22)
                    cameras[i].SetActive(false);
                if (i == 22)
                {
                    cameras[22].SetActive(true);
                }
            }

            Player.transform.position = new Vector2(528, 27);
            graphicsToEnable1.SetActive(true);
            graphicsToEnable2.SetActive(true);
        }
        #endregion

        #region Tutorial
        public GameObject tutorialTrigger;

        public void EnableTutorial()
        {
            if (PlayerPrefs.GetInt("DisableTutorial") == 1)
            {
                DialogueType1.StaticTutorial = 7;
                DialogueType1.StaticTutorial2 = 7;
                tutorialTrigger.SetActive(false);
            }
            else
            {
                tutorialTrigger.SetActive(true);
            }
        }
        public void DisableTutorial()
        {
            if (PlayerPrefs.GetInt("DisableTutorial") == 0)
            {
                DialogueType1.StaticTutorial = 7;
                DialogueType1.StaticTutorial2 = 7;
                PlayerPrefs.SetInt("DisableTutorial", 1);
            }
            else
            {
                PlayerPrefs.SetInt("DisableTutorial", 0);
            }

        }
        #endregion

        #region Energy
        public void Energy()
        {
            GameObject Player = ChangeFollow.StaticPlayerTemp;
            Player.GetComponent<PSMController>().CurrentEnergy = int.MaxValue;
        }
        #endregion

        #region Enemy
        public void CountEnemy()
        {
            FindObjectOfType<KilledEnemyCounter>().killedEnemyCounter = int.MaxValue;
        }

        public GameObject EnemyContainer;

        public void KilledEnemy()
        {
            Destroy(EnemyContainer);
        }
        #endregion
    }
}
