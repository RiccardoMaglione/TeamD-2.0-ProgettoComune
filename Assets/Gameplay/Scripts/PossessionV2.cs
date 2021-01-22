using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;


namespace SwordGame
{
    public class PossessionV2 : MonoBehaviour
    {
        #region Variables
        [Tooltip("")]
        public float RadiusArea = 1;
        [Tooltip("")]
        public GameObject PromptCommand;
        public static GameObject StaticPromptCommand;
        [Tooltip("")]
        public GameObject PlayerDetect;
        [Tooltip("")]
        public CircleCollider2D CC2D;
        [Tooltip("")]
        public bool isPlayer = false;


        public static List<GameObject> PlayerDetectArray = new List<GameObject>();
        [Tooltip("")]
        public List<GameObject> PlayerDetectArrayInspector;

        public static int count = 0;

        public static GameObject LastPlayer;
        [Tooltip("")]
        public float TimeDestroyLastPlayer = 5f;



        public PhysicsMaterial2D MaterialNoFriction;
        public PhysicsMaterial2D MaterialYesFriction;
        #endregion
        void Start()
        {
            if (PromptCommand != null)
                PromptCommand.SetActive(false);
            CC2D = GetComponentInChildren <CircleCollider2D>();
            CC2D.radius = RadiusArea;
        }

        void Update()
        {
            #region Update ViewOnly Inspector
            PlayerDetectArrayInspector = PlayerDetectArray;
            CC2D.radius = RadiusArea;
            #endregion
            #region Action of Possession
            if (isPlayer == true)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    ReturnPlayer.CanDestroy = false;
                    ReturnPlayer.timerDestroy = 0;
                    if (LastPlayer != null)
                    {
                        LastPlayer.GetComponent<PlayerController>().enabled = false;
                        LastPlayer.GetComponent<PossessionV2>().enabled = true;
                        LastPlayer = PlayerDetectArray[PlayerDetectArray.Count - 1];
                    }


                    PlayerDetect.gameObject.tag = "Untagged";
                    PlayerDetectArray[PlayerDetectArray.Count-1].gameObject.tag = "Player";
                    
                    PlayerDetect.GetComponent<PlayerController>().enabled = false;                                                  //Attuale Player
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PlayerController>().enabled = true;                //Nemico in cui nel trigger c'è il player
                    
                    PlayerDetect.GetComponent<PossessionV2>().enabled = true;                                                       //Attuale Player
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PossessionV2>().enabled = false;                    //Nemico in cui nel trigger c'è il player

                    PlayerDetect.GetComponent<PossessionV2>().gameObject.GetComponent<Rigidbody2D>().sharedMaterial = MaterialNoFriction;                                                       //Attuale Player
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PossessionV2>().gameObject.GetComponent<Rigidbody2D>().sharedMaterial = MaterialYesFriction;                    //Nemico in cui nel trigger c'è il player

                    ReturnPlayer.LastDetect = PlayerDetect;
                    ReturnPlayer.CanDestroy = true;
                    PromptCommand.SetActive(false);

                    PlayerDetect.GetComponent<PlayerController>().enabled = false;
                    PlayerDetect.GetComponent<PossessionV2>().enabled = true;

                    gameObject.SetActive(false);
                    gameObject.SetActive(true);
                }
            }
            #endregion

        }
        #region Gizmo Draw
        private void OnDrawGizmos()
        {
            Color C = Color.blue;
            C.a = 0.25f;
            Gizmos.color = C;
            Gizmos.DrawSphere(transform.position, RadiusArea);
        }
        #endregion
        #region Trigger Zone
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null && collision.gameObject != this.gameObject && collision.gameObject.tag == "Player")
            {
                PlayerDetect = collision.gameObject;
                if (PromptCommand != null)
                {
                    PossessionV2[] AllPossession = FindObjectsOfType<PossessionV2>();
                    foreach (PossessionV2 go in AllPossession)
                    {
                        go.PromptCommand.SetActive(false);
                    }
                }
                PromptCommand.SetActive(true);
                isPlayer = true;



                PlayerDetectArray.Add(this.gameObject);
                count++;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null && collision.gameObject != this.gameObject && collision.gameObject.tag == "Player")
            {
                PlayerDetect = null;
                if (PromptCommand != null)
                {
                    PossessionV2[] AllPossession = FindObjectsOfType<PossessionV2>();
                    foreach (PossessionV2 go in AllPossession)
                    {
                        go.gameObject.SetActive(false);
                        go.gameObject.SetActive(true);
                    }
                }
                PromptCommand.SetActive(false);
                isPlayer = false;
            }
        }
        #endregion
    }
}






//quando il nemico è stunnato e il player è dentro l'area di possessione, comparirà uno sprite sopra la testa del nemico con il tasto corrispondente
//in caso di molteplici nemici, la possessione non avverrà con il più vicino ma in base in quale trigger il player è entrato per ultimo