using UnityEngine;

public class Smash2 : MonoBehaviour
{
    public GameObject[] waypoints;
    [HideInInspector] public int i = 0;
    public float[] speed;
    float WPradius = 0.1f;
    public int checkGroundWP;
    bool hit = false;

    public GameObject[] cameraConfiners;
    public GameObject[] cameras;

    public GameObject lateralForces;

    public bool crumblingPlatforms = false;
    private void Start()
    {
        crumblingPlatforms = false;
    }

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
            hit = true;
            for (int i = 0; i < cameraConfiners.Length; i++)
            {
                cameraConfiners[i].SetActive(false);
                if (i == 25)
                {
                    cameraConfiners[25].SetActive(true);
                }
            }
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].SetActive(false);
                if (i == 25)
                {
                    cameras[25].SetActive(true);
                }
            }

            GroundManager.instance.Smash();

            AudioManager.instance.Play("Sfx_boss_smash");

            lateralForces.SetActive(true);
            crumblingPlatforms = true;
        }
    }
}
