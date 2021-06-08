using SwordGame;
using UnityEngine;

public class Boss : MonoBehaviour

{
    public int damage;
    public static bool canDamage = true;
    public float life = 100;
    [HideInInspector] public float maxLife;
    public float DMG_Reduction;
    public bool playerDamaged = false;
    private float canDamageTimerFloat;
    public float canDamageTimer = 1;

    public bool canGetDamage = true;

    public static Boss instance;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && playerDamaged == false && canDamage == true)
        {
            collision.GetComponent<PSMController>().CurrentHealth -= damage;
            playerDamaged = true;

            Debug.LogWarning(damage + " BOSS DAMAGE");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && playerDamaged == false && canDamage == true)
        {
            collision.GetComponent<PSMController>().CurrentHealth -= damage;
            playerDamaged = true;

            Debug.LogWarning(damage + " BOSS DAMAGE");
        }
    }

    private void Update()
    {
        if (playerDamaged == true)
        {
            canDamageTimerFloat += Time.deltaTime;
        }
        if (canDamageTimerFloat >= canDamageTimer)
        {
            playerDamaged = false;
            canDamageTimerFloat = 0;
        }
    }

    private void Awake()
    {
        maxLife = life;
        if (instance == null)
            instance = this;
    }
}
