using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region Life Behaviour / Stun Sub-Behaviour - Possession Sub-Behaviour
    [Space(10)]
    [Header("------------------------ Life Behaviour -----------------------------------------------------------------------------------------------------------------------------")]
    [Tooltip("Indica la vita del player")]
    public int Life;    //life behaviour, indica la vita del player
    
    [Header("   ►  First Method - From stun to destoy")]
    [Header("~~~ Stun Sub-Behaviour ~~~ Value Management")]
    [Space(10)]
    [ReadOnly] public float timerStun = 0;         //stun behaviour o life behaviour, è il timer di stun - readonly
    [Tooltip("Indica la durata dello stato di stun prima che il personaggio si distrugga")]
    public float DurationStun = 5;      //stun behaviour o life behaviour, max value of timer di stun 
    
    [Header("   ►  Second Method - From stun to destoy")]
    [ReadOnly] public int CountHit = 0;            //Stunned behaviour quindi potremmo metterlo nel life behaviour, indica quanti colpi ha dato il player al nemico dopo lo stun - readonly
    [Tooltip("Indica quanti attacchi da parte del player servano prima che il personaggio si distrugga")]
    public int MaxCountHit = 0;         //Stunned behaviour quindi potremmo metterlo nel life behaviour, indica il max dei colpi prima di scomparire
    [Header("   ►  Boolean for know if state stun is active or not - ReadOnly")]
    [ReadOnly]public bool isStun = false;
    
    [Header("   ►  Boolean for the know if the player can possess this enemy - ReadOnly")]
    [Header("~~~ Possesion Sub-Behaviour ~~~")]
    [Space(10)]
    [ReadOnly] public bool isPossessed = false; //Behaviour? forse life o stun, indica se l'enemy può essere posseduto oppure no
    #endregion

    #region Movement Behaviour
    [Space(10)]
    [Header("------------------------ Movement Behaviour -----------------------------------------------------------------------------------------------------------------------------")]

    public float Speed;             //Movement Behaviour - Velocità di movimento

    [Space(10)]
    [Header("►  Path Movement - Array")]
    public GameObject[] WaypointEnemy;  //Movement Behaviour Lista di waypoint per il path

    [ReadOnly] public int WaypointIndex;       //Movement Behaviour - Indice del waypoint = readonly
    
    [Space(10)]
    [Header("►  Value for indicate if the player can move")]
    [Tooltip("Condition - Standard: True - 'Temp false for ranged'")]
    public bool CanMove = true;      //Indica se il player si può muovere - si potrebbe anche usare se un nemico non si può muovere
    
    [Space(10)]
    [Header("►  Variables for control when the player is in aggro")]
    [ReadOnly] public GameObject PlayerEnemy;      //Movement Behaviour e Attack Behaviour - nel movement serve per andare in contro al player e nell'attack serve per la distance per il reset
    
    [ReadOnly] public bool CanVisible = false; //Movement Bahaviour e Attack Behaviour - Indica se il nemico viene visto (quindi se entra nel collider trigger) - readonly
    #endregion
    
    #region Variables Attack Behaviour
    [Space(10)]
    [Header("►  Collider Attack - Light And Heavy")]
    [Header("------------------------ Attack Behaviour -----------------------------------------------------------------------------------------------------------------------------")]
    public GameObject LightAttackCollider;
    public GameObject HeavyAttackCollider;

    [Space(10)]
    [Header("►  Percentuage of spawn of collider attack - Light And Heavy")]
    [Tooltip("Da 0 a Percentuage corrisponde al light attack, da percentuage a 100 è heavy attack\n0 <= Percentuage = Light && Percentuage >= 100 = Heavy")][Range(0,100)]
    public int PercentuageAttack;
    [ReadOnly] public int random;              //Attack Bahaviour - Variabile per la pesca random per poi confrontare con la percentuale
    [Tooltip("Sarebbe la variabile che indica che il random può attivarsi")]
    [ReadOnly] public bool CanAttack = true;   //Attack Behaviour - Indica la nuova estrazione del valore random riferito alla percentuale della scelta dell'attacco

    [Space(10)]
    [Header("►  Value of damage of typology of attack - Value Management")]
    public int LightDamage;
    public int HeavyDamage;
    public int SpecialDamage;
    
    [Space(10)]
    [Header("►  Cycle Light Attack - Value Management")]
    
    [ReadOnly] public float InitialTimerLight;
    [Tooltip("Pre-Attack: Indica la durata di attesa prima del primo attacco, alla fine del quale si attiva il collider di attacco - Fa parte del ciclo iniziale")]
    public float MaxInitialTimerLight;                          //Dopo tot secondi parte il primo ciclo attivando il collider
    [ReadOnly] public bool FirstCycleLight = true;              //Questo booleano indica se va eseguito prima il primo ciclo
    [ReadOnly] public float DeactiveColliderTimerLight;
    [Tooltip("Mid-Attack: Indica la durata di attesa in cui il collider di attacco sta acceso, alla fine del quale si spegne il coollider di attacco - Fa parte di tutti i cicli ")]
    public float MaxDeactiveColliderTimerLight;                 //Dopo tot secondi disattiva il collider
    [ReadOnly] public bool CooldownLight;                       //Questo booleano indica quando è attivo e disattivo il cooldown - Vero indica che è uscito da cooldown - Falso indica che deve entrare nel cooldown
    [ReadOnly] public float CooldownTimerLight;
    [Tooltip("Pre/Post-Attack: Indica la durata di cooldown dell'attacco per poterlo ripetere, alla fine del quale il cooldown finisce e fa partire il timer Mid-Attack ")]
    public float MaxCooldownTimerLight;                         //Dopo tot secondi finisce il cooldown
    
    [Space(10)]
    [Header("►  Cycle Heavy Attack - Value Management")]

    [ReadOnly] public float InitialTimerHeavy;
    [Tooltip("Pre-Attack: Indica la durata di attesa prima del primo attacco, alla fine del quale si attiva il collider di attacco - Fa parte del ciclo iniziale")]
    public float MaxInitialTimerHeavy;                          //Dopo tot secondi parte il primo ciclo attivando il collider
    [ReadOnly]public bool FirstCycleHeavy = true;               //Questo booleano indica se va eseguito prima il primo ciclo
    [ReadOnly] public float DeactiveColliderTimerHeavy;
    [Tooltip("Mid-Attack: Indica la durata di attesa in cui il collider di attacco sta acceso, alla fine del quale si spegne il coollider di attacco - Fa parte di tutti i cicli ")]
    public float MaxDeactiveColliderTimerHeavy;                 //Dopo tot secondi disattiva il collider
    [ReadOnly] public bool CooldownHeavy;                       //Questo booleano indica quando è attivo e disattivo il cooldown - Vero indica che è uscito da cooldown - Falso indica che deve entrare nel cooldown
    [ReadOnly] public float CooldownTimerHeavy;
    [Tooltip("Pre/Post-Attack: Indica la durata di cooldown dell'attacco per poterlo ripetere, alla fine del quale il cooldown finisce e fa partire il timer Mid-Attack ")]
    public float MaxCooldownTimerHeavy;                         //Dopo tot secondi finisce il cooldown
    
    [Space(10)]
    [Header("►  Reset Cycle Attack - Value Management - ReadOnly")]
    [ReadOnly] public bool CanReset = false;                    //Resetta i timer e i booleani di attacco quando il player esce fuori dall'aggro, visto che lo resettava ad ogni attaco, è stato strutturato tramite il controllo della distanza
    #endregion


    #region OLD - Variables
    //public float LightTimerEnemyAttack;
    //public float HeavyTimerEnemyAttack;
    //[Tooltip("Cooldown attacco leggero - Indica il tempo che passa tra un attacco e l'altro, si resetta quando si disattiva il collider dell'attacco leggero")]
    //public float LightMaxTimerEnemyAttack;
    //[Tooltip("Cooldown attacco pesante - Indica il tempo che passa tra un attacco e l'altro, si resetta quando si disattiva il collider dell'attacco pesante")]
    //public float HeavyMaxTimerEnemyAttack;
    //[Tooltip("Timer Collider Leggero Acceso - Indica la durata di quando il collider leggero è attivo")]
    //public float LightTimerAttackActivate;
    //[Tooltip("Timer Collider Pesante Acceso - Indica la durata di quando il collider Pesante è attivo")]
    //public float HeavyTimerAttackActivate;
    //[Tooltip("Pre Attack Leggero - Indica il tempo precedente all'attivazione del collider ma viene dopo il cooldown")]
    //public float LightTimerAnimation;
    //[Tooltip("Pre Attack Pesante - Indica il tempo precedente all'attivazione del collider ma viene dopo il cooldown")]
    //public float HeavyTimerAnimation;

    //[HideInInspector]public float TempTimerLight;
    //[HideInInspector]public float TempTimerHeavy;
    //[HideInInspector]public float Temp2TimerLight;
    //[HideInInspector]public float Temp2TimerHeavy;
    //public bool isActiveLight;
    //public bool isActiveHeavy
    #endregion


    void Update()
    {
        Stunned();
        Routine();
        Attack();

        float Distance = Vector2.Distance(gameObject.transform.position, PlayerEnemy.transform.position);
        print("Distance" + Distance);
        if (Distance >= 2.3f)       //Il 2.3f sarnne il possession radius
        {
            CanReset = true;
        }
        else
        {
            CanReset = false;
        }
        //AttivatiLeggero();
        //AttivatiPesante();
    }

    #region Method - IA - Enemy Behaviour
    public void Routine()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (WaypointIndex <= WaypointEnemy.Length - 1 && CanVisible == false && CanMove == true)
        {

            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(WaypointEnemy[WaypointIndex].transform.position.x, transform.position.y), Speed * Time.deltaTime);
            if(WaypointEnemy[WaypointIndex].transform.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);           //Destra
            }
            else
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, -180, transform.rotation.z);         //Sinistra
            }
            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (transform.position.x == WaypointEnemy[WaypointIndex].transform.position.x)
            {
                WaypointIndex += 1;
                if (WaypointIndex == WaypointEnemy.Length)
                {
                    WaypointIndex = 0;
                }
            }
        }
        if(CanVisible == true)
        {
            if(PlayerEnemy != null)
            {
                if (PlayerEnemy.transform.position.x + 1 > transform.position.x)
                {
                    transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);           //Destra
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(PlayerEnemy.transform.position.x - 1, transform.position.y), Speed * Time.deltaTime);
                }
                else if(PlayerEnemy.transform.position.x - 1 < transform.position.x)
                {
                    transform.rotation = Quaternion.Euler(transform.rotation.x, -180, transform.rotation.z);         //Sinistra
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(PlayerEnemy.transform.position.x + 1, transform.position.y), Speed * Time.deltaTime);
                }


                //In caso sfarfallasse il nemico
                if(transform.position.x == PlayerEnemy.transform.position.x + 1)
                {
                    CanMove = false;
                }
                else
                {
                    CanMove = true;
                }
                if(transform.position.x == PlayerEnemy.transform.position.x - 1)
                {
                    CanMove = false;
                }
                else
                {
                    CanMove = true;
                }
            }
        }
    }

    public void Stunned()
    {
        if (Life <= 0)
        {
            isStun = true;
            CanMove = false;
            GetComponent<SpriteRenderer>().color = Color.red;
            if (isStun == true && isPossessed == false)
            {
                timerStun += Time.deltaTime;
                if (MaxCountHit >= CountHit)
                {
                    Destroy(this.gameObject);
                }
                if (timerStun >= DurationStun)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    public void Attack()
    {
        //Slider x2 in cui si può settare la percentuale random - Light/Heavy
        //Pesca il valore randomico per poi passarlo allo switch
        //Switch in cui attiva l'attacco
        if(CanAttack == true)
        {
            random = Random.Range(0, 101);
            print("Random"+random);
            CanAttack = false;
        }
        if(CanVisible == true)                                          //Do while --> nel senso ha un xtempo iniziale + un cooldown dopo, quindi do è x tempo e cooldown sta nel while
        {
            if (random <= PercentuageAttack)
            {
                ActivateDifferentCicleLight();
                /*LightTimerEnemyAttack += Time.deltaTime;
                if (LightTimerEnemyAttack >= LightMaxTimerEnemyAttack)  //Prima ciclo, con un booleano diverrà falso per poi attivare il secondo ciclo in poi, se riesce e rientra dall'aggro, ricomincia dal ciclo uno
                {
                    print("Enemy Light Attack");
                    if (LightAttackCollider != null)
                    {
                        isActiveLight = true;
                        StartCoroutine(LightTimerAttack());
                        //TempTimerLight += Time.deltaTime;
                        //if (TempTimerLight >= LightTimerAnimation)
                        //{
                        //    LightAttackCollider.SetActive(true);
                        //    Temp2TimerLight += Time.deltaTime;
                        //    if (Temp2TimerLight >= LightTimerAttackActivate)
                        //    {
                        //        LightAttackCollider.SetActive(false);
                        //        LightTimerEnemyAttack = 0;
                        //        TempTimerLight = 0;
                        //        Temp2TimerLight = 0;
                        //        CanAttack = true;
                        //    }
                        //}
                    }
                }*/
            }
            else
            {
                ActivateDifferentCicleHeavy();
                /*HeavyTimerEnemyAttack += Time.deltaTime;
                if (HeavyTimerEnemyAttack >= HeavyMaxTimerEnemyAttack)
                {
                    print("Enemy Heavy Attack"+HeavyTimerEnemyAttack);
                    if (LightAttackCollider != null)
                    {
                        isActiveHeavy = true;
                        StartCoroutine(HeavyTimerAttack());
                        //TempTimerHeavy += Time.deltaTime;
                        //if (TempTimerHeavy >= HeavyTimerAnimation)
                        //{
                        //    HeavyAttackCollider.SetActive(true);
                        //    Temp2TimerHeavy += Time.deltaTime;
                        //    if (Temp2TimerHeavy >= HeavyTimerAttackActivate)
                        //    {
                        //        HeavyAttackCollider.SetActive(false);
                        //        TempTimerHeavy = 0;
                        //        Temp2TimerHeavy = 0;
                        //        HeavyTimerEnemyAttack = 0;
                        //        CanAttack = true;
                        //    }
                        //}

                    }
                }*/
            }
        }
    }

    public void ActivateDifferentCicleLight()
    {
        if (FirstCycleLight == true)                                                                //Se siamo al primo ciclo di attacco
        {
            InitialTimerLight += Time.deltaTime;                                                    //Faccio partire il timer initiale di attesa per l'attacco

            //Qua andrà messo un if in cui quando il timer del cooldown raggiunge un determinato valore, attiverà l'animazione di attacco

            if (InitialTimerLight >= MaxInitialTimerLight)                                          //Se il timer iniziale raggiunge il valore max, vado ad attivare l'attacco - Collider
            {
                LightAttackCollider.SetActive(true);                                                //Attivo il collider dell'attacco - Attivo attacco
                DeactiveColliderTimerLight += Time.deltaTime;                                       //Faccio partire il timer per disattivare il collider, quindi indica la durata di quando c'è il collider acceso
                if(DeactiveColliderTimerLight >= MaxDeactiveColliderTimerLight)                     //Se il timer di disattiazione raggiunge il valore max, vado a disattivare l'attacco - Collider
                {
                    LightAttackCollider.SetActive(false);                                           //Disattivo il collider dell'attacco - Disattivo attaco
                    FirstCycleLight = false;                                                        //Setto a falso il primo ciclo, quindi indica la fine di questo ciclo
                    InitialTimerLight = 0;                                                          //Resetto il timer iniziale a 0
                    DeactiveColliderTimerLight = 0;                                                 //Resetto il timer di disattivazione a 0
                }
            }
        }
        if (FirstCycleLight == false && CooldownLight == false)                                     //Se il primo ciclo è falso, quindi ci troviamo dal secondo in poi, e non siamo ancora nel cooldown e/o non è finito
        {
            CooldownTimerLight += Time.deltaTime;                                                   //Faccio partire il timer del cooldown per ripetere l'attacco
            
            //Qua andrà messo un if in cui quando il timer del cooldown raggiunge un determinato valore, attiverà l'animazione di attacco
            
            if(CooldownTimerLight >= MaxCooldownTimerLight)                                         //Se il timer cooldown raggiunge il valore max, indica che il cooldown è finito e quindi vado ad attivare l'attacco
            {
                LightAttackCollider.SetActive(true);                                                //Attivo il collider dell'attacco - Attivo attacco
                CooldownLight = true;                                                               //Questa booleana indica che abbiamo finito il cooldown e che al momento non ci dobbiamo rientrare
                DeactiveColliderTimerLight = 0;                                                     //Resetto il timer di disattivazione del collider a 0
            }
        }
        DeactiveColliderTimerLight += Time.deltaTime;                                               //Faccio partire il timer di disattivazione del collider
        if (DeactiveColliderTimerLight >= MaxDeactiveColliderTimerLight && CooldownLight == true)   //Se il timer di disattivazione raggiunge il valore max e siamo fuori dal cooldown
        {
            LightAttackCollider.SetActive(false);                                                   //Disattivo il collider dell'attacco - Disattivo attaco
            CooldownLight = false;                                                                  //Setto a falso la variabile del cooldown indicando l'inizio del cooldown
            CooldownTimerLight = 0;                                                                 //Resetto il timer del cooldown a 0
            DeactiveColliderTimerLight = 0;                                                         //Resetto il timer di disattivazione a 0
        }
    }
    public void ActivateDifferentCicleHeavy()
    {
        if (FirstCycleHeavy == true)                                                                //Se siamo al primo ciclo di attacco
        {
            InitialTimerHeavy += Time.deltaTime;                                                    //Faccio partire il timer initiale di attesa per l'attacco

            //Qua andrà messo un if in cui quando il timer del cooldown raggiunge un determinato valore, attiverà l'animazione di attacco

            if (InitialTimerHeavy >= MaxInitialTimerHeavy)                                          //Se il timer iniziale raggiunge il valore max, vado ad attivare l'attacco - Collider
            {
                LightAttackCollider.SetActive(true);                                                //Attivo il collider dell'attacco - Attivo attacco
                DeactiveColliderTimerHeavy += Time.deltaTime;                                       //Faccio partire il timer per disattivare il collider, quindi indica la durata di quando c'è il collider acceso
                if (DeactiveColliderTimerHeavy >= MaxDeactiveColliderTimerHeavy)                    //Se il timer di disattiazione raggiunge il valore max, vado a disattivare l'attacco - Collider
                {
                    LightAttackCollider.SetActive(false);                                           //Disattivo il collider dell'attacco - Disattivo attaco
                    FirstCycleHeavy = false;                                                        //Setto a falso il primo ciclo, quindi indica la fine di questo ciclo
                    InitialTimerHeavy = 0;                                                          //Resetto il timer iniziale a 0
                    DeactiveColliderTimerHeavy = 0;                                                 //Resetto il timer di disattivazione a 0
                }
            }
        }
        if (FirstCycleHeavy == false && CooldownHeavy == false)                                     //Se il primo ciclo è falso, quindi ci troviamo dal secondo in poi, e non siamo ancora nel cooldown e/o non è finito
        {
            CooldownTimerHeavy += Time.deltaTime;                                                   //Faccio partire il timer del cooldown per ripetere l'attacco

            //Qua andrà messo un if in cui quando il timer del cooldown raggiunge un determinato valore, attiverà l'animazione di attacco

            if (CooldownTimerHeavy >= MaxCooldownTimerHeavy)                                        //Se il timer cooldown raggiunge il valore max, indica che il cooldown è finito e quindi vado ad attivare l'attacco
            {
                HeavyAttackCollider.SetActive(true);                                                //Attivo il collider dell'attacco - Attivo attacco
                CooldownHeavy = true;                                                               //Questa booleana indica che abbiamo finito il cooldown e che al momento non ci dobbiamo rientrare
                DeactiveColliderTimerHeavy = 0;                                                     //Resetto il timer di disattivazione del collider a 0
            }
        }
        DeactiveColliderTimerHeavy += Time.deltaTime;                                               //Faccio partire il timer di disattivazione del collider
        if (DeactiveColliderTimerHeavy >= MaxDeactiveColliderTimerHeavy && CooldownHeavy == true)   //Se il timer di disattivazione raggiunge il valore max e siamo fuori dal cooldown
        {
            HeavyAttackCollider.SetActive(false);                                                   //Disattivo il collider dell'attacco - Disattivo attaco
            CooldownHeavy = false;                                                                  //Setto a falso la variabile del cooldown indicando l'inizio del cooldown
            CooldownTimerHeavy = 0;                                                                 //Resetto il timer del cooldown a 0
            DeactiveColliderTimerHeavy = 0;                                                         //Resetto il timer di disattivazione a 0
        }
    }

    /*public void AttivatiLeggero()
    {
        if(isActiveLight == true)
        {
            StartCoroutine(LightTimerAttack());
        }
    }
    public void AttivatiPesante()
    {
        if(isActiveHeavy == true)
        {
            StartCoroutine(HeavyTimerAttack());
        }
    }
    public IEnumerator LightTimerAttack()
    {

        //while (isActiveLight)
        //{
            yield return new WaitForSeconds(LightTimerAnimation);
            LightAttackCollider.SetActive(true);
            yield return new WaitForSeconds(LightTimerAttackActivate);
            LightAttackCollider.SetActive(false);
            LightTimerEnemyAttack = 0;
            CanAttack = true;
            print("Ciao1");
            isActiveLight = false;
        //}

    }
    public IEnumerator HeavyTimerAttack()
    {
        //while (isActiveHeavy)
        //{
            yield return new WaitForSeconds(HeavyTimerAnimation);
            HeavyAttackCollider.SetActive(true);
            yield return new WaitForSeconds(HeavyTimerAttackActivate);
            HeavyAttackCollider.SetActive(false);
            HeavyTimerEnemyAttack = 0;
            CanAttack = true;
            isActiveHeavy = false;
        print("Ciao2");
        //}
    }*/
    #endregion

    #region Trigger Zone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            CanVisible = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CanVisible = false;
        }
    }
    #endregion
}



//Cose da aggiungere:
//- Devo mettere il controllo sull'esistenza dei waypoint