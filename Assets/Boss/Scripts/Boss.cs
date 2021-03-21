using UnityEngine;

public class Boss : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Debug.LogWarning(damage+" BOSS DAMAGE");   
    }
   
    public int life = 100;
}
