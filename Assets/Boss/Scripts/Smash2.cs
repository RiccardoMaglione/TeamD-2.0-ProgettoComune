using UnityEngine;

public class Smash2 : MonoBehaviour
{
    public GameObject[] waypoints;
    [HideInInspector] public int i = 0;
    public float[] speed;
    float WPradius = 0.1f;
    public int checkGroundWP;
    bool hit = false;

    public void Smash()
    {
        if (i < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[i].transform.position, Time.deltaTime * speed[i]);

            if ((Vector3.Distance(waypoints[i].transform.position, transform.position) < WPradius) && i < waypoints.Length)
            {
                i++;
            }
        }

        if (waypoints[checkGroundWP].transform.position.y >= transform.position.y && hit == false)
        {
            hit = true;
            GroundManager.instance.Smash();
        }
    }
}
