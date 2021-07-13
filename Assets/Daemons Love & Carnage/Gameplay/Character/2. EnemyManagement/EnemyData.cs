using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    #region Variables

    #region Life Behaviour / Stun Sub-Behaviour - Possession Sub-Behaviour
    public TypeEnemies TypeEnemy;

    [Space(10)]
    [Header("------------------------ Life Behaviour -----------------------------------------------------------------------------------------------------------------------------")]
    [Tooltip("Indica la vita del player")]
    public float Life;                                                     //life behaviour, indica la vita del player

    [Header("   ►  First Method - From stun to destoy")]
    [Header("~~~ Stun Sub-Behaviour ~~~ Value Management")]
    [Space(10)]
    [ReadOnly] public float timerStun = 0;                               //stun behaviour o life behaviour, è il timer di stun - readonly
    [Tooltip("Indica la durata dello stato di stun prima che il personaggio si distrugga")]
    public float DurationStun = 5;                                       //stun behaviour o life behaviour, max value of timer di stun 

    [Header("   ►  Second Method - From stun to destoy")]
    [ReadOnly] public int CountHit = 0;                                  //Stunned behaviour quindi potremmo metterlo nel life behaviour, indica quanti colpi ha dato il player al nemico dopo lo stun - readonly
    [Tooltip("Indica quanti attacchi da parte del player servano prima che il personaggio si distrugga")]
    public int MaxCountHit = 0;                                          //Stunned behaviour quindi potremmo metterlo nel life behaviour, indica il max dei colpi prima di scomparire
    [Header("   ►  Boolean for know if state stun is active or not - ReadOnly")]
    [ReadOnly] public bool isStun = false;

    [Header("   ►  Boolean for the know if the player can possess this enemy - ReadOnly")]
    [Header("~~~ Possesion Sub-Behaviour ~~~")]
    [Space(10)]
    [ReadOnly] public bool isPossessed = false;                          //Behaviour? forse life o stun, indica se l'enemy può essere posseduto oppure no

    [Space(10)]
    [Header("~~~ Stagger Sub-Behaviour ~~~")]
    [Header("   ►  Count of max number of hit for activate stagger")]
    [Space(20)]
    public int CountPoiseEnemy;
    public int MaxCountPoiseEnemy;

    #endregion

    #region Movement Behaviour
    [Space(10)]
    [Header("------------------------ Movement Behaviour -----------------------------------------------------------------------------------------------------------------------------")]

    public float Speed;                                                   //Movement Behaviour - Velocità di movimento

    [Space(10)]
    [Header("►  Path Movement - Array")]
    public List<GameObject> WaypointEnemy = new List<GameObject>();                                    //Movement Behaviour Lista di waypoint per il path

    [ReadOnly] public int WaypointIndex;                                  //Movement Behaviour - Indice del waypoint = readonly

    [Space(10)]
    [Header("►  Value for indicate if the player can move")]
    [Tooltip("Condition - Standard: True - 'Temp false for ranged'")]
    public bool CanMove = true;                                           //Indica se il player si può muovere - si potrebbe anche usare se un nemico non si può muovere

    [Space(10)]
    [Header("►  Variables for control when the player is in aggro")]
    [ReadOnly] public GameObject PlayerEnemy;                             //Movement Behaviour e Attack Behaviour - nel movement serve per andare in contro al player e nell'attack serve per la distance per il reset

    [ReadOnly] public bool CanVisible = false;                            //Movement Bahaviour e Attack Behaviour - Indica se il nemico viene visto (quindi se entra nel collider trigger) - readonly
    #endregion

    #region Variables Attack Behaviour
    [Space(10)]
    [Header("►  Collider Attack - Light And Heavy")]
    [Header("------------------------ Attack Behaviour -----------------------------------------------------------------------------------------------------------------------------")]
    public GameObject LightAttackCollider;
    public GameObject HeavyAttackCollider;

    [Space(10)]
    [Header("►  Percentuage of spawn of collider attack - Light And Heavy")]
    [Tooltip("Da 0 a Percentuage corrisponde al light attack, da percentuage a 100 è heavy attack\n0 <= Percentuage = Light && Percentuage >= 100 = Heavy")]
    [Range(0, 100)]
    public int PercentuageAttack;
    [ReadOnly] public int random;                                          //Attack Bahaviour - Variabile per la pesca random per poi confrontare con la percentuale
    [Tooltip("Sarebbe la variabile che indica che il random può attivarsi")]
    public bool CanAttack = true;                               //Attack Behaviour - Indica la nuova estrazione del valore random riferito alla percentuale della scelta dell'attacco

    [Space(10)]
    [Header("►  Value of damage of typology of attack - Value Management")]
    public float LightDamage;
    public float HeavyDamage;
    public float SpecialDamage;

    [Space(10)]
    [Header("►  Reset Cycle Attack - Value Management - ReadOnly")]
    [ReadOnly] public bool CanReset = false;                                //Resetta i timer e i booleani di attacco quando il player esce fuori dall'aggro, visto che lo resettava ad ogni attaco, è stato strutturato tramite il controllo della distanza


    [Space(10)]
    [Header("~~~ AI Animation - State Machine Behaviour - Speed Management ~~~ ")]
    [Space(10)]
    [Header("------------------------ Animation Zone -----------------------------------------------------------------------------------------------------------------------------")]
    [Space(20)]
    public float IdleAnimClipSpeed = 10;
    public float PatrolAnimClipSpeed = 1;
    public float FollowAnimClipSpeed = 1;
    public float LightAttackAnimClipSpeed = 1;
    public float LightRecoveryAnimClipSpeed = 1;
    public float HeavyAttackAnimClipSpeed = 1;
    public float HeavyRecoveryAnimClipSpeed = 1;
    public float DamageAnimClipSpeed = 1;
    public float StunAnimClipSpeed = 1;
    public float StaggerAnimClipSpeed = 1;
    public float PossessionAnimClipSpeed = 1;
    public float DeathAnimClipSpeed = 1;

    public GameObject Aggro;

    public bool IsTriggerAttack = false;
    #endregion

    public GameObject RangeMelee;
    public GameObject RangeRanged;
    public GameObject AreaPossession;
    #endregion

    public GameObject ArrowThief;
    public GameObject SpawnArrow;
    public int ValuePoiseLight = 1;
    public int ValuePoiseHeavy = 1;

    public float DistanceFollow = 1f;

    public float EnemyCoeffReduceDamageLight = 1;
    public float EnemyCoeffReduceDamageHeavy = 1;
    public float EnemyCoeffReduceDamageSpecial = 1;

    public int ValuePoiseKnockbackFatKnight;
    public bool DashFatKnightEffect;

    public int ValuePoiseKnockbackBabushka;
    public bool DashBabushkaEffect;
    public float DamageDashBabushka;

    public GameObject deathEffect;

    private void Start()
    {
        //GetComponent<Animator>().SetInteger("Life", Life);
        GetComponent<Animator>().SetFloat("Life", Life);
        print("Vita del nemico" + Life + "Vita animator nemico" + GetComponent<Animator>().GetFloat("Life"));
        timerStun = 0;
        InitializeSpeedAnimation();
    }

    void Update()
    {
        #region Don't Active - Update
        //Stunned();
        //Staggered();
        //
        //if(isStaggeredEnemy == false)
        //{
        //  //PatrolStateBehaviour();
        //  //Attack();
        //}
        //
        //print("Stun" + timerStun);
        //ResetStaggeredEnemy();
        #endregion
        //CalculateDistance();
    }


    #region Method - IA - Enemy Behaviour
    #region Attack Behaviour
    public void CalculateDistance()
    {
        if (PlayerEnemy != null)
        {
            float Distance = Vector2.Distance(gameObject.transform.position, PlayerEnemy.transform.position);
            print("Distance" + Distance);
            if (Distance >= Aggro.GetComponentInChildren<CircleCollider2D>().radius)       //Il 2.3f sarebbe il possession radius
            {
                CanReset = true;
            }
            else
            {
                CanReset = false;
            }
        }
    }
    #endregion
    #endregion

    #region Animation Zone

    #region Init Animation
    public void InitializeSpeedAnimation()
    {
        GetComponent<Animator>().SetFloat("IdleSpeed", IdleAnimClipSpeed);
        GetComponent<Animator>().SetFloat("PatrolSpeed", PatrolAnimClipSpeed);
        GetComponent<Animator>().SetFloat("FollowSpeed", FollowAnimClipSpeed);
        GetComponent<Animator>().SetFloat("LightAttackSpeed", LightAttackAnimClipSpeed);
        GetComponent<Animator>().SetFloat("LightRecoverySpeed", LightRecoveryAnimClipSpeed);
        GetComponent<Animator>().SetFloat("HeavyAttackSpeed", HeavyAttackAnimClipSpeed);
        GetComponent<Animator>().SetFloat("HeavyRecoverySpeed", HeavyRecoveryAnimClipSpeed);
        GetComponent<Animator>().SetFloat("DamageSpeed", DamageAnimClipSpeed);
        GetComponent<Animator>().SetFloat("StaggerSpeed", StaggerAnimClipSpeed);
        GetComponent<Animator>().SetFloat("StunSpeed", StunAnimClipSpeed);
        GetComponent<Animator>().SetFloat("PossessionSpeed", PossessionAnimClipSpeed);
        GetComponent<Animator>().SetFloat("DeathSpeed", DeathAnimClipSpeed);
    }

    #endregion

    #region Animation Event
    //public void EventActivateAttack(GameObject ColliderAttack)
    //{
    //    ColliderAttack.SetActive(true);
    //}
    //
    //public void EventDeactivateAttack(GameObject ColliderAttack)
    //{
    //    ColliderAttack.SetActive(false);
    //}

    /// <summary>
    /// Evento: Attivazione del collider di attacco
    /// </summary>
    public void EventEnemyActivateCollider()
    {
        if (GetComponent<Animator>().GetBool("AI-LightAttack") == true)
        {
            LightAttackCollider.SetActive(true);

            if (AudioManager.instance != null)
            {
                switch (TypeEnemy)
                {
                    case TypeEnemies.FatKnight:
                        AudioManager.instance.Play("Sfx_FK_L_atk_swing");
                        break;

                    case TypeEnemies.BoriousKnight:
                        AudioManager.instance.Play("Sfx_BK_p_L_atk_swing");
                        break;

                    case TypeEnemies.Babushka:
                        AudioManager.instance.Play("Sfx_B_L_atk_swing");
                        break;

                    default:
                        break;
                }
            }
        }

        if (GetComponent<Animator>().GetBool("AI-HeavyAttack") == true)
        {
            HeavyAttackCollider.SetActive(true);

            if (AudioManager.instance != null)
            {
                switch (TypeEnemy)
                {
                    case TypeEnemies.FatKnight:
                        if (AudioManager.instance != null)
                        {
                            AudioManager.instance.Play("Sfx_FK_H_atk_swing");
                        }
                        break;

                    case TypeEnemies.BoriousKnight:
                        if (AudioManager.instance != null)
                        {
                            AudioManager.instance.Play("Sfx_BK_H_atk_swing");
                        }
                        break;

                    case TypeEnemies.Babushka:
                        if (AudioManager.instance != null)
                        {
                            AudioManager.instance.Play("Sfx_B_H_atk_swing");
                        }
                        break;

                    case TypeEnemies.Thief:
                        if (AudioManager.instance != null)
                        {
                            AudioManager.instance.Play("Sfx_T_H_atk_swing");
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }

    /// <summary>
    /// Evento: Disattivazione del collider di attacco
    /// </summary>
    public void EventEnemyDeactivateCollider()
    {
        if (GetComponent<Animator>().GetBool("AI-LightAttack") == true)
        {
            LightAttackCollider.SetActive(false);
        }
        if (GetComponent<Animator>().GetBool("AI-HeavyAttack") == true)
        {
            HeavyAttackCollider.SetActive(false);
        }

    }

    /// <summary>
    /// Evento: Va nell'ultimo frame dell'attacco, serve per passare allo stato successivo dell'attacco - Exit
    /// </summary>
    public void EventEnemyFinishAttack()
    {
        if (GetComponent<Animator>().GetBool("AI-LightAttack") == true)
        {
            GetComponent<Animator>().SetBool("AI-LightAttack", false);
        }
        if (GetComponent<Animator>().GetBool("AI-HeavyAttack") == true)
        {
            GetComponent<Animator>().SetBool("AI-HeavyAttack", false);
        }
    }
    #endregion
    public void EventEnemyArrowThief()
    {
        GameObject GoArrow = Instantiate(ArrowThief, SpawnArrow.transform.position, transform.rotation);
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_T_L_atk");
        }
    }
    #endregion

    public void EventEnemyDeactiveGameObject()
    {
        gameObject.SetActive(false);

        if (transform.rotation.eulerAngles.y == 0)
        {

            GameObject tempDeathEffect = Instantiate(deathEffect, new Vector2(transform.position.x + 1.3f, transform.position.y - 1), Quaternion.Euler(-90, 0, 0));
            Destroy(tempDeathEffect, 2f);
        }
        else
        {
            GameObject tempDeathEffect = Instantiate(deathEffect, new Vector2(transform.position.x - 1.3f, transform.position.y - 1), Quaternion.Euler(-90, 0, 0));
            Destroy(tempDeathEffect, 2f);
        }
    }

    #region Trigger Zone

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 14 && DashFatKnightEffect == false)
        {
            DashFatKnightEffect = true;
            CountPoiseEnemy += ValuePoiseKnockbackFatKnight;
            GetComponent<Animator>().SetTrigger("DamageReceived");
            if (CountPoiseEnemy >= MaxCountPoiseEnemy)
            {
                GetComponent<Animator>().SetBool("IsStagger", true);
            }
        }

        if (collision.gameObject.layer == 15 && DashBabushkaEffect == false)
        {
            DashBabushkaEffect = true;
            Life -= DamageDashBabushka;
            GetComponent<Animator>().SetFloat("Life", Life);
            CountPoiseEnemy += ValuePoiseKnockbackBabushka;
            GetComponent<Animator>().SetTrigger("DamageReceived");
            if (CountPoiseEnemy >= MaxCountPoiseEnemy)
            {
                GetComponent<Animator>().SetBool("IsStagger", true);
            }

            ColorChangeController colorChangeController = GetComponent<ColorChangeController>();
            colorChangeController.isAttacked = true;
            GetComponentInChildren<EnemyParticleController>().PlayBlood();
        }
    }
    //
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        print("COLLIDE CON IL PLAYER" + this.name);
    //        CanVisible = true;
    //        GetComponent<Animator>().SetBool("IsFollowing", true);
    //    }
    //}
    //
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 14 && DashFatKnightEffect == true)
        {
            DashFatKnightEffect = false;
        }
        if (collision.gameObject.layer == 15 && DashBabushkaEffect == true)
        {
            DashBabushkaEffect = false;
        }
    }

    #endregion

    public void EventEnemyStaggerFinish()
    {
        GetComponent<Animator>().SetTrigger("AI-FromStaggerToIdle");

    }
}
public enum TypeEnemies
{
    FatKnight,
    BoriousKnight,
    Babushka,
    Thief
}
