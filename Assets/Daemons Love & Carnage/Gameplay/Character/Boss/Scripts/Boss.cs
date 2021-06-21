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

    [SerializeField] float threshold1;
    [SerializeField] float threshold2;

    [SerializeField] Animator animator;

    public GameObject laserManager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && playerDamaged == false && canDamage == true)
        {
            collision.GetComponent<PSMController>().CurrentHealth -= damage;
            playerDamaged = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && playerDamaged == false && canDamage == true)
        {
            collision.GetComponent<PSMController>().CurrentHealth -= damage;
            playerDamaged = true;            
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

        if (life <= 0)
        {
            laserManager.SetActive(false);
            VictoryScreen.win = true;
            animator.SetBool("GoToDeath", true);
            animator.SetBool("GoToPhase2", false);
            animator.SetBool("GoToPhase3", false);
            animator.SetBool("Laser", false);
        }

        if (life < threshold2 && life > 0)
        {
            animator.SetBool("GoToPhase2", false);
            animator.SetBool("GoToPhase3", true);
        }

        if (life < threshold1 && life > threshold2 - 1)
        {
            animator.SetBool("GoToPhase2", true);
        }
    }

    private void Awake()
    {
        maxLife = life;
        if (instance == null)
            instance = this;
    }
}
