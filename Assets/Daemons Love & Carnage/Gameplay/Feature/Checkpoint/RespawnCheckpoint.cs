using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordGame
{
    public class RespawnCheckpoint : MonoBehaviour
    {
        public GameObject FatKnight;
        public GameObject BoriousKnight;
        public GameObject Babushka;
        public GameObject Thief;

        [HideInInspector] public GameObject InitialPlayer;

        public List<GameObject> ActivateGameObject = new List<GameObject>();
        public List<GameObject> DeactivateGameObject = new List<GameObject>();

        private void Start()
        {
            InitialiRespawn();
        }

        void Update()
        {
            RespawnInScene();
        }

        public void RespawnInScene()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("<color=lime> Respawn player all'ultimo checkpoint </color>");
                ChangeFollow.CFInstance.NewPlayer.transform.position = CheckpointController.LastCheckpoint.transform.position;

                for (int i = 0; i < DeactivateGameObject.Count; i++)
                {
                    if(DeactivateGameObject[i] != null)
                    {
                        DeactivateGameObject[i].SetActive(false);
                    }
                }
                for (int i = 0; i < ActivateGameObject.Count; i++)
                {
                    if (ActivateGameObject[i] != null)
                    {
                        ActivateGameObject[i].SetActive(false);
                    }
                }
            }
        }

        public void InitialiRespawn()
        {
            if(CheckpointController.LastCheckpoint != null)
            {
                Debug.Log("<color=lime> Respawn player all'ultimo checkpoint </color>");
                Destroy(ChangeFollow.CFInstance.NewPlayer);
                switch (CheckpointController.PlayerCheckpoint)
                {
                    case TypePlayer.FatKnight:
                        GameObject NewFatKnight = Instantiate(FatKnight, CheckpointController.LastCheckpoint.transform.position, Quaternion.identity);
                        ChangeFollow.CFInstance.NewPlayer = NewFatKnight;
                        break;
                    case TypePlayer.BoriousKnight:
                        GameObject NewBoriousKnight = Instantiate(FatKnight, CheckpointController.LastCheckpoint.transform.position, Quaternion.identity);
                        ChangeFollow.CFInstance.NewPlayer = NewBoriousKnight;
                        break;
                    case TypePlayer.Babushka:
                        GameObject NewBabushka = Instantiate(FatKnight, CheckpointController.LastCheckpoint.transform.position, Quaternion.identity);
                        ChangeFollow.CFInstance.NewPlayer = NewBabushka;
                        break;
                    case TypePlayer.Thief:
                        GameObject NewThief = Instantiate(FatKnight, CheckpointController.LastCheckpoint.transform.position, Quaternion.identity);
                        ChangeFollow.CFInstance.NewPlayer = NewThief;
                        break;
                    default:
                        break;
                }

                ChangeFollow.CFInstance.NewPlayer.GetComponent<PSMController>().HealthSlider = HealthBar.HBInstance;
                ChangeFollow.CFInstance.NewPlayer.GetComponent<PSMController>().EnergySliderPM = EnergyBar.EBInstance;

                for (int i = 0; i < DeactivateGameObject.Count; i++)
                {
                    if (DeactivateGameObject[i] != null)
                    {
                        DeactivateGameObject[i].SetActive(false);
                    }
                }
                for (int i = 0; i < ActivateGameObject.Count; i++)
                {
                    if (ActivateGameObject[i] != null)
                    {
                        ActivateGameObject[i].SetActive(false);
                    }
                }
            }
        }
    }
}

