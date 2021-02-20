using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwordGame
{
    [ExecuteInEditMode]
    public class PlayerManager : MonoBehaviour
    {
        #region Variables
        [Space(10)]
        [Header("Character Type Management")]
        [Tooltip("Permette di selezione la tipologia del player")]
        public TypePlayer TypeCharacter;
        #region Variables - Life System
        [Space(10)]
        [Header("Life System - Value Management")]
        [Space(20)]
        [Tooltip("Slider riferito alla vita nella UI")]
        public HealthBar HealthSlider;
        [Tooltip("Valore massimo della vita del player")]
        public int MaxHealth;
        [Tooltip("Valore corrente della vita del player, si setta al cambio della MaxHealth in inspector")]
        [ReadOnly] public int CurrentHealth;
        [Tooltip("Booleano che indica quando il player non può prendere danni")]
        [ReadOnly] public bool Invulnerability = false;
        #endregion
        #region Variables - Energy System
        [Space(10)]
        [Header("Energy System - Value Management")]
        [Space(20)]
        public Image EnergyBar;
        public int MaxEnergy;
        public static int MaxEnergyStatic;
        [ReadOnly] public int CurrentEnergy;
        #endregion
        #region Variables - Attack System
        [Space(10)]
        [Header("Attack System - Value Management")]
        [Space(20)]
        public int LightEnergyAmount;
        public int HeavyEnergyAmount;
        public int SpecialEnergyAmount;
        #endregion
        #region In caso servisse la life bar con un image
        //public Image LifeBar;
        //public int MaxLife;
        //public static int MaxLifeStatic;
        //public int CurrentLife;
        #endregion
        [ReadOnly] public bool isTriggerOnlyOnce = false;
        #endregion

        void OnValidate()
        {
            CurrentHealth = MaxHealth;
        }

        private void Start()
        {
            Initialize();
        }
        private void Update()
        {
            print("3. Current Life is" + CurrentHealth + "Nome " + gameObject.name);
            if (HealthSlider != null)
            {
                HealthSlider.sliderBar.value = CurrentHealth;
            }
            if (EnergyBar != null)
            {
                EnergyBar.fillAmount = (float)CurrentEnergy / 100;
            }
            //LifeBar.fillAmount = (float)CurrentLife / 100;      //temp
            if (CurrentHealth <= 0)
            {
                GetComponent<Animator>().SetBool("IsDie", true);
                //Destroy(this.gameObject);
                print("Hai Perso");
            }
            print("4. Current Life is" + CurrentHealth + "Nome " + gameObject.name);
        }

        #region Method

        public void Initialize()
        {
            //CurrentEnegy = PlayerPrefs.GetInt("EnergyValue", 0);
            if (EnergyBar != null)
                EnergyBar.fillAmount = (float)CurrentEnergy / 100;
            //LifeBar.fillAmount = (float)CurrentLife / 100;//temp
            //MaxEnergyStatic = MaxEnergy;
            print("1. Current Life is" + CurrentHealth + "Nome " + gameObject.name);
            if (HealthSlider != null)
                HealthSlider.SetHealth(CurrentHealth); //prendo il metodo dell'altro script e imposto sulla salute corrente
            print("2. Current Life is" + CurrentHealth + "Nome " + gameObject.name);
        }
        public void Refull()//Forse non serve
        {
            if (RefullLife.CanRefull == true)
            {
                //currentHealth = maxHealth;
                RefullLife.CanRefull = false;
            }
        }
        #endregion

        private void OnTriggerEnter2D(Collider2D collision)
        {
            #region PlayerLife
            if (Invulnerability == false && isTriggerOnlyOnce == false)
            {
                if (collision.tag == "LightAttack")
                {
                    isTriggerOnlyOnce = true;
                    GetComponent<PlayerController>().ResetTimerStaggered = 0;
                    GetComponent<PlayerController>().PoisePlayer += 1;                                  //aumenta di 1
                    CurrentHealth -= collision.GetComponentInParent<EnemyData>().LightDamage;
                    //CurrentLife -= collision.GetComponentInParent<EnemyManager>().LightDamage;
                    print("Colpito Light");
                    if (PlayerController.isBoriousDash == true)
                    {
                        collision.GetComponentInParent<EnemyData>().Life -= collision.GetComponentInParent<EnemyData>().LightDamage;
                    }
                }
                if (collision.tag == "HeavyAttack")
                {
                    isTriggerOnlyOnce = true;
                    GetComponent<PlayerController>().ResetTimerStaggered = 0;
                    GetComponent<PlayerController>().PoisePlayer += 1;                                  //aumenta di 1
                    CurrentHealth -= collision.GetComponentInParent<EnemyData>().HeavyDamage;
                    //CurrentLife -= collision.GetComponentInParent<EnemyManager>().HeavyDamage;
                    print("Colpito Heavy");
                    if (PlayerController.isBoriousDash == true)
                    {
                        collision.GetComponentInParent<EnemyData>().Life -= collision.GetComponentInParent<EnemyData>().HeavyDamage;
                    }
                }
                //if (collision.tag == "SpecialAttack")                     //I nemici non hanno l'attacco speciale
                //{
                //    GetComponent<PlayerController>().ResetTimerStaggered = 0;
                //    GetComponent<PlayerController>().PoisePlayer += 1;
                //    currentHealth -= collision.GetComponent<EnemyManager>().SpecialDamage;
                //    if (PlayerController.isBoriousDash == true)
                //    {
                //        collision.GetComponent<EnemyManager>().Life -= collision.GetComponent<EnemyManager>().SpecialDamage;
                //    }
                //}
                if (GetComponent<PlayerController>().PoisePlayer >= GetComponent<PlayerController>().MaxPoisePlayer)
                {
                    GetComponent<Animator>().SetBool("IsStagger", true);
                }
            }
            #endregion
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "LightAttack")
            {
                isTriggerOnlyOnce = false;
            }
            if (collision.tag == "HeavyAttack")
            {
                isTriggerOnlyOnce = false;
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
