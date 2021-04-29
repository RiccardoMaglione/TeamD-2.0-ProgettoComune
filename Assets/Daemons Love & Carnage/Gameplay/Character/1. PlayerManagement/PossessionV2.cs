using System.Collections.Generic;
using UnityEngine;

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

        public static GameObject LastPlayer;        //E' colui che diventerà il nuovo player, quindi l'ultimo player
        [Tooltip("")]
        public float TimeDestroyLastPlayer = 5f;



        public PhysicsMaterial2D MaterialNoFriction;
        public PhysicsMaterial2D MaterialYesFriction;

        public Color PlayerColor;
        public Color EnemyColor;

        public static GameObject ThisCharacter;

        public RuntimeAnimatorController PlayerAnimator;
        public RuntimeAnimatorController EnemyAnimator;

        public GameObject EnemyParticle;
        public GameObject PlayerParticle;

        #endregion

        public RuntimeAnimatorController FatKnightEnemyAnimator;
        public RuntimeAnimatorController BoriousEnemyAnimator;
        public RuntimeAnimatorController BabushkaEnemyAnimator;
        public RuntimeAnimatorController ThiefEnemyAnimator;

        public RuntimeAnimatorController FatKnightPlayerAnimator;
        public RuntimeAnimatorController BoriousKnightPlayerAnimator;
        public RuntimeAnimatorController BabushkaPlayerAnimator;
        public RuntimeAnimatorController ThiefPlayerAnimator;
        public static bool Can = false;

        public static GameObject PlayerPlayerPlayer;

        void Start()
        {
            if (PromptCommand != null)
                PromptCommand.SetActive(false);
            CC2D = GetComponentInChildren<CircleCollider2D>();
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
                if ((Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.Joystick1Button4)) && PlayerDetectArray[PlayerDetectArray.Count - 1] == this.gameObject && PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<EnemyData>().isStun == true && Can == false)
                {
                    Can = true;
                    PlayerPlayerPlayer = PlayerDetect;
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<EnemyData>().isPossessed = true;
                    
                    ReturnPlayer.CanDestroy = false;
                    ReturnPlayer.timerDestroy = 0;

                    //if (LastPlayer != null)
                    //{
                    //    //LastPlayer.GetComponent<PSMController>().enabled = false;
                    //    //LastPlayer.GetComponent<PossessionV2>().enabled = true;
                    //    LastPlayer = PlayerDetectArray[PlayerDetectArray.Count - 1];
                    //}

                    FindObjectOfType<ChangeFollow>().NewPlayer = PlayerDetectArray[PlayerDetectArray.Count - 1];

                    #region OLD - Vecchi commenti
                    //FindObjectOfType<ScoreSystem>(true).ScoreAssignedEnemyDestroy((int)PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<EnemyData>().TypeEnemy,1);
                    //PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PSMController>().CurrentHealth = PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PSMController>().MaxHealth;
                    //PlayerDetect.GetComponent<Animator>().enabled = true;
                    //PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<Animator>().enabled = false;
                    //PlayerDetect.GetComponent<PlayerManager>().enabled = false;
                    //PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PlayerManager>().enabled = true;
                    #endregion

                    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                    #region 0. Nemico: Disattivazione dell'area possession, che si era precedentemente attiva perché poteva essere posseduto
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<EnemyData>().AreaPossession.SetActive(false);
                    #endregion

                    #region 1. Cambio di tag tra player e nemico
                    PlayerPlayerPlayer.gameObject.tag = "Enemy";
                    PlayerDetectArray[PlayerDetectArray.Count - 1].gameObject.tag = "Player";
                    #endregion

                    #region 2. Cambio del layer tra player e nemico
                    PlayerPlayerPlayer.GetComponent<PossessionV2>().gameObject.layer = 9;                                                       //Attuale 
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PossessionV2>().PromptCommand.layer = 8;                    //Nemico in cui nel trigger c'è il player
                    PlayerPlayerPlayer.GetComponent<PossessionV2>().PromptCommand.layer = 9;                                                       //Attuale 
                    PlayerDetectArray[PlayerDetectArray.Count - 1].gameObject.layer = 8;                    //Nemico in cui nel trigger c'è il player
                    #endregion

                    #region 3. Cambio del sorting layer tra player e nemico
                    PlayerPlayerPlayer.GetComponent<PossessionV2>().gameObject.GetComponent<SpriteRenderer>().sortingOrder = PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PossessionV2>().gameObject.GetComponent<SpriteRenderer>().sortingOrder;              //Attuale Player
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PossessionV2>().gameObject.GetComponent<SpriteRenderer>().sortingOrder = 9;                    //Nemico in cui nel trigger c'è il player
                    #endregion

                    #region 4. Nemico Disattivazione range collider per diventare player
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<EnemyData>().RangeMelee.SetActive(false);
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<EnemyData>().RangeRanged.SetActive(false);

                    //Non attivo i range del player divenuto nemico perché sarà in stato di possession, quindi non potrà attaccare
                    #endregion
                    
                    #region 5. Nemico: Disattivazione collider di attacco per diventare player
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<EnemyData>().LightAttackCollider.SetActive(false);
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<EnemyData>().HeavyAttackCollider.SetActive(false);
                    #endregion

                    #region 6. Player: Attivazione particellare da nemico e disattiva particellare da player
                    PlayerPlayerPlayer.GetComponent<PossessionV2>().EnemyParticle.SetActive(true);
                    PlayerPlayerPlayer.GetComponent<PossessionV2>().PlayerParticle.SetActive(false);
                    #endregion
                    
                    #region 7. Nemico: Attivazione particelle da player e disattivazione particelle da nemico
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PossessionV2>().EnemyParticle.SetActive(false);
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PossessionV2>().PlayerParticle.SetActive(true);
                    #endregion

                    #region 8. Cambio del materiale fisico tra player e nemico
                    PlayerPlayerPlayer.GetComponent<PossessionV2>().gameObject.GetComponent<Rigidbody2D>().sharedMaterial = MaterialYesFriction;                                                       //Attuale Player
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PossessionV2>().gameObject.GetComponent<Rigidbody2D>().sharedMaterial = MaterialNoFriction;                    //Nemico in cui nel trigger c'è il player
                    #endregion

                    #region 9. Settare al nemico che diventa player l'orginal material 
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<SpriteRenderer>().material = PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<ColorChangeController>().originalMaterial;
                    #endregion

                    // Dal punto 0 al punto 9 è tutto giusto----------------------------------------------------------------------------------------------------------------------------------------------------


                    #region Attivazione e disattivazione dello script EnemyData
                    PlayerPlayerPlayer.GetComponent<EnemyData>().enabled = true;
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<EnemyData>().enabled = false;
                    #endregion
                    #region Attivazione e disattivazione dello script PSMController
                    PlayerPlayerPlayer.GetComponent<PSMController>().enabled = false;                                                  //Attuale Player
                    //PlayerDetect.GetComponent<PSMController>().enabled = false;
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PSMController>().enabled = true;                //Nemico in cui nel trigger c'è il player
                    #endregion
                    #region Cambio dell'animator tra il player e il nemico
                    switch (PlayerPlayerPlayer.GetComponent<EnemyData>().TypeEnemy)
                    {
                        case TypeEnemies.FatKnight:
                            PlayerPlayerPlayer.GetComponent<Animator>().runtimeAnimatorController = PlayerPlayerPlayer.GetComponent<PossessionV2>().FatKnightEnemyAnimator;                                            //Il player diventa il nemico
                            break;
                        case TypeEnemies.BoriusKnight:
                            PlayerPlayerPlayer.GetComponent<Animator>().runtimeAnimatorController = PlayerPlayerPlayer.GetComponent<PossessionV2>().BoriousEnemyAnimator;                                            //Il player diventa il nemico
                            break;
                        case TypeEnemies.Babushka:
                            PlayerPlayerPlayer.GetComponent<Animator>().runtimeAnimatorController = PlayerPlayerPlayer.GetComponent<PossessionV2>().BabushkaEnemyAnimator;                                            //Il player diventa il nemico
                            break;
                        case TypeEnemies.Thief:
                            PlayerPlayerPlayer.GetComponent<Animator>().runtimeAnimatorController = PlayerPlayerPlayer.GetComponent<PossessionV2>().ThiefEnemyAnimator;                                            //Il player diventa il nemico
                            break;
                        default:
                            break;
                    }

                    switch (PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PSMController>().TypeCharacter)
                    {
                        case TypePlayer.FatKnight:
                            PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<Animator>().runtimeAnimatorController = FatKnightPlayerAnimator;         //Il nemico diventa il player
                            break;
                        case TypePlayer.BoriousKnight:
                            PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<Animator>().runtimeAnimatorController = BoriousKnightPlayerAnimator;         //Il nemico diventa il player
                            break;
                        case TypePlayer.Babushka:
                            PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<Animator>().runtimeAnimatorController = BabushkaPlayerAnimator;         //Il nemico diventa il player
                            break;
                        case TypePlayer.Thief:
                            PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<Animator>().runtimeAnimatorController = ThiefPlayerAnimator;         //Il nemico diventa il player
                            PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<BoxCollider2D>().size = new Vector2(PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<BoxCollider2D>().size.x, 1.717764f);
                            PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<BoxCollider2D>().offset = new Vector2(PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<BoxCollider2D>().offset.x, -0.1982318f);
                            break;
                        default:
                            break;
                    }
                    #endregion

                    PlayerPlayerPlayer.GetComponent<Animator>().SetInteger("Life", PlayerPlayerPlayer.GetComponent<EnemyData>().Life);

                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PSMController>().PoisePlayer = 0;
                    
                    #region Settaggio della massima vita del nemico appena diventato player nello slider della vita
                    if (PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PSMController>().HealthSlider != null)
                        PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PSMController>().HealthSlider.MaxHealth(PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PSMController>().MaxHealth);
                    #endregion

                    PlayerPlayerPlayer.GetComponent<EnemyData>().Life = 0;
                    PlayerPlayerPlayer.GetComponent<EnemyData>().isStun = true;

                    #region Attivo e disattivo il parametro CanPossession che serve per andare nello stato possession quando si è un nemico
                    PlayerPlayerPlayer.GetComponent<Animator>().SetBool("CanPossession", true);
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<Animator>().SetBool("CanPossession", false);
                    #endregion

                    #region FORSE OLD - Attivazione e disattivazione dell'oggetto Aggro
                    PlayerPlayerPlayer.transform.Find("Aggro").gameObject.SetActive(true);                                    //Diventa nemico attiva aggro
                    PlayerDetectArray[PlayerDetectArray.Count - 1].transform.Find("Aggro").gameObject.SetActive(false);  //diventa player disattiva aggro
                    #endregion
                    #region OLD - Cambio colore
                    PlayerPlayerPlayer.GetComponent<PossessionV2>().gameObject.GetComponent<SpriteRenderer>().color = EnemyColor;                                                       //Attuale Player
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PossessionV2>().gameObject.GetComponent<SpriteRenderer>().color = PlayerColor;                    //Nemico in cui nel trigger c'è il player
                    #endregion

                    ReturnPlayer.PlayerNow = PlayerDetectArray[PlayerDetectArray.Count - 1];
                    ReturnPlayer.LastDetectList.Add(PlayerPlayerPlayer);
                    ReturnPlayer.TimerDestroyList.Add(0);
                    ReturnPlayer.CanDestroyList.Add(true);
                    ReturnPlayer.CanDestroy = true;
                    PromptCommand.SetActive(false);

                    ThisCharacter = gameObject;

                    gameObject.SetActive(false);
                    gameObject.SetActive(true);

                    PromptCommand.SetActive(true);
                    #region Attivazione e disattivazione dello script PossessionV2
                    //Lo script della possession è quello che mi potrà far impossessare degli altri, e dovrebbe stare alla fine perché se lo disattivo prima, rischio di interrompere il flusso di dati
                    Can = false;
                    #region Disattivo lo script della possesion del nemico che sta per diventare player
                    PlayerDetectArray[PlayerDetectArray.Count - 1].GetComponent<PossessionV2>().enabled = false;                    //Nemico in cui nel trigger c'è il player
                    #endregion
                    PlayerPlayerPlayer.GetComponent<PossessionV2>().enabled = true;                                                       //Attuale Player
                    //PlayerDetect.GetComponent<PossessionV2>().enabled = true;
                    #endregion
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
            if(GetComponent<EnemyData>().AreaPossession.activeSelf== true)
            {
                if (collision.gameObject.GetComponent<PSMController>() != null && collision.gameObject != this.gameObject && collision.gameObject.tag == "Player")
                {
                    PlayerDetect = collision.gameObject;
                    GetComponent<EnemyData>().PlayerEnemy = PlayerDetect;
                    if (PromptCommand != null)
                    {
                        PossessionV2[] AllPossession = FindObjectsOfType<PossessionV2>();
                        foreach (PossessionV2 go in AllPossession)
                        {
                            if(GetComponent<EnemyData>().AreaPossession.activeSelf == true)
                            {
                                go.PromptCommand.SetActive(false);
                            }
                            //print("Disattiva12");
                        }
                    }
                    if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Stun"))
                    {
                        PromptCommand.SetActive(true);
                    }
                    isPlayer = true;

                    PlayerDetectArray.Add(this.gameObject);
                    count++;
                    //print("Aggiungi");
                }
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {                
            if(PlayerDetectArray.Count - 1 > 0)     //Risolve l'out of index
            {
                if (collision.gameObject.GetComponent<PSMController>() != null && collision.gameObject != this.gameObject && collision.gameObject.tag == "Player" && this.gameObject == PlayerDetectArray[PlayerDetectArray.Count - 1])
                {

                    if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Stun"))
                    { 
                        PromptCommand.SetActive(true);
                    }
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PSMController>() != null && collision.gameObject != this.gameObject && collision.gameObject.tag == "Player")
            {
                PlayerDetect = null;
                if (GetComponent<EnemyData>().LightAttackCollider.activeSelf == true || GetComponent<EnemyData>().HeavyAttackCollider.activeSelf == true)
                {
                    GetComponent<EnemyData>().PlayerEnemy = null;
                }
            
                GetComponent<EnemyData>().LightAttackCollider.SetActive(false);
                GetComponent<EnemyData>().HeavyAttackCollider.SetActive(false);
                GetComponent<EnemyData>().CanMove = true;
                if (GetComponent<EnemyData>().CanReset == true)
                {
                    GetComponent<EnemyData>().PlayerEnemy = null;
                    GetComponent<EnemyData>().CanReset = false;
                    GetComponent<EnemyData>().CanAttack = true;
                }
            
            
                if (PromptCommand != null)
                {
                    PossessionV2[] AllPossession = FindObjectsOfType<PossessionV2>();
                    foreach (PossessionV2 go in AllPossession)
                    {
                        if (go.gameObject != go.GetComponent<PSMController>().enabled)
                        {
                            //go.gameObject.SetActive(false);
                            //go.gameObject.SetActive(true);
                        }
                    }
                    PromptCommand.SetActive(false);
                    //print("Disattiva23");
                }
                isPlayer = false;
            }
        }
        #endregion
    }
}






//quando il nemico è stunnato e il player è dentro l'area di possessione, comparirà uno sprite sopra la testa del nemico con il tasto corrispondente
//in caso di molteplici nemici, la possessione non avverrà con il più vicino ma in base in quale trigger il player è entrato per ultimo
