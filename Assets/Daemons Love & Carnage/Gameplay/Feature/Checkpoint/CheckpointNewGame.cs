using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordGame
{
    public class CheckpointNewGame : MonoBehaviour
    {
        public void CheckNewGame()
        {
            PlayerPrefs.GetInt("IDCheckpoint", -1);
            CheckpointManager.ContinueGame = false;
        }
    }
}
