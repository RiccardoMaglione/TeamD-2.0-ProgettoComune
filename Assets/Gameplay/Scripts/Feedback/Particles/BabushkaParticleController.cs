using UnityEngine;

public class BabushkaParticleController : BasePlayerParticles
{
    BabushkaParticleController instance;

    public ParticleSystem rageAuraParticle;

    public void PlayRageAura()
    {
        rageAuraParticle.Play();
    }

    public void StopRageAura()
    {
        rageAuraParticle.Play();
    }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
