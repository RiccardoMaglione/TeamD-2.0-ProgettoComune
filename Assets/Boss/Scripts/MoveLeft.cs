using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
            Destroy(gameObject);

        if (collision.gameObject.tag == "Player")
            Debug.LogWarning("HIT");
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
