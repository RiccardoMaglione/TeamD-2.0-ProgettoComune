using SwordGame;
using UnityEngine;

public class TrapSpike : MonoBehaviour
{
    [Tooltip("conto alla rovescia per il ricaricamento")]
    [ReadOnly]
    public float cooldownTrap = 0f;

    [Tooltip("tempo ricarica della trappola")]
    public float rechargeTime;

    public bool cooldownIsActive;
    public int damageToPlayer;
    public int damageToEnemy;


    private void Start()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && cooldownIsActive == false && cooldownTrap <= 0f)
        {
            collision.gameObject.GetComponent<PSMController>().CurrentHealth -= damageToPlayer;
            GetHitScript.getHitScript.gameObject.SetActive(false);
            GetHitScript.getHitScript.gameObject.SetActive(true);

            cooldownIsActive = true;
        }
        if (collision.gameObject.tag == "Enemy" && cooldownIsActive == false && cooldownTrap <= 0f)
        {
            collision.gameObject.GetComponent<EnemyData>().Life -= damageToEnemy;
            cooldownIsActive = true;
        }

    }

    void Update()
    {
        if (cooldownIsActive)
        {
            cooldownTrap += Time.deltaTime;

            if (cooldownTrap >= rechargeTime)
            {
                cooldownIsActive = false;
                cooldownTrap = cooldownTrap = 0f;
            }
        }
    }
}
