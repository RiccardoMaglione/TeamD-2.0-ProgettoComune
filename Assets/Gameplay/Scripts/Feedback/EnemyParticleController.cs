using UnityEngine;

public class EnemyParticleController : MonoBehaviour
{
    public ParticleSystem deathParticle;
    public ParticleSystem stunParticle;
    public ParticleSystem bloodParticle;

    public static EnemyParticleController instance;

    public void PlayDeath()
    {
        deathParticle.Play();
    }

    public void PlayStun()
    {
        stunParticle.Play();
    }

    public void PlayBlood()
    {
        bloodParticle.Play();
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
