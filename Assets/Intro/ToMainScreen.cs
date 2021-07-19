using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainScreen : MonoBehaviour
{
    private float timer;
    public float timeToMainScreen;

    private void Start()
    {
        timer = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToMainScreen)
        {
            SceneManager.LoadScene("MainScreen");
        }
    }
}
