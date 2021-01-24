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
        public static GameObject PlayerNow;
        public static List<GameObject> LastDetectList = new List<GameObject>();
        public List<GameObject> LastDetectListInspector = new List<GameObject>();
        #endregion
        void Update()
        {
            
            LastDetectListInspector = LastDetectList;
            timerDestroyInspector = timerDestroy;

            if(CanDestroy == true)
            {
                timerDestroy += Time.deltaTime;
                if(timerDestroy >= timerLimit)
                {
                    for (int i = 0; i < LastDetectList.Count; i++)
                    {
                        if(LastDetectList[i] != PlayerNow)
                        {
                            Destroy(LastDetectList[i]);
                        }
                    }
                    timerDestroy = timerLimit;
                    CanDestroy = false;
                }
            }
            if (LastDetectList.Count - 1 > 0 && LastDetectList[LastDetectList.Count - 1] != null && LastDetectList[LastDetectList.Count - 1].tag == "Player")
            {
                timerDestroy = 0;
                CanDestroy = false;
            }
        }
    }
}

