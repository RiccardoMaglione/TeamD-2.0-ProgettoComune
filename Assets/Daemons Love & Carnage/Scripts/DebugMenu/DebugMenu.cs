using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SwordGame
{
    public class DebugMenu : MonoBehaviour
    {
        public KeyCode KeyDebugMenu;

        private void Start()
        {
            EnableTutorial();
        }

        private void Update()
        {
            OpenCloseMenu();
        }

        #region Scene
        public void ReloadScene(string NameScene)
        {
            PlayerPrefs.SetInt("IDCheckpoint", -1);
            CheckpointManager.ContinueGame = false;
            Time.timeScale = 1;
            SceneManager.LoadScene(NameScene);
        }
        #endregion

        #region GodMode
        public void GodMode()
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

        public void ResetTutorial()
        {
            PlayerPrefs.SetInt("TutorialSkip", 0);
            PlayerPrefs.SetInt("TutorialSkipEnergy", 0);
            TutorialEnergy.TutorialEnergyInstance.TutorialEnergyBool = false;
        }
        #endregion

        #region Energy
        public void Energy()
        {
            GameObject Player = ChangeFollow.StaticPlayerTemp;
            Player.GetComponent<PSMController>().CurrentEnergy = Player.GetComponent<PSMController>().MaxEnergy;
        }
        #endregion

        #region Enemy
        public void CountEnemy()
        {
            FindObjectOfType<KilledEnemyCounter>().killedEnemyCounter = 10000;
        }

        public GameObject EnemyContainer;

        public void KilledEnemy()
        {
            Destroy(EnemyContainer);
        }
        #endregion

        public GameObject DebugMenuPanel;

        public void OpenCloseMenu()
        {
            if (Input.GetKeyDown(KeyDebugMenu) && DebugMenuPanel.activeSelf == false)
            {
                DebugMenuPanel.SetActive(true);
                Cursor.visible = true;
            }
            else if (Input.GetKeyDown(KeyDebugMenu) && DebugMenuPanel.activeSelf == true)
            {
                DebugMenuPanel.SetActive(false);
                Cursor.visible = false;
            }
        }
    }
}
