using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int Life;

    public int LightDamage;
    public int HeavyDamage;
    public int SpecialDamage;

    public bool isStun = false;
    public float timerStun = 0;
    public float DurationStun = 5;


    public bool isPossessed = false;

    public int CountHit = 0;
    public int MaxCountHit = 0;


    public GameObject[] WaypointEnemy;

    public int WaypointIndex;
    public float Speed;
    public GameObject PlayerEnemy;

    public bool CanVisible = false;

    [Tooltip("Da 0 a Percentuage corrisponde al light attack, da percentuage a 100 è heavy attack\n0 <= Percentuage = Light && Percentuage >= 100 = Heavy")][Range(0,100)]
    public int PercentuageAttack;
    public float LightTimerEnemyAttack;
    public float HeavyTimerEnemyAttack;
    [Tooltip("Cooldown attacco leggero - Indica il tempo che passa tra un attacco e l'altro, si resetta quando si disattiva il collider dell'attacco leggero")]
    public float LightMaxTimerEnemyAttack;
    [Tooltip("Cooldown attacco pesante - Indica il tempo che passa tra un attacco e l'altro, si resetta quando si disattiva il collider dell'attacco pesante")]
    public float HeavyMaxTimerEnemyAttack;
    public GameObject LightAttackCollider;
    public GameObject HeavyAttackCollider;
    [Tooltip("Timer Collider Leggero Acceso - Indica la durata di quando il collider leggero è attivo")]
    public float LightTimerAttackActivate;
    [Tooltip("Timer Collider Pesante Acceso - Indica la durata di quando il collider Pesante è attivo")]
    public float HeavyTimerAttackActivate;
    [Tooltip("Pre Attack Leggero - Indica il tempo precedente all'attivazione del collider ma viene dopo il cooldown")]
    public float LightTimerAnimation;
    [Tooltip("Pre Attack Pesante - Indica il tempo precedente all'attivazione del collider ma viene dopo il cooldown")]
    public float HeavyTimerAnimation;
    public bool CanMove = true;

    public int random;
    public bool CanAttack = true;

    [HideInInspector]public float TempTimerLight;
    [HideInInspector]public float TempTimerHeavy;
    [HideInInspector]public float Temp2TimerLight;
    [HideInInspector]public float Temp2TimerHeavy;
    public bool isActiveLight;
    public bool isActiveHeavy;


    void Update()
    {
        Stunned();
        Routine();
        Attack();
        AttivatiLeggero();
        AttivatiPesante();
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
        if(CanVisible == true)
        {
            if (random <= PercentuageAttack)
            {
                LightTimerEnemyAttack += Time.deltaTime;
                if (LightTimerEnemyAttack >= LightMaxTimerEnemyAttack)
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
                }
            }
            else
            {
                HeavyTimerEnemyAttack += Time.deltaTime;
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
                }
            }
        }
    }

    public void AttivatiLeggero()
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
    }
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