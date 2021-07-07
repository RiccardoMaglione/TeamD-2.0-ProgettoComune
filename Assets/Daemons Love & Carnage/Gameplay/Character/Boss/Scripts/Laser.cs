using SwordGame;
using UnityEngine;
public class Laser : MonoBehaviour
{
    public float damage;
    public bool playerDamaged = false;

    private float timerDMG = 0.5f;
    private float timer;

    private void Update()
    {
        if (playerDamaged && timer < timerDMG)
        {
            timer += Time.deltaTime;
        }

        if (playerDamaged && timer >= timerDMG)
        {
            playerDamaged = false;
            timer = 0;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && playerDamaged == false)
        {
            collision.GetComponent<PSMController>().CurrentHealth -= damage;
            playerDamaged = true;
            GetHitScript.getHitScript.gameObject.SetActive(false);
            GetHitScript.getHitScript.gameObject.SetActive(true);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && playerDamaged == false)
        {
            collision.GetComponent<PSMController>().CurrentHealth -= damage;
            playerDamaged = true;
            GetHitScript.getHitScript.gameObject.SetActive(false);
            GetHitScript.getHitScript.gameObject.SetActive(true);
        }

    }
}
