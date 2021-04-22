using UnityEngine;

public class LaserManager : MonoBehaviour
{
    public GameObject laser1;
    public GameObject laser2;
    public GameObject laser3;
 
    public ParticleSystem  particle1;
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
                particle1.Play();

            if (rand == 2)
                particle2.Play();

            if (rand == 3)
                particle3.Play();

            oldRandom = rand;
        }
    }
}
