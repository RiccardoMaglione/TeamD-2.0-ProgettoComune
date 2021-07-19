using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void GameTitleStart()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void Update()
    {
        GameTitleStart();
    }
}
