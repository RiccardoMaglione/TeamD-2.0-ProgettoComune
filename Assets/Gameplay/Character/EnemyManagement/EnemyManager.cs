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
    public float TimerEnemyAttack;
    public float MaxTimerEnemyAttack;
    public GameObject LightAttackCollider;
    public GameObject HeavyAttackCollider;
    public float TimerAttackActivate;
    public float TimerAnimation;
    public bool CanMove = true;

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
        if(CanVisible == true)
        {
            TimerEnemyAttack += Time.deltaTime;
            if (TimerEnemyAttack >= MaxTimerEnemyAttack)
            {
                int random = Random.Range(0, 101);
        
                if (random <= PercentuageAttack)
                {
                    print("Enemy Light Attack");
                    if(LightAttackCollider != null)
                    {
                        StartCoroutine(LightTimerAttack());
                    }
                    TimerEnemyAttack = 0;
                }
                else
                {
                    print("Enemy Heavy Attack");
                    StartCoroutine(HeavyTimerAttack());
                    TimerEnemyAttack = 0;
                }
            }
        }
    }

    public IEnumerator LightTimerAttack()
    {
        yield return new WaitForSeconds(TimerAnimation);
        LightAttackCollider.SetActive(true);
        yield return new WaitForSeconds(TimerAttackActivate);
        LightAttackCollider.SetActive(false);
    }
    public IEnumerator HeavyTimerAttack()
    {
        yield return new WaitForSeconds(TimerAnimation);
        HeavyAttackCollider.SetActive(true);
        yield return new WaitForSeconds(TimerAttackActivate);
        HeavyAttackCollider.SetActive(false);
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