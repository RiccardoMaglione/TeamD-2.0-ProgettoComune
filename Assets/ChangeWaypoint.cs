using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class ChangeWaypoint : MonoBehaviour
{
    public List<GameObject> ListWaypoint = new List<GameObject>();
    public GameObject PlayerAggro;
    public List<GameObject> EnemyAggro = new List<GameObject>();
    public bool PlayerSee;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyData>().WaypointEnemy.Clear();
            for (int i = 0; i < ListWaypoint.Count; i++)
            {
                collision.GetComponent<EnemyData>().WaypointEnemy.Add(ListWaypoint[i]);
            }
            EnemyAggro.Add(collision.gameObject);
            for (int i = 0; i < EnemyAggro.Count; i++)
            {
                EnemyAggro[i].GetComponent<EnemyData>().CanVisible = false;
                EnemyAggro[i].GetComponent<Animator>().SetBool("IsFollowing", false);
            }
        }
        if (collision.tag == "Player")
        {
            for (int i = 0; i < EnemyAggro.Count; i++)
            {
                EnemyAggro[i].GetComponent<EnemyData>().CanVisible = true;
                EnemyAggro[i].GetComponent<Animator>().SetBool("IsFollowing", true);
                PlayerSee = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerAggro = collision.gameObject;
            for (int i = 0; i < EnemyAggro.Count; i++)
            {
                EnemyAggro[i].GetComponent<EnemyData>().CanVisible = true;
                EnemyAggro[i].GetComponent<Animator>().SetBool("IsFollowing", true);
                PlayerSee = true;
            }
        }

        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyData>().PlayerEnemy = PlayerAggro;
            collision.GetComponent<PossessionV2>().PlayerDetect = PlayerAggro;
            if(PlayerSee == false)
            {
                for (int i = 0; i < EnemyAggro.Count; i++)
                {
                    EnemyAggro[i].GetComponent<EnemyData>().CanVisible = false;
                    EnemyAggro[i].GetComponent<Animator>().SetBool("IsFollowing", false);
                }
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; i < EnemyAggro.Count; i++)
            {
                EnemyAggro[i].GetComponent<EnemyData>().CanVisible = false;
                EnemyAggro[i].GetComponent<Animator>().SetBool("IsFollowing", false);
                PlayerSee = true;
            }
        }
    }
}
