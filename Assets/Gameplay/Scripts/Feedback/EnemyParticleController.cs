using UnityEngine;

public class EnemyParticleController : MonoBehaviour
{
    public ParticleSystem deathParticle;
    public ParticleSystem stunParticle;
    public ParticleSystem bloodParticle;
    public ParticleSystem rageAuraParticle;

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

    #region Rage Aura Particle
    public void PlayRageAura()
    {
        rageAuraParticle.Play();
    }

    public void StopRageAura()
    {
        rageAuraParticle.Play();
    }
    #endregion

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
