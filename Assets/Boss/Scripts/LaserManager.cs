using UnityEngine;

public class LaserManager : MonoBehaviour
{
    public GameObject laser1;
    public GameObject laser2;
    public GameObject laser3;
 
    public GameObject particle1;
    public GameObject particle2;
    public GameObject particle3;

    [HideInInspector] public int rand;
    int oldRandom;

    public Animator animator;

    public void DoRandom()
    {
        if (animator.GetBool("Laser") == true)
        {
            do
            {
                rand = Random.Range(1, 4);
            }
            while (oldRandom == rand);

            if (rand == 1)
                particle1.SetActive(true);

            if (rand == 2)
                particle2.SetActive(true);

            if (rand == 3)
                particle3.SetActive(true);

            oldRandom = rand;
        }
    }
}
