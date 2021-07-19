using UnityEngine;

public class TutorialSkipper : MonoBehaviour
{
    public GameObject tutorialTrigger;

    private void Start()
    {
        if (PlayerPrefs.GetInt("DisableTutorial") == 1)
        {
            DialogueType1.StaticTutorial = 7;
            DialogueType1.StaticTutorial2 = 7;
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
            DialogueType1.StaticTutorial = 7;
            DialogueType1.StaticTutorial2 = 7;
            PlayerPrefs.SetInt("DisableTutorial", 1);
        }
        else
        {
            PlayerPrefs.SetInt("DisableTutorial", 0);
        }

    }
}
