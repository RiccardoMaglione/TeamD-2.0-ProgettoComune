using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwordGame
{
    public class ScoreSystem : MonoBehaviour
    {
        public float[] ScoreBoss;
        public float[] ScoreEnemy;
    
        public float Score;
        public int Rank = 1;

        [HideInInspector] public bool SpecialType;

        public Text ScoreText;

        private void Update()
        {
            ScoreText.text = "Score: " + Score.ToString();
        }

        /// <summary>
        /// Metodo utilizzabile per assegnare lo score quando un nemico muore o anche quando viene posseduto
        /// </summary>
        /// <param name="ID"> Corrisponde alla variabile dell'enum del nemico convertita in int </param>
        /// <param name="TypeAttackMultiplier"> Variabile per identificare la tipologia di attacco, utilizzato per la differenzazione special </param>
        public void ScoreAssignedEnemyDestroy(int ID, int TypeAttackMultiplier)
        {
            Score += ScoreEnemy[ID] * Rank * TypeAttackMultiplier;
            ScoreText.text = "Score: " + Score.ToString();
        }

        /// <summary>
        /// Metodo utilizzabile per assegnare lo score quando un boss muore
        /// </summary>
        /// <param name="ID"> Corrisponde alla variabile dell'enum del nemico convertita in int </param>
        /// <param name="TypeAttackMultiplier"> Variabile per identificare la tipologia di attacco, utilizzato per la differenzazione special </param>
        public void ScoreAssignedBossDestroy(int ID, int TypeAttackMultiplier)
        {
            Score += ScoreBoss[ID] * Rank * TypeAttackMultiplier;
            ScoreText.text = "Score: " + Score.ToString();
        }
    }
}