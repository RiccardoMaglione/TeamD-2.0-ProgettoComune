using UnityEngine;
using UnityEngine.SceneManagement;

public class KeboardMenuManager : MonoBehaviour
{
    [SerializeField] GameObject destinationScreen;
    [SerializeField] GameObject currentScreen;
    
    public void GoToPreviousScreen()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            destinationScreen.SetActive(true);
            currentScreen.SetActive(false);
        }
    }

    void Update()
    {
        GoToPreviousScreen();
    }
}
