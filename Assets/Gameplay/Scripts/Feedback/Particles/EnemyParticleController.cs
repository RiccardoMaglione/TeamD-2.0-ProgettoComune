using UnityEngine;

public class EnemyParticleController : MonoBehaviour
{
    public ParticleSystem bloodParticle;
    public ParticleSystem stunParticle;
    public ParticleSystem deathParticle;
    public ParticleSystem possessionParticle;

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
}
