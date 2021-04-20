using UnityEngine;

public class BabushkaParticleController : BasePlayerParticles
{
    public ParticleSystem rageAuraParticle;

    public void PlayRageAura()
    {
        rageAuraParticle.Play();
    }

    public void StopRageAura()
    {
        rageAuraParticle.Play();
    }
}
