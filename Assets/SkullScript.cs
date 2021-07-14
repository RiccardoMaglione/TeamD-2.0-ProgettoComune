using UnityEngine;

public class SkullScript : MonoBehaviour
{
    [SerializeField] GameObject interactionButtonIcon;
    [SerializeField] ParticleSystem ps;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //interactionButtonIcon.SetActive(true);
            this.gameObject.SetActive(false);
            Instantiate(ps, this.gameObject.transform.position, this.gameObject.transform.rotation);

            //inserire nelle playerpref modifica alla pagina di conferma livello + impostare il teschio come ottenuto e attivabile nel menu teschi
            PlayerPrefs.SetInt("ObtainSkull", 1);

        }
    }
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                Instantiate(ps, this.gameObject.transform.position, this.gameObject.transform.rotation);

                //inserire nelle playerpref modifica alla pagina di conferma livello + impostare il teschio come ottenuto e attivabile nel menu teschi
                PlayerPrefs.SetInt("ObtainSkull", 1);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionButtonIcon.SetActive(false);
        }
    }*/
}
