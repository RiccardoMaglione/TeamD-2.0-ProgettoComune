using UnityEngine;

public class LaserManager : MonoBehaviour
{
    public GameObject laser1;
    public GameObject laser2;
    public GameObject laser3;

    public GameObject openedCrack1;
    public GameObject openedCrack2;
    public GameObject openedCrack3;

    public ParticleSystem particle1;
    public ParticleSystem particle2;
    public ParticleSystem particle3;

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
            {
                particle1.Play();
                openedCrack1.SetActive(true);
            }

            if (rand == 2)
            {
                particle2.Play();
                openedCrack2.SetActive(true);

            }


            if (rand == 3)
            {
                particle3.Play();
                openedCrack3.SetActive(true);

            }


            oldRandom = rand;
        }
    }
}
