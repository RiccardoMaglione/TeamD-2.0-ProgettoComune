using UnityEngine;

public class Smash1 : MonoBehaviour
{
    public GameObject[] waypoints;
    [HideInInspector] public int i = 0;
    public float[] speed;
    float WPradius = 0.1f;
    public int checkGroundWP;
    bool hit = false;

    public GameObject[] cameraConfiners;
    public GameObject[] cameras;

    public void Smash()
    {
        if (i < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[i].transform.position, Time.unscaledDeltaTime * speed[i]);

            if ((Vector3.Distance(waypoints[i].transform.position, transform.position) < WPradius) && i < waypoints.Length)
            {
                i++;
            }
        }

        if (waypoints[checkGroundWP].transform.position.y >= transform.position.y && hit == false)
        {
            hit = true;
            for (int i = 0; i < cameraConfiners.Length; i++)
            {
                cameraConfiners[i].SetActive(false);
                if (i == 24)
                {
                    cameraConfiners[24].SetActive(true);
                }
            }
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].SetActive(false);
                if (i == 24)
                {
                    cameras[24].SetActive(true);
                }
            }

            GroundManager.instance.Smash();
            EnviromentManager.instance.ActiveSimulated(true);
        }
    }
}
