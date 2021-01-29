using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int Life;

    public int LightDamage;
    public int HeavyDamage;
    public int SpecialDamage;

    [ReadOnly] public bool isStun = false;
    [ReadOnly] public float timerStun = 0;
    public float DurationStun = 5;


    [ReadOnly] public bool isPossessed = false;

    [ReadOnly] public int CountHit = 0;
    public int MaxCountHit = 0;


    public GameObject[] WaypointEnemy;

    [ReadOnly] public int WaypointIndex;
    public float Speed;
    [ReadOnly] public GameObject PlayerEnemy;

    [ReadOnly] public bool CanVisible = false;

    [Tooltip("Da 0 a Percentuage corrisponde al light attack, da percentuage a 100 è heavy attack\n0 <= Percentuage = Light && Percentuage >= 100 = Heavy")][Range(0,100)]
    public int PercentuageAttack;
    [ReadOnly] public float LightTimerEnemyAttack;
    [ReadOnly] public float HeavyTimerEnemyAttack;
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
    [ReadOnly] public bool CanMove = true;

    [ReadOnly] public int random;
    [ReadOnly] public bool CanAttack;

    void Update()
    {
        Stunned();
        Routine();
        Attack();
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

                transform.position = Vector2.MoveTowards(transform.position, new Vector2(PlayerEnemy.transform.position.x, transform.position.y), Speed * Time.deltaTime);

                if (PlayerEnemy.transform.position.x > transform.position.x)
                {
                    transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);           //Destra
                }
                else
                {
                    transform.rotation = Quaternion.Euler(transform.rotation.x, -180, transform.rotation.z);         //Sinistra
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
                        StartCoroutine(LightTimerAttack());
                    }
                }
            }
            else
            {
                HeavyTimerEnemyAttack += Time.deltaTime;
                if (HeavyTimerEnemyAttack >= HeavyMaxTimerEnemyAttack)
                {
                    print("Enemy Heavy Attack");
                    StartCoroutine(HeavyTimerAttack());
                }
            }
        }
    }

    public IEnumerator LightTimerAttack()
    {
        yield return new WaitForSeconds(LightTimerAnimation);
        LightAttackCollider.SetActive(true);
        yield return new WaitForSeconds(LightTimerAttackActivate);
        LightAttackCollider.SetActive(false);
        LightTimerEnemyAttack = 0;
        CanAttack = false;
        print("Ciao1");
    }
    public IEnumerator HeavyTimerAttack()
    {
        yield return new WaitForSeconds(HeavyTimerAnimation);
        HeavyAttackCollider.SetActive(true);
        yield return new WaitForSeconds(HeavyTimerAttackActivate);
        HeavyAttackCollider.SetActive(false);
        HeavyTimerEnemyAttack = 0;
        CanAttack = false;
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