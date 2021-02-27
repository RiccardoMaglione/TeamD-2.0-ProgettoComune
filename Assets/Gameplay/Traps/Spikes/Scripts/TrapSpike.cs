using UnityEngine;

public class TrapSpike : MonoBehaviour
{
    [Tooltip("conto alla rovescia per il ricaricamento [solo lettura]")]
    public float cooldownTrap = 0f;

    [Tooltip("tempo ricarica della trappola")]
    public float rechargeTime;

    public bool cooldownIsActive;
    public int health = 3; //------------ change with player health

    private void Start()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !cooldownIsActive && cooldownTrap <=0f)
        {
            health--;  // -------------------- change with player health
            cooldownIsActive = true;
        }
    }
    void Update()
    {
        if (cooldownIsActive)
        {
            cooldownTrap += Time.deltaTime;

            if(cooldownTrap >= rechargeTime)
            {
                cooldownIsActive = false;
                cooldownTrap = cooldownTrap = 0f;
            }
        }
    }
}
