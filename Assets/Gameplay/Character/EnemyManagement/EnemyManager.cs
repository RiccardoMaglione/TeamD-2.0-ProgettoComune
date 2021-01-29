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
    public GameObject Player;

    public bool CanVisible = false;

    void Update()
    {
        Stunned();
        Routine();
    }

    public void Routine()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (WaypointIndex <= WaypointEnemy.Length - 1 && CanVisible == false)
        {

            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(WaypointEnemy[WaypointIndex].transform.position.x, transform.position.y), Speed * Time.deltaTime);

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
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(Player.transform.position.x, transform.position.y), Speed * Time.deltaTime);
        }
    }

    public void Stunned()
    {
        if (Life <= 0)
        {
            isStun = true;
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
}
