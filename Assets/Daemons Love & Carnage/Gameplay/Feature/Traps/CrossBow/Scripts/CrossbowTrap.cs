using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrossbowTrap : MonoBehaviour
{
    [Tooltip("bool che verifica se il player è nel range")]
    public bool playerInRange;
    [Tooltip("tempo tra un colpo e l'altro")]
    public float timeBetweenShot;
    [Tooltip("se non dovesse prendere il player o pareti si distruggerà dopo tot secondi")]
    public float destroyBulletTime;
    [Tooltip("bool che verifica se puo sparare")]
    public bool canShot = true;

    public GameObject bullet;
    public GameObject shotPoint;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
                playerInRange = true;

            if (canShot)
            {
                StartCoroutine("Shoot");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           playerInRange = false;
        }
    }

    IEnumerator Shoot()
    {
        AudioManager.instance.Play("Sfx_ballista_shots");

        while (playerInRange)
        {
            canShot = false;
            yield return new WaitForSeconds(timeBetweenShot);
            canShot = true;

            GameObject go = Instantiate(bullet, shotPoint.transform.position, transform.rotation);
            Destroy(go, destroyBulletTime);

        }      
    }
}
