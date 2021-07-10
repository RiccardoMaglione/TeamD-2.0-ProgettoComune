using SwordGame;
using UnityEngine;
public class DashStopper : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.CompareTag("Player") && DialogueTrigger.bossDialogueTrigger == true)
        {
            Debug.Log("Sos");

            collision.GetComponent<PSMController>().TimerDash += 5;
            collision.GetComponent<PSMController>().CooldownDashDirectional = true;                                              //Setto a vero la condizione per entrare nella fase di cooldown del dash
                                                                                                                                 //Debug.Log("PlayerState - Entra nel cooldown - Dash sinistro");                                                      //Debuggo in console cosa fa e il punto in cui è arrivato
            collision.GetComponent<Animator>().SetBool("PSM-CanDash", false);
            if (collision.GetComponent<Animator>().GetBool("PSM-IsGrounded") == false)                                                                    //Se non tocca il pavimento
            {
                collision.GetComponent<Animator>().SetBool("PSM-CanDashInAir", true);                                                                     //Blocco la possibilità di rientrare nel dash dallo stato di caduta
                                                                                                                                                          //Debug.Log("PlayerState - Air dash - Dash destro");                                                              //Debuggo in console cosa fa e il punto in cui è arrivato
            }

            collision.GetComponentInChildren<BasePlayerParticles>().StopDash();
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            collision.GetComponent<PSMController>().CanDashRight = false;                   //Resetta la direzione del dash
            collision.GetComponent<PSMController>().CanDashLeft = false;                    //Resetta la direzione del dash
            collision.GetComponent<PSMController>().TimerDash = 0;                          //Resetta il timer della durata del dash
            collision.GetComponent<PSMController>().TimerDashCooldown = 0;                  //Resetta il timer del cooldown
            collision.GetComponent<PSMController>().CooldownDashDirectional = false;        //Mi permette di ritornare in dash

            if (collision.GetComponent<PSMController>().DashKnockbackFatKnight != null)
                collision.GetComponent<PSMController>().DashKnockbackFatKnight.SetActive(false);

            collision.GetComponent<PSMController>().Invulnerability = false;
            PSMController.isBoriousDash = false;

            if (collision.GetComponent<PSMController>().DashColliderBabushka != null)
                collision.GetComponent<PSMController>().DashColliderBabushka.SetActive(false);

            if (collision.GetComponent<PSMController>().DashColliderBorious != null)
                collision.GetComponent<PSMController>().DashColliderBorious.SetActive(false);
        }
        else if (collision.CompareTag("Player") && PlayerPrefs.GetInt("TutorialSkip") < GetComponentInParent<DialogueType1>().NumSkip) //|| collision.CompareTag("Player") && DialogueTrigger.bossDialogueTrigger == true)
        {
            Debug.Log("Sos");

            collision.GetComponent<PSMController>().TimerDash += 5;
            collision.GetComponent<PSMController>().CooldownDashDirectional = true;                                              //Setto a vero la condizione per entrare nella fase di cooldown del dash
                                                                                                                                 //Debug.Log("PlayerState - Entra nel cooldown - Dash sinistro");                                                      //Debuggo in console cosa fa e il punto in cui è arrivato
            collision.GetComponent<Animator>().SetBool("PSM-CanDash", false);
            if (collision.GetComponent<Animator>().GetBool("PSM-IsGrounded") == false)                                                                    //Se non tocca il pavimento
            {
                collision.GetComponent<Animator>().SetBool("PSM-CanDashInAir", true);                                                                     //Blocco la possibilità di rientrare nel dash dallo stato di caduta
                                                                                                                                                          //Debug.Log("PlayerState - Air dash - Dash destro");                                                              //Debuggo in console cosa fa e il punto in cui è arrivato
            }

            collision.GetComponentInChildren<BasePlayerParticles>().StopDash();
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            collision.GetComponent<PSMController>().CanDashRight = false;                   //Resetta la direzione del dash
            collision.GetComponent<PSMController>().CanDashLeft = false;                    //Resetta la direzione del dash
            collision.GetComponent<PSMController>().TimerDash = 0;                          //Resetta il timer della durata del dash
            collision.GetComponent<PSMController>().TimerDashCooldown = 0;                  //Resetta il timer del cooldown
            collision.GetComponent<PSMController>().CooldownDashDirectional = false;        //Mi permette di ritornare in dash
        }



    }
}
