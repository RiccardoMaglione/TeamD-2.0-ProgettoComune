using UnityEngine;
using UnityEngine.UI;

public class TestHealth : MonoBehaviour
{
    public HealthBar hb;
    public int maxHealth;
    public int currentHealth;

    void DecreaseHealth(int damage)
    {
        currentHealth -= damage; // calcola il danno 
        hb.SetHealth(currentHealth); // imposta il danno

        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }

        if(currentHealth <= 5)
        {
          
        }

    }
    void Start()
    {
        currentHealth = maxHealth;
        hb.SetHealth(currentHealth); //prendo il metodo dell'altro script e imposto sulla salute corrente
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //test
            DecreaseHealth(2);
        }
    }
}
