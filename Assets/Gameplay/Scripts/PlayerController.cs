using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordGame
{
    [System.Serializable]
    public struct StructMovement
    {
        [Tooltip("It's an acceleration of player")]
        public float Acceleration;
        [Tooltip("It's a velocity of player on right and left way")]
        public float Speed;
        [Tooltip("It's a max speed of player")]
        public float MaxSpeed;
    }

    [System.Serializable]
    public struct StructJump
    {
        [Tooltip("It's a force of player's jump")]
        public float jumpForce;
        [Tooltip("It's value of gravity fall")]
        public float fallMultiplier;
        [Tooltip("It's a value for progressive jump")]
        public float lowJumpMultiplier;
    }

    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]

    public class PlayerController : PlayerManager
    {
        #region Variables
        /*[Custom Inspector]*/ public Rigidbody2D rb;
        public SpriteRenderer TempSprite;   //Non ci sono riferimenti ma c'è quello del player

        #region Variables Struct
        /*[Custom Inspector]*/ public StructMovement ValueMovement;
        /*[Custom Inspector]*/ public StructJump ValueJump;
        #endregion
        #region Variables Jump and Fall
        [SerializeField]
        /*Hide ma public*/ public bool Grounded = true;
        /*Hide ma public*/ public bool canJump = true;
        #endregion
        #region Variables Platform
        /*Hide*/ float waitTime;                    //Si può cancellare
        [Tooltip("It's a time of change rotation offset of platform")]
        /*Custom Inspector]*/public float TimeDoublePlatform;
        GameObject TempPlatform;
        public List<GameObject> ListTempPlatform = new List<GameObject>();
        public List<float> ListWaitTime = new List<float>();
        #endregion
        #region Variables Dash - Normal
        /*Hide ma public*/
        public bool CanDashLeft = false;
        /*Hide ma public*/ public bool CanDashRight = false;
        [Tooltip("Value of start of timer for dash")]
        [ReadOnly] public float TimerDash = 0;//Controllare se utilizzato o no causa animator
        [Tooltip("Value for limit timer of dash")]
        public float LimitTimerDash = 5; //va nell'animator
        public float TimerCooldownDash;             //Controllare se utilizzato o no causa animator
        public bool CanDashJump;            //Utilizzato nella parte del dash - Non si possono modificare da inspector
        public bool CanDash;                //Utilizzato nella parte del dash - Non si possono modificare da inspector
        public bool GravityChange = true;   //Utilizzato nella parte del dash - Non si possono modificare da inspector
        #endregion
        #region Variables Dash - Effect
        public GameObject DashColliderBabushka;     //Per gli effetti del dash - Deve essere possibile modificarlo
        public int DashDamageFatKnight;             //Per gli effetti del dash - Deve essere possibile modificarlo
        public static bool isBoriousDash = false;   //Per gli effetti del dash - Vedere dove utilizzato
        #endregion
        #region Variables Poise
        /*Hide ma public*/ public int PoisePlayer;             //Utilizzato nella parte del poise - Non si possono modificare da inspector
        /*[Custom Inspector]*/ public int MaxPoisePlayer;          //Utilizzato nella parte del poise - Deve essere possibile modificarlo
        #endregion
        #region Variables Stagger utilizzate
        [ReadOnly] public float ResetTimerStaggered;   //Si potrebbero poter togliere - Non si possono modificare da inspector
        /*[Custom Inspector]*/ public float MaxResetTimerStaggered;//Si potrebbero poter togliere - Non si possono modificare da inspector
        #endregion

        public float tempSpeed;                         //Va nell'animatore
        [ReadOnly] public float velocityY;              //Check in inspector - Non si possono modificare da inspector
        public static float StaticSpeed;                //Controllare dove va

        #region Variables Stagger non utilizzate
        public bool isStaggered;            //Si potrebbero poter togliere - Non si possono modificare da inspector
        public float TimerStaggered;        //Si potrebbero poter togliere - Non si possono modificare da inspector
        #endregion

        public float PlayerIdleSpeed = 1;
        public float PlayerMoveSpeed = 1;
        public float PlayerDashSpeed = 1;
        public float PlayerFallSpeed = 1;
        public float PlayerDashFallSpeed = 1;
        public float PlayerJumpSpeed = 1;
        public float PlayerDieSpeed = 1;
        public float PlayerStaggerSpeed = 1;
        public float PlayerLightAttackSpeed = 1;
        public float PlayerHeavyAttackSpeed = 1;
        public float PlayerSpecialAttackSpeed = 1;
        #endregion

        private void OnValidate()
        {
            OnValidatePlayerManager();
        }

        void Start()
        {
            InitializePlayerManager();
            InitializePlayerController();
        }

        void Update()
        {
            UpdatePlayerManager();
            UpdatePlayerController();
        }

        #region Player - Move and Jump and Dash

        /// <summary>
        /// Metodo che inizializza alcune variabili del player controller
        /// </summary>
        public void InitializePlayerController()
        {
            rb = GetComponent<Rigidbody2D>();       //Setta la referenza del Rigidbody2D
            waitTime = TimeDoublePlatform;          //Setta il wait time uguale al TimeDoublePlatform - Si può cancellare
            tempSpeed = ValueMovement.Speed;        //Setta il tempSpeed uguale alla velocità del player
        }

        /// <summary>
        /// Metodo per inizializzare da inspector le velocità delle animazioni della state machine
        /// </summary>
        public void InitializeSpeedAnimation()
        {
            GetComponent<Animator>().SetFloat("PlayerIdleSpeed", PlayerIdleSpeed);
            GetComponent<Animator>().SetFloat("PlayerMoveSpeed", PlayerMoveSpeed);
            GetComponent<Animator>().SetFloat("PlayerDashSpeed", PlayerDashSpeed);
            GetComponent<Animator>().SetFloat("PlayerFallSpeed", PlayerFallSpeed);
            GetComponent<Animator>().SetFloat("PlayerDashFallSpeed", PlayerDashFallSpeed);
            GetComponent<Animator>().SetFloat("PlayerJumpSpeed", PlayerJumpSpeed);
            GetComponent<Animator>().SetFloat("PlayerDieSpeed", PlayerDieSpeed);
            GetComponent<Animator>().SetFloat("PlayerStaggerSpeed", PlayerStaggerSpeed);
            GetComponent<Animator>().SetFloat("PlayerLightAttackSpeed", PlayerLightAttackSpeed);
            GetComponent<Animator>().SetFloat("PlayerHeavyAttackSpeed", PlayerHeavyAttackSpeed);
            GetComponent<Animator>().SetFloat("PlayerSpecialAttackSpeed", PlayerSpecialAttackSpeed);
        }

        /// <summary>
        /// Metodo dell'update del PlayerController
        /// </summary>
        public void UpdatePlayerController()
        {
            velocityY = rb.velocity.y;                  //Check rb.velocity.y in inspector
            StaticSpeed = ValueMovement.Speed;          //Controllare cosa fa

            ResetPlatform();
            ResetStaggered();
            print("Grounded" + Grounded);

            if (Grounded == true)
            {
                CanDashJump = true;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                canJump = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftControl))
            {
                CanDash = true;
            }

            if (rb.velocity.y < -0.01f && CanDashLeft == false && CanDashRight == false)
            {
                GetComponent<Animator>().SetBool("IsFall", true);       //Possibile bug
                Debug.Log("Ciao3");
            }
            else
            {
                GetComponent<Animator>().SetBool("IsFall", false);
            }
        }
        
        /// <summary>
        /// Metodo per calcolare la velocità del player e limitarla ad un massimo
        /// </summary>
        public void CalculateSpeed()
        {
            ValueMovement.Speed = ValueMovement.Speed + ValueMovement.Acceleration * Time.deltaTime;
            if (ValueMovement.Speed >= ValueMovement.MaxSpeed)
                ValueMovement.Speed = ValueMovement.MaxSpeed;
        }
        
        /// <summary>
        /// Metodo per resettare il rotation offset delle piattaforme
        /// TODO: Creare un array per risolvere il bug delle piattaforme che non si resettano
        /// </summary>
        public void ResetPlatform()
        {
            for (int i = 0; i < ListWaitTime.Count; i++)
            {
                if(ListTempPlatform[i] != null)
                {
                    ListWaitTime[i] -= Time.deltaTime;
                    if(ListWaitTime[i] <= 0)
                    {
                        ListTempPlatform[i].GetComponent<PlatformEffector2D>().rotationalOffset = 0;
                        ListWaitTime.RemoveAt(i);
                        ListTempPlatform.RemoveAt(i);
                    }
                }
            }
            //if (TempPlatform != null )
            //{
                //waitTime -= Time.deltaTime;
                //if (waitTime <= 0)
                //{
                //    TempPlatform.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
                //    TempPlatform = null;
                //    waitTime = TimeDoublePlatform;
                //}
            //}
        }

        /// <summary>
        /// Metodo che resetta il poise se il player non viene attaccato per un certo valore di tempo
        /// </summary>
        public void ResetStaggered()
        {
            ResetTimerStaggered += Time.deltaTime;              //Aumenta il timer
            if (ResetTimerStaggered >= MaxResetTimerStaggered)  //Se il timer è superiore rispetto a un certo valore
            {
                PoisePlayer = 0;                                //Azzera il valore della poise
            }
        }
        
        #region Dash

        /// <summary>
        /// Metodo che definisce gli effetti dei dash dei vari personaggi giocabili
        /// </summary>
        public void EffectDash()
        {
            switch (TypeCharacter)
            {
                case TypePlayer.FatKnight:
                    gameObject.layer = 0;
                    break;
                case TypePlayer.BoriousKnight:
                    isBoriousDash = true;
                    break;
                case TypePlayer.Babushka:
                    DashColliderBabushka.SetActive(true);
                    break;
                case TypePlayer.Thief:
                    Invulnerability = true;
                    break;
                default:
                    break;
            }
        }

       /// <summary>
       /// IEnumerator per il cooldown del dash
       /// </summary>
       /// <returns></returns>
        public IEnumerator CooldownDash()
        {
            GravityChange = false;
            if (GravityChange == false)
            {
                GetComponent<Rigidbody2D>().gravityScale = ValueJump.fallMultiplier - 1;
            }
            GetComponent<Animator>().SetBool("IsDash", false);
            GetComponent<Animator>().SetBool("CanDashFall", false);
            gameObject.layer = 8;
            yield return new WaitForSeconds(TimerCooldownDash);
            GetComponent<Rigidbody2D>().gravityScale = 1;
            CanDashLeft = false;
            CanDashRight = false;
            Invulnerability = false;
            if (DashColliderBabushka != null)
                DashColliderBabushka.SetActive(false);
            isBoriousDash = false;

            TimerDash = 0;
            if (rb.velocity.y == 0)
            {
                CanDashJump = true;
                Grounded = true;
            }
            else
            {
                CanDashJump = false;
            }
            GravityChange = true;
        }

        #endregion

        #region Contiene lo stagger con un timer - Al momento metodi inutilizzati

        /// <summary>
        /// Metodo per attivare lo stagger, azzerare la velocità del player e far partire il cooldown
        /// </summary>
        public void Staggered()
        {
            if (PoisePlayer >= MaxPoisePlayer)
            {
                isStaggered = true;
                rb.velocity = Vector2.zero;
                StartCoroutine(CooldownStaggered());
            }
        }
        /// <summary>
        /// IEnumarator per il cooldown dello stagger, nel quale a fine resetta il valore di poise
        /// </summary>
        /// <returns></returns>
        public IEnumerator CooldownStaggered()
        {
            yield return new WaitForSeconds(TimerStaggered);
            isStaggered = false;
            PoisePlayer = 0;
        }

        #endregion
        
        #endregion

        #region Collision
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (rb != null)
            {
                if (rb.velocity.y == 0)
                {
                    Grounded = true;
                }
            }

        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            if (Input.GetKey(KeyCode.S))
            {
                if (collision.gameObject.GetComponent<PlatformEffector2D>() != null)
                {
                    collision.gameObject.GetComponent<PlatformEffector2D>().rotationalOffset = 180;
                    TempPlatform = collision.gameObject;
                    ListTempPlatform.Add(TempPlatform);
                    ListWaitTime.Add(TimeDoublePlatform);
                }
            }
        }
        #endregion

        #region Trigger
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
        #endregion
    }
}