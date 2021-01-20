using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordGame
{
    [RequireComponent(typeof(PlayerController))]
    public class Possession : MonoBehaviour
    {
        //public Collider2D[] collidersEnemy2D;
        [Header("Press P for Possession the closest enemy")]
        public PlayerController[] gos;
        void Update()
        {
            #region Metodo 1 - Possession Click Mouse
            /*if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.GetComponent<PlayerController>() != null)
                    {
                        hit.collider.gameObject.GetComponent<PlayerController>().enabled = true;
                        this.gameObject.GetComponent<PlayerController>().enabled = false;

                        hit.collider.gameObject.GetComponent<Possession>().enabled = true;
                        this.gameObject.GetComponent<Possession>().enabled = false;
                    }
                }
            }*/
            #endregion
            #region Metodo 2 - Overlap ma non detecta il più vicino
            /*if (Input.GetKeyDown(KeyCode.P))
            {
                collidersEnemy2D = Physics2D.OverlapCircleAll(this.transform.position, 50);
                foreach (var colliderEnemy2D in collidersEnemy2D)
                {
                    if (colliderEnemy2D.GetComponent<PlayerController>() != null && colliderEnemy2D.gameObject != this.gameObject)
                    {
                        colliderEnemy2D.gameObject.GetComponent<PlayerController>().enabled = true;
                        this.gameObject.GetComponent<PlayerController>().enabled = false;
                
                        colliderEnemy2D.gameObject.GetComponent<Possession>().enabled = true;
                        this.gameObject.GetComponent<Possession>().enabled = false;
                
                        //for (int i = 0; i < collidersEnemy2D.Length; i++)
                        //{
                        //    collidersEnemy2D[i] = null;
                        //}
                
                        break;
                    }
                }

            }*/
            #endregion
            #region Metodo 3 - ClosestEnemy in base alla distanza del PlayerController attivo
            if (Input.GetKeyDown(KeyCode.P))
            {
                PlayerController PC = FindClosestEnemy();
                PC.gameObject.GetComponent<PlayerController>().enabled = true;
                this.gameObject.GetComponent<PlayerController>().enabled = false;

                PC.gameObject.GetComponent<Possession>().enabled = true;
                this.gameObject.GetComponent<Possession>().enabled = false;
            }
            #endregion
        }

        public PlayerController FindClosestEnemy()
        {
            gos = FindObjectsOfType<PlayerController>();
            PlayerController closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (PlayerController go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance && go != this.gameObject.GetComponent<PlayerController>())
                {
                    closest = go;
                    distance = curDistance;
                }
            }
            return closest;
        }
    }
}