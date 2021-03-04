using UnityEngine;

public class CrossbowTrap : MonoBehaviour
{
    public bool playerInRange;
    public bool canShot;
    public bool cooldownIsActive;
    public bool touchRangeStartCrono;

    public float delayAttak = 0f;
    public float cooldownTrap = 0f;

    public GameObject bullet;
    public GameObject shotPoint;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
            touchRangeStartCrono = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    private void Update()
    { 
        /// aggiustare il range //while

        if (touchRangeStartCrono)
        {
            delayAttak += Time.deltaTime;

            if(delayAttak >= 1f) //delay
            {
                canShot = true;
                delayAttak = 0f;
                touchRangeStartCrono = false;
            }
        }

        if(canShot == true && !cooldownIsActive)
        {
            Instantiate(bullet, shotPoint.transform.position, transform.rotation);
            canShot = false;
            cooldownIsActive = true;
        }

        if (cooldownIsActive)
        {
            cooldownTrap += Time.deltaTime;
            touchRangeStartCrono = false;

            if(cooldownTrap >= 3f)
            {
                cooldownIsActive = false;
                cooldownTrap = 0f;
            }
        }
    }
}
