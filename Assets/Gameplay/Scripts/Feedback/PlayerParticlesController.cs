using UnityEngine;

public class PlayerParticlesController : MonoBehaviour
{
    public ParticleSystem runParticle;
    public ParticleSystem jumpParticle;
    public ParticleSystem landingParticle;
    public ParticleSystem dashParticle;

    public static PlayerParticlesController instance;

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

    void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
    }
}
