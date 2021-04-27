using UnityEngine;

public class Waypoints3Phase : MonoBehaviour
{
    public GameObject[] waypoints;
    [HideInInspector] public int i = 0;
    public float[] speed;
    float WPradius = 0.1f;
    public int ground = 0;

    [SerializeField] GameObject prefab1;
    [SerializeField] GameObject prefab2;

    public void Attack3()
    {
        if (i < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[i].transform.position, Time.deltaTime * speed[i]);

            if ((Vector3.Distance(waypoints[i].transform.position, transform.position) <= WPradius) && i < waypoints.Length)
            {
                i++;
            }

            if (i >= waypoints.Length)
            {
                i = 0;
                Instantiate(prefab1, new Vector2(transform.position.x - 2.7f, transform.position.y - 1.8f), transform.rotation);
                Instantiate(prefab2, new Vector2(transform.position.x + 2.7f, transform.position.y - 1.8f), transform.rotation);
                ground++;
            }
        }
    }
}
