using UnityEngine;

namespace SwordGame
{
    public class GodMode : MonoBehaviour
    {
        public GameObject player;
        public HealthBar healthBar;

        public bool godModeActive = false;
        public GameObject TempPlayer;

        private void Update()
        {
            if(TempPlayer != ChangeFollow.StaticPlayerTemp)
            player = ChangeFollow.StaticPlayerTemp;
        }

        public void SetGodMode()
        {
            player.GetComponent<PSMController>().MaxHealth = 1000000;
            player.GetComponent<PSMController>().CurrentHealth = 1000000;

        }
    }

}
