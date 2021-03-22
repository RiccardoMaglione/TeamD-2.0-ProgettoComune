using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
            Destroy(gameObject);

        if (collision.gameObject.tag == "Player")
            Debug.LogWarning(damage+" WAVE DAMAGE");
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
