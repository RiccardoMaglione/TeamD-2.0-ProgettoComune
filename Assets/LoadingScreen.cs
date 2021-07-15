using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    public IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LevelScene");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
