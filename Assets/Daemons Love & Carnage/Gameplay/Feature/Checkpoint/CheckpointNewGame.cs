using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordGame
{
    public class CheckpointNewGame : MonoBehaviour
    {
        public void CheckNewGame()
        {
            print(PlayerPrefs.GetInt("IDCheckpoint", -1));
            print(CheckpointManager.ContinueGame);
        }
    }
}
