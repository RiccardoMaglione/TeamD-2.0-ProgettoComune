using UnityEngine;

public class BasePlayerParticles : MonoBehaviour
{
    public ParticleSystem runParticle;
    public ParticleSystem jumpParticle;
    public ParticleSystem landingParticle;
    public ParticleSystem dashParticle;
    public ParticleSystem possessionParticle;

    #region Run Particles
    public void PlayRun()
    {
        runParticle.Play();
    }

    public void StopRun()
    {
        runParticle.Stop();
    }
    #endregion

    public void PlayJump()
    {
        jumpParticle.Play();
    }

    public void PlayLanding()
    {
        landingParticle.Play();
    }

    public void PlayDash()
    {
        dashParticle.Play();
    }

    public void PlayPossession()
    {
        possessionParticle.Play();
    }
}
