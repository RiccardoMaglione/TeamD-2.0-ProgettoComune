using UnityEngine;

public class EnemyParticleController : MonoBehaviour
{
    public ParticleSystem bloodParticle;
    public GameObject stunParticle;
    public ParticleSystem deathParticle;

    public void PlayBlood()
    {
        bloodParticle.Play();
    }

    public void PlayStun()
    {
        stunParticle.SetActive(true);
    }
    public void StopStun()
    {
        stunParticle.SetActive(false);
    }

    public void PlayDeath()
    {
        deathParticle.Play();
    }
}
