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

        public Color PlayerColor;
        public Color EnemyColor;

        public static GameObject ThisCharacter;
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
                if (Input.GetKeyDown(KeyCode.P) && PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<EnemyData>().isStun == true)
                {
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<EnemyData>().isPossessed = true;
                    ReturnPlayer.CanDestroy = false;
                    ReturnPlayer.timerDestroy = 0;
                    if (LastPlayer != null)
                    {
                        LastPlayer.GetComponent<PlayerController>().enabled = false;
                        LastPlayer.GetComponent<PossessionV2>().enabled = true;
                        LastPlayer = PlayerDetectArray[PlayerDetectArray.Count - 1];
                    }


                    PlayerDetect.gameObject.tag = "Enemy";
                    PlayerDetectArray[PlayerDetectArray.Count-1].gameObject.tag = "Player";

                    PlayerDetect.GetComponent<Animator>().enabled = true;
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<Animator>().enabled = false;
                    
                    PlayerDetect.GetComponent<EnemyData>().enabled = true;
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<EnemyData>().enabled = false;


                    PlayerDetect.GetComponent<PlayerManager>().enabled = false;
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PlayerManager>().enabled = true;
                    if(PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PlayerManager>().HealthSlider != null)
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PlayerManager>().HealthSlider.MaxHealth(PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PlayerManager>().MaxHealth);

                    PlayerDetect.GetComponent<PlayerInput>().enabled = false;
                    if(PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PlayerInput>() == null)
                    {
                        PlayerDetectArray[PlayerDetectArray.Count - 1].AddComponent<PlayerInput>().enabled = true;

                        foreach (AttackSystem item in PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponentsInChildren<AttackSystem>(true))
                        {
                            if (item.name == "LightAttackCollider")
                            {
                                PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PlayerInput>().lightAttackCollider = item.gameObject;
                                PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PlayerInput>().KeyboardLightlAttack = KeyCode.U;
                            }
                            if (item.name == "HeavyAttackCollider")
                            {
                                PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PlayerInput>().heavyAttackCollider = item.gameObject;
                                PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PlayerInput>().KeyboardHeavyAttack = KeyCode.I;

                            }
                            if (item.name == "SpecialAttackCollider")
                            {
                                PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PlayerInput>().specialAttackCollider = item.gameObject;
                                PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PlayerInput>().KeyboardSpecialAttack = KeyCode.Y;
                            }
                        }
                    }
                    else
                    {
                        PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PlayerInput>().enabled = true;
                    }

                    PlayerDetect.GetComponent<EnemyData>().Life = 0;
                    PlayerDetect.GetComponent<EnemyData>().isStun = true;

                    PlayerDetect.GetComponent<PlayerController>().enabled = false;                                                  //Attuale Player
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PlayerController>().enabled = true;                //Nemico in cui nel trigger c'è il player
                    
                    PlayerDetect.GetComponent<PossessionV2>().gameObject.GetComponent<Rigidbody2D>().sharedMaterial = MaterialYesFriction;                                                       //Attuale Player
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PossessionV2>().gameObject.GetComponent<Rigidbody2D>().sharedMaterial = MaterialNoFriction;                    //Nemico in cui nel trigger c'è il player

                    PlayerDetect.GetComponent<PossessionV2>().gameObject.GetComponent<SpriteRenderer>().color = EnemyColor;                                                       //Attuale Player
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PossessionV2>().gameObject.GetComponent<SpriteRenderer>().color = PlayerColor;                    //Nemico in cui nel trigger c'è il player

                    PlayerDetect.GetComponent<PossessionV2>().gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;                                                       //Attuale Player
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PossessionV2>().gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;                    //Nemico in cui nel trigger c'è il player


                    PlayerDetect.GetComponent<PossessionV2>().gameObject.layer = 9;                                                       //Attuale 
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PossessionV2>().PromptCommand.layer = 8;                    //Nemico in cui nel trigger c'è il player
                    PlayerDetect.GetComponent<PossessionV2>().PromptCommand.layer = 9;                                                       //Attuale 
                    PlayerDetectArray[PlayerDetectArray.Count - 1].gameObject.layer = 8;                    //Nemico in cui nel trigger c'è il player

                    PlayerDetect.GetComponent<PossessionV2>().enabled = true;                                                       //Attuale Player
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PossessionV2>().enabled = false;                    //Nemico in cui nel trigger c'è il player

                    ReturnPlayer.PlayerNow = PlayerDetectArray[PlayerDetectArray.Count - 1];
                    ReturnPlayer.LastDetectList.Add(PlayerDetect);
                    ReturnPlayer.TimerDestroyList.Add(0);
                    ReturnPlayer.CanDestroyList.Add(true);
                    ReturnPlayer.CanDestroy = true;
                    PromptCommand.SetActive(false);

                    ThisCharacter = gameObject;

                    PlayerDetect.GetComponent<PlayerController>().enabled = false;
                    PlayerDetect.GetComponent<PossessionV2>().enabled = true;

                    gameObject.SetActive(false);
                    gameObject.SetActive(true);
                    
                    PlayerDetect.GetComponent<Animator>().SetBool("CanPossession", true);
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<Animator>().SetBool("CanPossession", true);
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
                GetComponent<EnemyData>().PlayerEnemy = PlayerDetect;
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
                if(GetComponent<EnemyData>().LightAttackCollider.activeSelf == true || GetComponent<EnemyData>().HeavyAttackCollider.activeSelf == true)
                {
                    GetComponent<EnemyData>().PlayerEnemy = null;
                }
                
                GetComponent<EnemyData>().LightAttackCollider.SetActive(false);
                GetComponent<EnemyData>().HeavyAttackCollider.SetActive(false);
                GetComponent<EnemyData>().CanMove = true;
                if (GetComponent<EnemyData>().CanReset == true)
                {
                    GetComponent<EnemyData>().PlayerEnemy = null;
                    //GetComponent<EnemyManager>().FirstCycleHeavy = true;
                    //GetComponent<EnemyManager>().FirstCycleLight = true;
                    //GetComponent<EnemyManager>().CooldownHeavy = false;
                    //GetComponent<EnemyManager>().CooldownLight = false;
                    //GetComponent<EnemyManager>().InitialTimerHeavy = 0;
                    //GetComponent<EnemyManager>().DeactiveColliderTimerHeavy = 0;
                    //GetComponent<EnemyManager>().CooldownTimerHeavy = 0;
                    //GetComponent<EnemyManager>().InitialTimerLight = 0;
                    //GetComponent<EnemyManager>().DeactiveColliderTimerLight = 0;
                    //GetComponent<EnemyManager>().CooldownTimerLight = 0;
                    GetComponent<EnemyData>().CanReset = false;
                    GetComponent<EnemyData>().CanAttack = true;
                }
        
        
                if (PromptCommand != null)
                {
                    PossessionV2[] AllPossession = FindObjectsOfType<PossessionV2>();
                    foreach (PossessionV2 go in AllPossession)
                    {
                        if(go.gameObject != go.GetComponent<PlayerController>().enabled)
                        {
                            //go.gameObject.SetActive(false);
                            //go.gameObject.SetActive(true);
                        }
                    }
                    PromptCommand.SetActive(false);
                }
                isPlayer = false;
            }
        }
        #endregion
    }
}






//quando il nemico è stunnato e il player è dentro l'area di possessione, comparirà uno sprite sopra la testa del nemico con il tasto corrispondente
//in caso di molteplici nemici, la possessione non avverrà con il più vicino ma in base in quale trigger il player è entrato per ultimo