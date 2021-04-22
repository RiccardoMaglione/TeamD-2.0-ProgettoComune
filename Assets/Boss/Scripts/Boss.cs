using SwordGame;
using UnityEngine;

public class Boss : MonoBehaviour

{
    public int damage;
    public static bool canDamage = true;
    public float life = 100;
    public float maxLife;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && canDamage == true)
        {
            collision.GetComponent<PSMController>().CurrentHealth -= damage;
            Debug.LogWarning(damage + " BOSS DAMAGE");
        }
    }

    

    private void Awake()
    {
        maxLife = life;
    }
}
