using SwordGame;
using UnityEngine;

public class Boss : MonoBehaviour

{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PSMController>().CurrentHealth -= damage;
            Debug.LogWarning(damage + " BOSS DAMAGE");
        }
    }

    public int life = 100;
}
