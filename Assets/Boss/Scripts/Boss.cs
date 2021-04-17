﻿using SwordGame;
using UnityEngine;

public class Boss : MonoBehaviour

{
    public int damage;
    public bool canDamage = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && canDamage == true)
        {
            collision.GetComponent<PSMController>().CurrentHealth -= damage;
            Debug.LogWarning(damage + " BOSS DAMAGE");
        }
    }

    public int life = 100;
}
