using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordGame
{
    public class CheckpointManager : MonoBehaviour
    {
        public List<GameObject> ListCheckpoint = new List<GameObject>();

        public static bool ContinueGame;

        private void Awake()
        {
            for (int i = 0; i < ListCheckpoint.Count; i++)
            {
                ListCheckpoint[i].GetComponent<CheckpointController>().ID = i;
            }
        }

        private void Start()
        {
            if (PlayerPrefs.GetInt("IDCheckpoint", -1) > -1 && ContinueGame == true)
            {
                ContinueGame = false;
                ChangeFollow.CFInstance.NewPlayer.transform.position = ListCheckpoint[PlayerPrefs.GetInt("IDCheckpoint", 0)].transform.position;
            }
        }
    }
}