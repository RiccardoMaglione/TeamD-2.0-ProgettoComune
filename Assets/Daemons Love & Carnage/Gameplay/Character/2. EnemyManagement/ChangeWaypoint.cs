﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class ChangeWaypoint : MonoBehaviour
{
    public List<GameObject> ListWaypoint = new List<GameObject>();
    public GameObject PlayerAggro;
    public List<GameObject> EnemyAggro = new List<GameObject>();
    public bool PlayerSee;
    public int InitialOrderLayer = 7;
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
                if (EnemyAggro[i].GetComponent<EnemyData>().isActiveAndEnabled == true)
                {
                    EnemyAggro[i].GetComponent<Animator>().SetBool("IsFollowing", false);
                }
                EnemyAggro[i].GetComponent<EnemyData>().CanReset = true;

                EnemyAggro[i].GetComponent<EnemyData>().GetComponent<SpriteRenderer>().sortingOrder = InitialOrderLayer - i;
            }
        }
        if (collision.tag == "Player")
        {
            for (int i = 0; i < EnemyAggro.Count; i++)
            {
                EnemyAggro[i].GetComponent<EnemyData>().CanVisible = true;
                if (EnemyAggro[i].GetComponent<EnemyData>().isActiveAndEnabled == true)
                {
                    EnemyAggro[i].GetComponent<Animator>().SetBool("IsFollowing", true);
                }
                EnemyAggro[i].GetComponent<EnemyData>().CanReset = false;
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
                if (EnemyAggro[i].GetComponent<EnemyData>().isActiveAndEnabled == true)
                {
                    EnemyAggro[i].GetComponent<Animator>().SetBool("IsFollowing", true);
                }
                EnemyAggro[i].GetComponent<EnemyData>().CanReset = false;
                PlayerSee = true;
            }
        }

        if (collision.tag == "Enemy" && collision.tag != "Player")
        {
            collision.GetComponent<EnemyData>().PlayerEnemy = PlayerAggro;
            collision.GetComponent<PossessionV2>().PlayerDetect = PlayerAggro;
            if(PlayerSee == false)
            {
                for (int i = 0; i < EnemyAggro.Count; i++)
                {
                    EnemyAggro[i].GetComponent<EnemyData>().CanVisible = false;
                    if (EnemyAggro[i].GetComponent<EnemyData>().isActiveAndEnabled == true)
                    {
                        EnemyAggro[i].GetComponent<Animator>().SetBool("IsFollowing", false);
                    }
                    EnemyAggro[i].GetComponent<EnemyData>().CanReset = true;
                    EnemyAggro[i].GetComponent<EnemyData>().GetComponent<SpriteRenderer>().sortingOrder = InitialOrderLayer - i;
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
                if (EnemyAggro[i].GetComponent<EnemyData>().isActiveAndEnabled == true)
                {
                    EnemyAggro[i].GetComponent<Animator>().SetBool("IsFollowing", false);
                }
                EnemyAggro[i].GetComponent<EnemyData>().CanReset = true;
                PlayerSee = true;
            }
        }
        if(collision.tag == "Enemy")
        {
            for (int i = 0; i < EnemyAggro.Count; i++)
            {
                if (collision.gameObject == EnemyAggro[i])
                {
                    EnemyAggro.RemoveAt(i);
                }
            }
        }
    }
}
