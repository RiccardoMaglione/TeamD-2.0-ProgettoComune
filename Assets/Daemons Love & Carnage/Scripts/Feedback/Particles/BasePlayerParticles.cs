using UnityEngine;

public class BasePlayerParticles : MonoBehaviour
{
    public ParticleSystem runParticle;
    public ParticleSystem jumpParticle;
    public ParticleSystem landingParticle;
    public ParticleSystem dashParticle;
    public ParticleSystem possessionParticle;

    public GameObject player;

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
        //jumpParticle.Play();
        GameObject tempJumpEffect = Instantiate(landingParticle.gameObject, new Vector2(transform.position.x, transform.position.y - 1), Quaternion.identity);
        tempJumpEffect.GetComponent<ParticleSystem>().Play();
        Destroy(tempJumpEffect, 1);

    }

    public void PlayLanding()
    {
        //landingParticle.Play();
        GameObject tempLandingEffect = Instantiate(landingParticle.gameObject, new Vector2(transform.position.x, transform.position.y - 1), Quaternion.identity);
        tempLandingEffect.GetComponent<ParticleSystem>().Play();
        Destroy(tempLandingEffect, 1);

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
