using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

namespace SwordGame
{
    [System.Serializable]
    public struct PSMStructMovement
{
    [Tooltip("It's an acceleration of player")]
    public float Acceleration;
    [Tooltip("It's a velocity of player on right and left way")]
    public float Speed;
    [Tooltip("It's a max speed of player")]
    public float MaxSpeed;
}
    
    [System.Serializable]
    public struct PSMStructJump
{
    [Tooltip("It's a force of player's jump")]
    public float InitialJumpForce;
    [Tooltip("It's a force of player's jump")]
    public float jumpForce;
    [Tooltip("It's value of gravity fall")]
    public float fallMultiplier;
    [Tooltip("It's a value for progressive jump")]
    public float lowJumpMultiplier;
}
    public class PSMController : PlayerManager
    {
        [HideInInspector] public Rigidbody2D RB2D;
    
        public PSMStructMovement ValueMovement;
        public PSMStructJump ValueJump;
    
        #region Variables Dash
        [HideInInspector] public float TimerDash = 0;
        public float LimitTimerDash = 0.2f;
        [HideInInspector] public float TimerDashCooldown = 0;
        public float LimiTimerDashCooldown = 1f;
        /*[HideInInspector]*/ public bool CanDashRight = false;
        /*[HideInInspector]*/ public bool CanDashLeft = false;
        /*[HideInInspector]*/ public bool CooldownDashDirectional = false;
        /*[HideInInspector]*/ public bool OnceJump = false;
        #endregion
        #region Variables Poise
        /*[HideInInspector]*/ public float ResetTimerStaggered;
        public float MaxResetTimerStaggered;
        /*[HideInInspector]*/ public int PoisePlayer;
        public int MaxPoisePlayer;
        #endregion
        #region Variables Platform
        public float TimeDoublePlatform;
        GameObject TempPlatform;
        public List<GameObject> ListTempPlatform = new List<GameObject>();
        public List<float> ListWaitTime = new List<float>();
        #endregion
        #region Speed Animation
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
        #region Dash Effect
        public GameObject DashColliderBabushka;
        public static bool isBoriousDash = false;
        #endregion
        //[HideInInspector] public Vector3 InitialPos;
        private void OnValidate()
        {
            OnValidatePlayerManager();
        }
    
        void Start()
        {
            RB2D = GetComponent<Rigidbody2D>();
            InitializePlayerManager();
            InitializeSpeedAnimation();
        }
    
        void Update()
        {
            DashCooldownState();
            ResetStaggered();
            ResetPlatform();
            UpdatePlayerManager();
        }
    
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
        /// Metodo per il cooldown del dash
        /// </summary>
        public void DashCooldownState()
        {
            if (CooldownDashDirectional == true)
            {
                Debug.Log("PlayerState - E' nel cooldown dash");
                TimerDashCooldown += Time.deltaTime;
                if (TimerDashCooldown >= LimiTimerDashCooldown)
                {
                    //Resetta cose ma devo essere già fuori dallo stato
                    CanDashRight = false;                   //Resetta la direzione del dash
                    CanDashLeft = false;                    //Resetta la direzione del dash
                    TimerDash = 0;                          //Resetta il timer della durata del dash
                    TimerDashCooldown = 0;                  //Resetta il timer del cooldown
                    CooldownDashDirectional = false;        //Mi permette di ritornare in dash
                    Invulnerability = false;
                    isBoriousDash = false;
                    if (DashColliderBabushka != null)
                        DashColliderBabushka.SetActive(false);
                }

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
    
        /// <summary>
        /// Metodo per resettare il rotation offset delle piattaforme
        /// </summary>
        public void ResetPlatform()
        {
            for (int i = 0; i < ListWaitTime.Count; i++)
            {
                if (ListTempPlatform[i] != null)
                {
                    ListWaitTime[i] -= Time.deltaTime;
                    if (ListWaitTime[i] <= 0)
                    {
                        ListTempPlatform[i].GetComponent<PlatformEffector2D>().rotationalOffset = 0;
                        ListWaitTime.RemoveAt(i);
                        ListTempPlatform.RemoveAt(i);
                    }
                }
            }
        }

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

        #region Trigger Zone
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(Invulnerability == false && isTriggerOnlyOnce == false)
            {
                if (collision.tag == "LightAttack")
                {
                    isTriggerOnlyOnce = true;
                    ResetTimerStaggered = 0;
                    PoisePlayer += 1;
                    CurrentHealth -= collision.GetComponentInParent<EnemyData>().LightDamage;
                    print("PSM-Trigger: Entra nel light attack - Colpito");
                    if (isBoriousDash == true)
                    {
                        collision.GetComponentInParent<EnemyData>().Life -= collision.GetComponentInParent<EnemyData>().LightDamage;
                    }
                }
                if (collision.tag == "HeavyAttack")
                {
                    isTriggerOnlyOnce = true;
                    ResetTimerStaggered = 0;
                    PoisePlayer += 1;
                    CurrentHealth -= collision.GetComponentInParent<EnemyData>().HeavyDamage;
                    print("PSM-Trigger: Entra nel heavy attack - Colpito");
                    if (isBoriousDash == true)
                    {
                        collision.GetComponentInParent<EnemyData>().Life -= collision.GetComponentInParent<EnemyData>().HeavyDamage;
                    }
                }
            }

            if (PoisePlayer >= MaxPoisePlayer)
            {
                GetComponent<Animator>().SetBool("PSM-IsStagger", true);
                print("PSM-Trigger: Entra nello stagger");
            }
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
    
        #region Collision Zone
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Floor" && RB2D.velocity.y == 0)
            {
                GetComponent<Animator>().SetBool("PSM-IsGrounded", true);   //Setto PSM-IsGrounded = true quando tocca il pavimento
            }
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Floor" && RB2D.velocity.y == 0)
            {
                GetComponent<Animator>().SetBool("PSM-IsGrounded", true);
                GetComponent<Animator>().SetBool("PSM-CanDashInAir", false); //Permette di rientrare in dash
            }

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
    }
}


//Sarebbe da velocizzare il passaggio a jump
//Mancano gli effetti del dash