﻿using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject nextCamera;
    public GameObject nextConfiner;
    public GameObject currentCamera;
    public GameObject currentConfiner;

    public GameObject previousConfinerBarrier;

    public GameObject activateAggroBox1;

    public int killedEnemyToProgress = 0;

    public GameObject Enemies1;

    public GameObject deactivatingGraphics;
    public GameObject deactivatingGraphics2;

    public GameObject activatingGraphics;

    public GameObject deactivatingEnemiesZone;

    private void Update()
    {
        if (2 == KilledEnemyCounter.KilledEnemyCounterInstance.killedEnemyCounter)
        {
            if (Enemies1 != null)
            {
                Enemies1.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && killedEnemyToProgress <= KilledEnemyCounter.KilledEnemyCounterInstance.killedEnemyCounter)
        {
            UIManager.instance.arrow.SetActive(false);
            UIManager.instance.go.SetActive(false);
            if (deactivatingEnemiesZone != null)
            {
                deactivatingEnemiesZone.GetComponent<WaveController>().enabled = false;
            }
            nextCamera.SetActive(true);
            this.gameObject.SetActive(false);
            currentCamera.SetActive(false);
            nextConfiner.SetActive(true);

            if (deactivatingGraphics != null)
            {
                Invoke("DeactivatePreviousGraphics", 0.3f);
            }
            if (deactivatingGraphics2 != null)
            {
                Invoke("DeactivatePreviousGraphics2", 0.3f);
            }

            if (activatingGraphics != null)
            {
                activatingGraphics.SetActive(true);
            }

            if (previousConfinerBarrier != null)
            {
                previousConfinerBarrier.SetActive(false);
            }
            Invoke("DeactivatePreviousConfiner", 0.5f);
            if (activateAggroBox1 != null)
            {
                activateAggroBox1.SetActive(true);
            }

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && killedEnemyToProgress <= KilledEnemyCounter.KilledEnemyCounterInstance.killedEnemyCounter)
        {
            UIManager.instance.arrow.SetActive(false);
            UIManager.instance.go.SetActive(false);
            if (deactivatingEnemiesZone != null)
            {
                deactivatingEnemiesZone.GetComponent<WaveController>().enabled = false;
            }
            nextCamera.SetActive(true);
            this.gameObject.SetActive(false);
            currentCamera.SetActive(false);
            nextConfiner.SetActive(true);

            if (deactivatingGraphics != null)
            {
                Invoke("DeactivatePreviousGraphics", 0.3f);
            }
            if (deactivatingGraphics2 != null)
            {
                Invoke("DeactivatePreviousGraphics2", 0.3f);
            }

            if (activatingGraphics != null)
            {
                activatingGraphics.SetActive(true);
            }

            if (previousConfinerBarrier != null)
            {
                previousConfinerBarrier.SetActive(false);
            }
            Invoke("DeactivatePreviousConfiner", 0.5f);
            if (activateAggroBox1 != null)
            {
                activateAggroBox1.SetActive(true);
            }

        }
    }

    public void DeactivatePreviousGraphics()
    {
        deactivatingGraphics.SetActive(false);
    }
    public void DeactivatePreviousGraphics2()
    {
        deactivatingGraphics2.SetActive(false);
    }

    public void DeactivatePreviousConfiner()
    {
        currentConfiner.SetActive(false);
    }


}
