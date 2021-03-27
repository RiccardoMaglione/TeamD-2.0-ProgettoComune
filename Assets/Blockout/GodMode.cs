using UnityEngine;

namespace SwordGame
{
    public class GodMode : MonoBehaviour
    {
        public GameObject player;

        public bool godModeActive = false;

        public void SetGodMode()
        {
            player.GetComponent<PSMController>().MaxHealth = 1000000;

        }
    }

}
