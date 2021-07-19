using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordGame
{
    public class CheckpointNewGame : MonoBehaviour
    {
        public void CheckNewGame()
        {
            PlayerPrefs.SetInt("IDCheckpoint", -1);
            CheckpointManager.ContinueGame = false;
        }
    }
}
