using System.Collections;
using UnityEngine;

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
    public GameObject shotPoint2;


    private Animator anim;
    public bool aiming;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
            if (aiming == false)
                StartCoroutine("Shoot");


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //StopCoroutine("Shoot");
            playerInRange = false;
            anim.SetBool("Shooting", false);

        }
    }

    public IEnumerator Shoot()
    {

        aiming = true;
        yield return new WaitForSeconds(timeBetweenShot);
        aiming = false;
        anim.SetBool("Shooting", true);


        //Destroy(go, destroyBulletTime);

    }

}
