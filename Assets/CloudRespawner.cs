using UnityEngine;

public class CloudRespawner : MonoBehaviour
{
    [SerializeField] Vector3 spawningPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cloud")
        {
            collision.transform.position = new Vector3(spawningPoint.x, collision.transform.position.y, collision.transform.position.z);
        }
    }
}
