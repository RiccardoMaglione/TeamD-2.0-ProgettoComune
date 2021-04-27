using UnityEngine;

public class ActivateTutorial1 : MonoBehaviour
{
    public GameObject tutorial1Trigger;

    private void Start()
    {
        Invoke("ActiveTutorial1", 0.5f);
    }

    public void ActiveTutorial1()
    {
        tutorial1Trigger.SetActive(true);
    }
}
