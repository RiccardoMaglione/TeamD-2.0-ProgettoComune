using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwordGame
{
    public class PlayerManager : MonoBehaviour
    {
        public TypePlayer TypeCharacter;

        public HealthBar hB;
        public int maxHealth;
        public int currentHealth;

        public Image EnergyBar;
        public int MaxEnergy;
        public static int MaxEnergyStatic;
        public int CurrentEnergy;

        [HideInInspector] public bool Invulnerability = false;

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            //CurrentEnegy = PlayerPrefs.GetInt("EnergyValue", 0);
            EnergyBar.fillAmount = (float)CurrentEnergy / 100;;
            //MaxEnergyStatic = MaxEnergy;

            hB.SetHealth(currentHealth); //prendo il metodo dell'altro script e imposto sulla salute corrente
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            #region PlayerLife
            if(Invulnerability == false)
            {
                if (collision.tag == "LightAttack")
                {
                    currentHealth -= collision.GetComponent<EnemyManager>().LightDamage;
                    if(PlayerController.isBoriousDash == true)
                    {
                        collision.GetComponent<EnemyManager>().Life -= collision.GetComponent<EnemyManager>().LightDamage;
                    }
                }
                if (collision.tag == "HeavyAttack")
                {
                    currentHealth -= collision.GetComponent<EnemyManager>().HeavyDamage;
                    if (PlayerController.isBoriousDash == true)
                    {
                        collision.GetComponent<EnemyManager>().Life -= collision.GetComponent<EnemyManager>().HeavyDamage;
                    }
                }
                if (collision.tag == "SpecialAttack")
                {
                    currentHealth -= collision.GetComponent<EnemyManager>().SpecialDamage;
                    if (PlayerController.isBoriousDash == true)
                    {
                        collision.GetComponent<EnemyManager>().Life -= collision.GetComponent<EnemyManager>().SpecialDamage;
                    }
                }
            }
            #endregion
        }

        public void Refull()
        {
            if(RefullLife.CanRefull == true)
            {
                currentHealth = maxHealth;
                RefullLife.CanRefull = false;
            }
        }
    }

    public enum TypePlayer
    {
        FatKnight,
        BoriousKnight,
        Babushka,
        Thief
    }
}
