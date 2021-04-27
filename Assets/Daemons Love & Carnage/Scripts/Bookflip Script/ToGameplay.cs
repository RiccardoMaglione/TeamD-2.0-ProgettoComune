using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGameplay : MonoBehaviour
{
    public void ToGameplayButton()
    {
        FindObjectOfType<FadeInOutTransition>().BlackPanelAppears();
        FindObjectOfType<FadeInOutTransition>().FadeIn();
        Invoke("ToGameplayScene", 0.5f);

    }
    public void ToGameplayScene()
    {
        SceneManager.LoadScene(2);

    }
}
