using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;


namespace SwordGame
{
    public class PossessionV2 : MonoBehaviour
    {
        public float RadiusArea = 1;
        public GameObject PromptCommand;
        public static GameObject StaticPromptCommand;
        public GameObject PlayerDetect;
        public CircleCollider2D CC2D;
        public bool isPlayer = false;


        public static List<GameObject> PlayerDetectArray = new List<GameObject>();
        public List<GameObject> PlayerDetectArrayInspector;

        public static int count = 0;

        public static GameObject LastPlayer;
        public float TimeDestroyLastPlayer = 5f;

        void Start()
        {
            if (PromptCommand != null)
                PromptCommand.SetActive(false);
            CC2D = GetComponentInChildren <CircleCollider2D>();
            CC2D.radius = RadiusArea;
        }

        // Update is called once per frame
        void Update()
        {
            PlayerDetectArrayInspector = PlayerDetectArray;
            CC2D.radius = RadiusArea;
            if(isPlayer == true)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
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

                    ReturnPlayer.LastDetect = PlayerDetect;
                    ReturnPlayer.CanDestroy = true;
                    PromptCommand.SetActive(false);
                    
                }
            }
            

        }


        private void OnDrawGizmos()
        {
            Color C = Color.blue;
            C.a = 0.25f;
            Gizmos.color = C;
            Gizmos.DrawSphere(transform.position, RadiusArea);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null && collision.gameObject != this.gameObject && collision.gameObject.tag == "Player")
            {
                PlayerDetect = collision.gameObject;
                if (PromptCommand != null)
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
                    PromptCommand.SetActive(false);
                isPlayer = false;
            }
        }
    }
}






//quando il nemico è stunnato e il player è dentro l'area di possessione, comparirà uno sprite sopra la testa del nemico con il tasto corrispondente
//in caso di molteplici nemici, la possessione non avverrà con il più vicino ma in base in quale trigger il player è entrato per ultimo