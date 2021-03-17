using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    public Animator animator;
    public GameObject wave1;
    public GameObject wave2;

    public void StartWave1()
    {
        wave1.SetActive(true);
    }

    public void StartWave2()
    {
        wave2.SetActive(true);
    }

    void Update()
    {
        if (wave1.activeSelf == true || wave2.activeSelf == true)
        {
            if (GameObject.FindGameObjectsWithTag("Wave").Length == 0)
            {
                wave1.SetActive(false);
                wave2.SetActive(false);
                animator.SetTrigger("GoToSmash");
            }
        }
    }
}
