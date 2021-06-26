using UnityEngine;

public class Smash3 : MonoBehaviour
{
    public GameObject[] waypoints;
    [HideInInspector] public int i = 0;
    public float[] speed;
    float WPradius = 0.1f;

    public GameObject crack1;
    public GameObject crack2;
    public GameObject crack3;


    public CameraShake cameraShake;

    public void Smash()
    {
        if (i < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[i].transform.position, Time.deltaTime * speed[i]);

            if ((Vector3.Distance(waypoints[i].transform.position, transform.position) < WPradius) && i < waypoints.Length)
            {
                i++;
            }

            if (i == waypoints.Length)
            {
                cameraShake.ShakeElapsedTime = cameraShake.ShakeDuration;
                crack1.SetActive(true);
                crack2.SetActive(true);
                crack3.SetActive(true);


                AudioManager.instance.Play("Sfx_boss_smash");
            }
        }
    }
}
