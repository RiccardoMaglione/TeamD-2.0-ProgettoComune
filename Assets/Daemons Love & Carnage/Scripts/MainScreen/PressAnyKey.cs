using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PressAnyKey : MonoBehaviour
{
    public float flickerSpeed = 1f;
    public Image pressAnyKey;
    public Image sfumatura;
    void Start()
    {
        StartCoroutine("Flickering");
    }
    IEnumerator Flickering()
    {
        while (true)
        {
            yield return new WaitForSeconds(flickerSpeed + 1);
            pressAnyKey.CrossFadeAlpha(0, 0.4f, false);
            sfumatura.CrossFadeAlpha(0, 0.4f, false);

            yield return new WaitForSeconds(flickerSpeed);
            //pressAnyKey.enabled = true;
            //sfumatura.enabled = true;
            pressAnyKey.canvasRenderer.SetAlpha(0f);
            pressAnyKey.CrossFadeAlpha(1, 0.4f, false);
            sfumatura.canvasRenderer.SetAlpha(0f);
            sfumatura.CrossFadeAlpha(1, 0.4f, false);

            //pressAnyKey.enabled = false;
            //sfumatura.enabled = false;

        }
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            AudioManager.instance.Play("Sfx_spess_any_key");
            //PlayerPrefs.DeleteKey("IDCheckpoint");
            //PlayerPrefs.SetInt("IDCheckpoint", -1);
            FindObjectOfType<FadeInOutTransition>().BlackPanelAppears();
            FindObjectOfType<FadeInOutTransition>().FadeIn();
            Invoke("ToMainMenu", 0.5f);
        }
    }

    void ToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
