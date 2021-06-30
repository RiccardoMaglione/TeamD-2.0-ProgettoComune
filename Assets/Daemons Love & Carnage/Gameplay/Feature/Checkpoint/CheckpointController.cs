using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordGame
{
    public class CheckpointController : MonoBehaviour
    {
        public static CheckpointController CCInstance;

        [HideInInspector] public int ID;
        
        public static GameObject LastCheckpoint;
        [HideInInspector] public GameObject InspectorLastCheckpoint;

        public static TypePlayer PlayerCheckpoint;
        [HideInInspector] public TypePlayer InspectorPlayerCheckpoint;

        [Tooltip("Numeri di nemici uccisi")] public int KilledEnemy;

        public List<GameObject> ActivateGameObject = new List<GameObject>();
        public List<GameObject> DeactivateGameObject = new List<GameObject>();

        public GameObject FatKnight;
        public GameObject BoriousKnight;
        public GameObject Babushka;
        public GameObject Thief;

        public static bool StartRespawn = false;

        public GameObject SpawnPointCheck;

        private void Awake()
        {
            CCInstance = this;
            StartRespawn = true;
        }

        private void Update()
        {
            if (StartRespawn == true && CheckpointManager.ContinueGame == true)
            {
                InitialiRespawn();
            }
            
            InspectorPlayerCheckpoint = PlayerCheckpoint;
            InspectorLastCheckpoint = LastCheckpoint;

            RespawnInScene();
        }

        public void RespawnInScene()
        {
            if (Input.GetKeyDown(KeyCode.R) && LastCheckpoint == gameObject)
            {

                Debug.Log("<color=lime> Respawn player all'ultimo checkpoint </color>");
                ChangeFollow.CFInstance.NewPlayer.transform.position = SpawnPointCheck.transform.position;

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
                        ActivateGameObject[i].SetActive(true);
                    }
                }
            }
        }
        public void InitialiRespawn()
        {
            print(LastCheckpoint);
            if (LastCheckpoint != null && LastCheckpoint == gameObject)
            {
                StartRespawn = false;
                Debug.Log("<color=lime> Respawn player all'ultimo checkpoint </color>");
                Destroy(ChangeFollow.CFInstance.NewPlayer);
                switch (PlayerCheckpoint)
                {
                    case TypePlayer.FatKnight:
                        GameObject NewFatKnight = Instantiate(FatKnight, SpawnPointCheck.transform.position, Quaternion.identity);
                        ChangeFollow.CFInstance.NewPlayer = NewFatKnight;
                        break;
                    case TypePlayer.BoriousKnight:
                        GameObject NewBoriousKnight = Instantiate(FatKnight, SpawnPointCheck.transform.position, Quaternion.identity);
                        ChangeFollow.CFInstance.NewPlayer = NewBoriousKnight;
                        break;
                    case TypePlayer.Babushka:
                        GameObject NewBabushka = Instantiate(FatKnight, SpawnPointCheck.transform.position, Quaternion.identity);
                        ChangeFollow.CFInstance.NewPlayer = NewBabushka;
                        break;
                    case TypePlayer.Thief:
                        GameObject NewThief = Instantiate(FatKnight, SpawnPointCheck.transform.position, Quaternion.identity);
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
                        ActivateGameObject[i].SetActive(true);
                    }
                }

                KilledEnemyCounter.KilledEnemyCounterInstance.killedEnemyCounter = KilledEnemy;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                Debug.Log("<color=fuchsia> Checkpoint Attivato </color>");
                PlayerCheckpoint = collision.gameObject.GetComponent<PSMController>().TypeCharacter;
                LastCheckpoint = gameObject;
                PlayerPrefs.SetInt("IDCheckpoint", ID);
                print(PlayerPrefs.GetInt("IDCheckpoint", 0));
            }
        }
    }
}

