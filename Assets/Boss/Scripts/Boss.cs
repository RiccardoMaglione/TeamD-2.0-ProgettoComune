using UnityEngine;

public class Boss : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Debug.LogWarning("BOSS HIT");   
    }
   
    public int life = 100;
}
