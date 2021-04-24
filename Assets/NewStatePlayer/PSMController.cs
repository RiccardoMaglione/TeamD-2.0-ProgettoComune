﻿using System.Collections;
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
        public float VelocityDash = 5;
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

        #region Attack
        [SerializeField] public GameObject LightAttackCollider;
        [SerializeField] public GameObject HeavyAttackCollider;
        [SerializeField] public GameObject SpecialAttackCollider;

        [Header("KEYBOARD INPUTS")]
        [SerializeField] public KeyCode KeyboardLightlAttack;
        [SerializeField] public KeyCode KeyboardHeavyAttack;
        [SerializeField] public KeyCode KeyboardSpecialAttack;

        public bool IsLightAttack = false;
        public bool IsHeavyAttack = false;
        public bool IsSpecialAttack = false;
        #endregion
        public bool JumpFollow = false;

        public float CoeffReduceDamageLight = 1;
        public float CoeffReduceDamageHeavy = 1;
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
            AttackPlayer();
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

        /// <summary>
        /// Metodo per attaccare
        /// </summary>
        public void AttackPlayer()
        {
            if ((Input.GetKeyDown(KeyboardLightlAttack) || Input.GetKeyDown(KeyCode.Joystick1Button2)) && GetComponent<Animator>().GetBool("PSM-CanAttack") == true && (DialogueType1.StaticTutorial != -1 && DialogueType1.StaticTutorial != 1 && DialogueType1.StaticTutorial != 4 && DialogueType1.StaticTutorial != 6))
            {
                GetComponent<Animator>().SetBool("PSM-CanAttack", false);
                GetComponent<Animator>().SetBool("PSM-Attack", true);
                GetComponent<Animator>().SetBool("PSM-LightAttack", true);
                IsLightAttack = true;
                IsHeavyAttack = false;
                IsSpecialAttack = false;
            }
            if ((Input.GetKeyDown(KeyboardHeavyAttack) || Input.GetKeyDown(KeyCode.Joystick1Button3)) && GetComponent<Animator>().GetBool("PSM-CanAttack") == true && (DialogueType1.StaticTutorial != -1 && DialogueType1.StaticTutorial != 1 && DialogueType1.StaticTutorial != 4 && DialogueType1.StaticTutorial != 6))
            {
                GetComponent<Animator>().SetBool("PSM-CanAttack", false);
                GetComponent<Animator>().SetBool("PSM-Attack", true);
                GetComponent<Animator>().SetBool("PSM-HeavyAttack", true);
                IsLightAttack = false;
                IsHeavyAttack = true;
                IsSpecialAttack = false;
            }
            if ((Input.GetKeyDown(KeyboardSpecialAttack) || Input.GetKeyDown(KeyCode.Joystick1Button1)) && GetComponent<Animator>().GetBool("PSM-CanAttack") == true && (DialogueType1.StaticTutorial != -1 && DialogueType1.StaticTutorial != 1 && DialogueType1.StaticTutorial != 4 && DialogueType1.StaticTutorial != 6) && MaxEnergy <= CurrentEnergy)
            {
                CurrentEnergy = 0;
                //GetComponent<Animator>().SetBool("PSM-CanAttack", false);
                //GetComponent<Animator>().SetBool("PSM-Attack", true);
                //GetComponent<Animator>().SetBool("PSM-SpecialAttack", true);
                //IsLightAttack = false;
                //IsHeavyAttack = false;
                //IsSpecialAttack = true;
                if (TypeCharacter == TypePlayer.FatKnight)
                {
                    if (FeedbackManager.instance.isCutIn == false)
                        StartCoroutine(FeedbackManager.instance.CutInFat());
                }

                if (TypeCharacter == TypePlayer.Babushka)
                {
                    if (FeedbackManager.instance.isCutIn == false)
                        StartCoroutine(FeedbackManager.instance.CutInBabushka());
                    
                    GetComponentInChildren<BabushkaParticleController>().PlayRageAura();
                }

                if (TypeCharacter == TypePlayer.BoriousKnight)
                {
                    if (FeedbackManager.instance.isCutIn == false)
                        StartCoroutine(FeedbackManager.instance.CutInBorius());
                }

                if (TypeCharacter == TypePlayer.Thief)
                {
                    if (FeedbackManager.instance.isCutIn == false)
                        StartCoroutine(FeedbackManager.instance.CutInThief());
                }
            }
        }

        /// <summary>
        /// Evento: Attivazione del collider di attacco
        /// </summary>
        public void EventActivateCollider()
        {
            if(GetComponent<Animator>().GetBool("PSM-LightAttack") == true)
            {
                LightAttackCollider.SetActive(true);
            }
            if (GetComponent<Animator>().GetBool("PSM-HeavyAttack") == true)
            {
                StartCoroutine(FeedbackManager.instance.Vibration());
                HeavyAttackCollider.SetActive(true);
            }
            if (GetComponent<Animator>().GetBool("PSM-SpecialAttack") == true)
            {
                SpecialAttackCollider.SetActive(true);
            }
        }

        /// <summary>
        /// Evento: Disattivazione del collider di attacco
        /// </summary>
        public void EventDeactivateCollider()
        {
            if (GetComponent<Animator>().GetBool("PSM-LightAttack") == true)
            {
                LightAttackCollider.SetActive(false);
            }
            if (GetComponent<Animator>().GetBool("PSM-HeavyAttack") == true)
            {
                HeavyAttackCollider.SetActive(false);
            }
            if (GetComponent<Animator>().GetBool("PSM-SpecialAttack") == true)
            {
                SpecialAttackCollider.SetActive(false);
            }
        }

        /// <summary>
        /// Evento: Va nell'ultimo frame dell'attacco, serve per passare allo stato successivo dell'attacco - Exit
        /// </summary>
        public void EventFinishAttack()
        {
            if (GetComponent<Animator>().GetBool("PSM-LightAttack") == true)
            {
                GetComponent<Animator>().SetBool("PSM-LightAttack", false);
            }
            if (GetComponent<Animator>().GetBool("PSM-HeavyAttack") == true)
            {
                GetComponent<Animator>().SetBool("PSM-HeavyAttack", false);
            }
            if (GetComponent<Animator>().GetBool("PSM-SpecialAttack") == true)
            {
                GetComponent<Animator>().SetBool("PSM-SpecialAttack", false);
            }
            IsLightAttack = false;
            IsHeavyAttack = false;
            IsSpecialAttack = false;
        }

        #region Trigger Zone
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.GetComponentInParent<EnemyData>() != null)
            {
                if(Invulnerability == false && collision.GetComponentInParent<EnemyData>().IsTriggerAttack == false && tag == "Player")
                {
                    if (collision.tag == "LightAttack")
                    {
                        collision.GetComponentInParent<EnemyData>().IsTriggerAttack = true;
                        ResetTimerStaggered = 0;
                        PoisePlayer += 1;
                        CurrentHealth -= (int)(collision.GetComponentInParent<EnemyData>().LightDamage * CoeffReduceDamageLight);
                        print("PSM-Trigger: Entra nel light attack - Colpito");
                        StartCoroutine(FeedbackManager.instance.Vibration());
                        if (isBoriousDash == true)
                        {
                            collision.GetComponentInParent<EnemyData>().Life -= collision.GetComponentInParent<EnemyData>().LightDamage;
                        }
                        collision.GetComponentInParent<EnemyData>().IsTriggerAttack = false;
                    }
                    if (collision.tag == "HeavyAttack" )
                    {
                        collision.GetComponentInParent<EnemyData>().IsTriggerAttack = true;
                        ResetTimerStaggered = 0;
                        PoisePlayer += 1;
                        CurrentHealth -= (int)(collision.GetComponentInParent<EnemyData>().HeavyDamage * CoeffReduceDamageHeavy);
                        print("PSM-Trigger: Entra nel heavy attack - Colpito");
                        StartCoroutine(FeedbackManager.instance.Vibration());
                        if (isBoriousDash == true)
                        {
                            collision.GetComponentInParent<EnemyData>().Life -= collision.GetComponentInParent<EnemyData>().HeavyDamage;
                        }
                        collision.GetComponentInParent<EnemyData>().IsTriggerAttack = false;
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
                collision.GetComponentInParent<EnemyData>().IsTriggerAttack = false;
            }
            if (collision.tag == "HeavyAttack")
            {
                collision.GetComponentInParent<EnemyData>().IsTriggerAttack = false;
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

            if ((Input.GetKey(KeyCode.DownArrow) || (Input.GetAxisRaw("Vertical") < 0) || (Input.GetAxisRaw("DPad Y") < 0)) && (DialogueType1.StaticTutorial != -1))
            {
                if (collision.gameObject.GetComponent<PlatformEffector2D>() != null && this.gameObject.tag == "Player")
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