using SwordGame;
using UnityEngine;
public class BasePlayerParticles : MonoBehaviour
{
    public ParticleSystem runParticle;
    public ParticleSystem jumpParticle;
    public ParticleSystem landingParticle;
    public ParticleSystem dashParticle;
    public ParticleSystem possessionParticle;
    public ParticleSystem hit;
    public float landingParticleOffsetSX;

    public Rigidbody2D player;

    private float timeBetweenSpawn;
    public float StartTimeBetweenSpawn;


    #region Run Particles

    private void Update()
    {
        if (player.gameObject.GetComponent<PSMController>().TimerDash >= player.gameObject.GetComponent<PSMController>().LimitTimerDash - 0.2f && player.gameObject.GetComponent<PSMController>().TimerDash != 0)
            StopDash();


        if (player.velocity.x != 0 && player.gameObject.GetComponent<Animator>().GetBool("PSM-IsGrounded") == true)
        {
            if (timeBetweenSpawn <= 0)
            {
                //PlayRun();
                GameObject tempRunEffect = Instantiate(runParticle.gameObject, new Vector2(transform.position.x, transform.position.y - 1), Quaternion.identity);
                tempRunEffect.GetComponent<ParticleSystem>().Play();
                Destroy(tempRunEffect, 0.5f);
                timeBetweenSpawn = StartTimeBetweenSpawn;

            }
            else
            {
                timeBetweenSpawn -= Time.deltaTime;
            }
        }
    }
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
        GameObject tempJumpEffect = Instantiate(jumpParticle.gameObject, new Vector2(transform.position.x, transform.position.y - 1), Quaternion.identity);
        tempJumpEffect.GetComponent<ParticleSystem>().Play();
        Destroy(tempJumpEffect, 1);

    }

    public void PlayLanding()
    {
        if (player.gameObject.GetComponent<Animator>().GetBool("PSM-IsGrounded") == true)
        {
            //landingParticle.Play();
            GameObject tempLandingEffect = Instantiate(landingParticle.gameObject, new Vector2(transform.position.x - landingParticleOffsetSX, transform.position.y - 1), Quaternion.identity);
            tempLandingEffect.GetComponent<ParticleSystem>().Play();
            Destroy(tempLandingEffect, 1);

        }
    }

    public void PlayDash()
    {
        dashParticle.Play();
    }
    public void StopDash()
    {
        dashParticle.Stop();
    }

    public void PlayPossession()
    {
        possessionParticle.Play();
    }

    public void PlayHit(GameObject targetTransform)
    {
        GameObject tempHitEffect = Instantiate(hit.gameObject, targetTransform.transform.position, Quaternion.identity);
        tempHitEffect.GetComponent<ParticleSystem>().Play();

        Destroy(tempHitEffect, 0.5f);

    }

}
