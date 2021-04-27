using UnityEngine;

public class Laser : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            Debug.LogWarning(damage+" LASER DAMAGE");
    }
}
