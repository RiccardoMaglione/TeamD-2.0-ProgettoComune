using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadBookFlip : MonoBehaviour
{
    public AsyncOperation asyncOperation;
    public static LoadBookFlip thisinstance;

    void Start()
    {
        thisinstance = this;
        //Call the LoadButton() function when the user clicks this Button
        //m_Button.onClick.AddListener(LoadButton);
        StartCoroutine(LoadScene());
    }

    void LoadButton()
    {
        //Start loading the Scene asynchronously and output the progress bar
    }

    IEnumerator LoadScene()
    {
        yield return null;

        //Begin to load the Scene you specify
        asyncOperation = SceneManager.LoadSceneAsync("BookFlip");
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        Debug.Log("Pro 2:" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            //m_Text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                //Change the Text to show the Scene is ready
                //m_Text.text = "Press the space bar to continue";
                Debug.Log("Puoi andare avanti al menù");
                //Wait to you press the space key to activate the Scene
                //if (Input.GetKeyDown(KeyCode.Space))
                //Activate the Scene
                //asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}