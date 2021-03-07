using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordGame
{
    public class RangeAttack : MonoBehaviour
    {
        public static bool isMelee;
        public static bool isRanged;
    
        [Tooltip("Percentuale di attacco melee quando il player sta nel range melee")]
        public int OverridePercetuageMelee;                                                             //Override di percentuage attack - Default: PercentuageAttack - Max = 100

        [Tooltip("Percentuale di attacco ranged quando il player sta nel range ranged")]
        public int OverridePercetuageRanged;                                                            //Override di percentuage attack - Max = 0

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")                                                              //Se l'area di range collide con il player
            {
                if (tag == "RangeMelee")                                                                //Quando il player è nel range melee
                {
                    isMelee = true;
                    GetComponentInParent<EnemyData>().PercentuageAttack = OverridePercetuageMelee;      //Override della percentuale di attacco in quella melee
                }
                else if (tag == "RangeRanged" && isMelee == false)                                      //Quando il player è nel range ranged ma è fuori dal melee
                {
                    isRanged = true;
                    GetComponentInParent<EnemyData>().PercentuageAttack = OverridePercetuageRanged;     //Override della percentuale di attacco in quella ranged
                }
            }
        }

        private void Update()
        {
            print("Print range melee" + isMelee + "range ranged" + isRanged);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")                                                              //Se il player esce dall'area range
            {
                if (tag == "RangeMelee")                                                                //Se esce dall'area melee - Conseguenza: il range da melee viene passato a ranged
                {
                    isMelee = false;
                    if(isRanged == true && isMelee == false)                                            //Deve tornare alla percentuale ranged quando isMelee è falso e isRanged è true - Controllo per sicurezza isMelee - Controllo isRanged perché potrebbe non avere l'area ranged
                    {
                        GetComponentInParent<EnemyData>().PercentuageAttack = OverridePercetuageRanged; //Override della percentuale di attacco in quella ranged
                    }
                }
                else if (tag == "RangeRanged")                                                          //Se esce dall'area ranged
                {
                    isRanged = false;
                }
            }
        }
    
    }
}

//How to use: Mettere lo script sul collider range, sia melee e sia ranged