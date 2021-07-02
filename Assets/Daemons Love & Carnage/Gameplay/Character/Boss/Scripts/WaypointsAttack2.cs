using UnityEngine;

public class WaypointsAttack2 : MonoBehaviour
{
    public GameObject[] waypoints;
    [HideInInspector] public int i = 0;
    public float[] speed;
    float WPradius = 0.1f;

    [SerializeField] CameraShake cameraShake;

    public void Attack2()
    {
        if (i < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[i].transform.position, Time.deltaTime * speed[i]);

            if ((Vector3.Distance(waypoints[i].transform.position, transform.position) < WPradius) && i < waypoints.Length)
            {
                i++;

                if(i != waypoints.Length && i != 3 && i != 6 && i != 1)
                    AudioManager.instance.Play("Sfx_boss_stomp");

                if (i < waypoints.Length)
                    cameraShake.ShakeElapsedTime = cameraShake.ShakeDuration;

                if (i == waypoints.Length - 1)
                {
                    Boss.canDamage = false;
                }

                if (i == 3)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }

                if(i== 6)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
            }
        }
    }
}
