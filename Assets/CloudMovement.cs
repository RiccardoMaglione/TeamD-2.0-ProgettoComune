using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 startPos;
    private void Start()
    {
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.x >= startPos.x + 80)
        {
            transform.position = startPos;
        }


    }
}
