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
        public float timerLimit = 5; //deve essere uguale al tempo di stun
        public static float timerDestroy;

        public static List<float> TimerDestroyList = new List<float>();
        public List<float> TimerDestroyListInspector = new List<float>();

        public static List<bool> CanDestroyList = new List<bool>();
        public List<bool> CanDestroyInspector = new List<bool>();

        public static bool CanDestroy = false;
        public static GameObject PlayerNow;
        public static List<GameObject> LastDetectList = new List<GameObject>();
        public List<GameObject> LastDetectListInspector = new List<GameObject>();
        #endregion
        void Update()
        {
            LastDetectListInspector = LastDetectList;
            timerDestroyInspector = timerDestroy;

            TimerDestroyListInspector = TimerDestroyList;
            CanDestroyInspector = CanDestroyList;

            for (int i = 0; i < LastDetectList.Count; i++)
            {
                if(CanDestroyList[i] == true)
                {
                    TimerDestroyList[i] += Time.deltaTime;
                    if(TimerDestroyList[i] >= timerLimit)
                    {
                        if(LastDetectList[i] != PlayerNow)
                        {
                            //print("ForseQua");
                            LastDetectList[i].GetComponent<Animator>().SetTrigger("IsDeath");
                            //Destroy(LastDetectList[i]);
                        }
                        TimerDestroyList[i] = timerLimit;
                        CanDestroyList[i] = false;
                    }
                }
            }
            if (LastDetectList.Count - 1 > 0 && LastDetectList[LastDetectList.Count - 1] != null && LastDetectList[LastDetectList.Count - 1].tag == "Player")
            {
                //timerDestroy = 0;
                //CanDestroy = false;
                TimerDestroyList[TimerDestroyList.Count - 1] = 0;
                CanDestroyList[CanDestroyList.Count - 1] = false;
            }
        }
    }
}

