using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject nextCamera;
    public GameObject nextConfiner;
    public GameObject currentCamera;
    public GameObject currentConfiner;

    public GameObject previousConfinerBarrier;

    public GameObject activateAggroBox1;

    public int killedEnemyToProgress;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //&& killedEnemyToProgress == FindObjectOfType<KilledEnemyCounter>().killedEnemyCounter)
        {
            nextCamera.SetActive(true);
            this.gameObject.SetActive(false);
            currentCamera.SetActive(false);
            nextConfiner.SetActive(true);
            previousConfinerBarrier.SetActive(false);
            Invoke("DeactivatePreviousConfiner", 0.5f);
            /*if (activateAggroBox1 != null)
            {
                activateAggroBox1.SetActive(true);
            }*/

        }
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && killedEnemyToProgress == FindObjectOfType<KilledEnemyCounter>().killedEnemyCounter)
        {
            nextCamera.SetActive(true);
            this.gameObject.SetActive(false);
            currentCamera.SetActive(false);
            nextConfiner.SetActive(true);
            Invoke("DeactivatePreviousConfiner", 0.5f);
            if (activateAggroBox1 != null)
            {
                activateAggroBox1.SetActive(true);
            }

        }
    }*/

    public void DeactivatePreviousConfiner()
    {
        currentConfiner.SetActive(false);
    }


}
