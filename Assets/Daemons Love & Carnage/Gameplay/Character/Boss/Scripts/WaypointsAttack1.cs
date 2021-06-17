using UnityEngine;

public class WaypointsAttack1 : MonoBehaviour
{
    public GameObject[] waypoints;
    [HideInInspector] public int i = 0;
    public float[] speed;
    float WPradius = 0.1f;

    [SerializeField] CameraShake cameraShake;
    
    public void Attack1()
    {
        if (i < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[i].transform.position, Time.deltaTime * speed[i]);

            if ((Vector3.Distance(waypoints[i].transform.position, transform.position) < WPradius) && i < waypoints.Length)
            {
                i++;
                AudioManager.instance.Play("Sfx_boss_stomp");

                if (i < waypoints.Length)
                    cameraShake.ShakeElapsedTime = cameraShake.ShakeDuration;

                if (i == waypoints.Length - 1)
                    Boss.canDamage = false;
            }
        }
    }
}
