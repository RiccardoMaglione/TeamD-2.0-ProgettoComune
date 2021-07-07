using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryContinue : MonoBehaviour
{
    [SerializeField] GameObject ContinueButton;
    [SerializeField] Image iconIMG;
    [SerializeField] TextMeshProUGUI textIMG;
    FadeInOutTransition fadeInOutTransition;

    private void Awake()
    {
        fadeInOutTransition = FindObjectOfType<FadeInOutTransition>();
    }

    private void Update()
    {
        if (VictoryScreen.win == true && VictoryScreen.winChecked == false)
        {
            Invoke("EnableContinueButton", 4f);
        }

        if (Input.GetMouseButtonDown(0) && ContinueButton.activeSelf)
        {
            ContinueButtonPressed();
        }
    }

    private void EnableContinueButton()
    {
        ContinueButton.SetActive(true);
        ContinueFadeIn();
    }
    public void ContinueFadeIn()
    {
        textIMG.canvasRenderer.SetAlpha(0f);
        textIMG.CrossFadeAlpha(1, 0.5f, false);

        iconIMG.canvasRenderer.SetAlpha(0f);
        iconIMG.CrossFadeAlpha(1, 0.5f, false);
    }

    public void ContinueButtonPressed()
    {
        fadeInOutTransition.BlackPanelAppears();
        fadeInOutTransition.FadeIn();
        Invoke("ToMap", 1f);

    }
    public void ToMap()
    {
        SceneManager.LoadScene(1);
        CutsceneControllerDeathBoss.isCutsceneEnabled = false;
    }
}
