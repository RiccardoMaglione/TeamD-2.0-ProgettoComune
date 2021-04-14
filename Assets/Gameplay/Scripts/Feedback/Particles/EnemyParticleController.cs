using UnityEngine;

public class EnemyParticleController : MonoBehaviour
{
    public ParticleSystem bloodParticle;
    public ParticleSystem stunParticle;
    public ParticleSystem deathParticle;
    public ParticleSystem possessionParticle;

    public static EnemyParticleController instance;

    public void PlayBlood()
    {
        bloodParticle.Play();
    }

    public void PlayStun()
    {
        stunParticle.Play();
    }

    public void PlayDeath()
    {
        deathParticle.Play();
    }

    public void PlayPossession()
    {
        possessionParticle.Play();
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
