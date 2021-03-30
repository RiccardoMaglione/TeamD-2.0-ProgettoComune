using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject nextCamera;
    public GameObject nextConfiner;
    public GameObject currentCamera;
    public GameObject currentConfiner;

    public GameObject activateAggroBox1;

    public int killedEnemyToProgress;

    public GameObject Enemies1;

    private void Update()
    {
        if(2 == FindObjectOfType<KilledEnemyCounter>().killedEnemyCounter)
        {
            if(Enemies1 != null)
            {
                Enemies1.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && killedEnemyToProgress == FindObjectOfType<KilledEnemyCounter>().killedEnemyCounter)
        {
            nextCamera.SetActive(true);
            this.gameObject.SetActive(false);
            currentCamera.SetActive(false);
            nextConfiner.SetActive(true);
            currentConfiner.SetActive(false);
            if (activateAggroBox1 != null)
            {
                activateAggroBox1.SetActive(true);
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && killedEnemyToProgress == FindObjectOfType<KilledEnemyCounter>().killedEnemyCounter)
        {
            nextCamera.SetActive(true);
            this.gameObject.SetActive(false);
            currentCamera.SetActive(false);
            nextConfiner.SetActive(true);
            currentConfiner.SetActive(false);
            if (activateAggroBox1 != null)
            {
                activateAggroBox1.SetActive(true);
            }

        }
    }


}
