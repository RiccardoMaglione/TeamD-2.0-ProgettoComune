using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordGame
{
    public class ReturnPlayer : MonoBehaviour
    {
        #region Variables
        [Header("Timer Management")]
        [Tooltip("ViewOnly - It's a timer from 0 to timerLimit")]
        public float timerDestroyInspector;
        [Tooltip("It's a limit for the timer for destroy the last player")]
        public float timerLimit = 5;
        public static float timerDestroy;
        public static bool CanDestroy = false;
        public static GameObject LastDetect;
        #endregion
        void Update()
        {
            timerDestroyInspector = timerDestroy;
            if(CanDestroy == true)
            {
                timerDestroy += Time.deltaTime;
                if(timerDestroy >= timerLimit)
                {
                    Destroy(LastDetect);
                    timerDestroy = timerLimit;
                    CanDestroy = false;
                }
            }
            if (LastDetect != null && LastDetect.tag == "Player")
            {
                timerDestroy = 0;
                CanDestroy = false;
            }
        }

    }
}

