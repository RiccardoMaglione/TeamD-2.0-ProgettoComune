using UnityEngine;

public class TutorialSkipper : MonoBehaviour
{
    public GameObject tutorialTrigger;

    private void Start()
    {
        if (PlayerPrefs.GetInt("DisableTutorial") == 1)
        {
            tutorialTrigger.SetActive(false);
        }
        else
        {
            tutorialTrigger.SetActive(true);
        }
    }
    public void DisableTutorial()
    {
        if (PlayerPrefs.GetInt("DisableTutorial") == 0)
        {
            PlayerPrefs.SetInt("DisableTutorial", 1);

        }
        else
        {
            PlayerPrefs.SetInt("DisableTutorial", 0);
        }

    }
}
