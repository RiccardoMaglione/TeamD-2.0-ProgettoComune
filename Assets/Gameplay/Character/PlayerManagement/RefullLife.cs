using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;
namespace SwordGame
{
    public class RefullLife : MonoBehaviour
    {
        public static bool CanRefull;
        private void Update()
        {
            for (int i = 0; i < ReturnPlayer.LastDetectList.Count; i++)
            {
                if(ReturnPlayer.LastDetectList[i] == PossessionV2.ThisCharacter)
                {
                    print("Non refullare" + ReturnPlayer.LastDetectList[i].name);
                    CanRefull = true;
                }
            }
        }
    }
}
