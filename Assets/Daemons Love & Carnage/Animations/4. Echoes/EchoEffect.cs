using SwordGame;
using UnityEngine;
public class EchoEffect : MonoBehaviour
{
    private float timeBetweenSpawn;
    public float StartTimeBetweenSpawn;

    public GameObject echo;
    private PSMController PSMController;

    private void Awake()
    {
        PSMController = this.gameObject.GetComponent<PSMController>();
    }
    private void Update()
    {
        if (PSMController.TimerDash <= PSMController.LimitTimerDash && PSMController.TimerDash != 0)
        {
            if (timeBetweenSpawn <= 0)
            {
                GameObject tempEcho = Instantiate(echo, transform.position, Quaternion.Euler(0, 0, 90));
                tempEcho.GetComponent<ParticleSystem>().Play();
                Destroy(tempEcho, 1f);
                timeBetweenSpawn = StartTimeBetweenSpawn;
            }
            else
            {
                timeBetweenSpawn -= Time.deltaTime;
            }

        }
    }
}
