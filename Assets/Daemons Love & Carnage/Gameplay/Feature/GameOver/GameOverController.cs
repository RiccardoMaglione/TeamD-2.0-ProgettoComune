using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public List<Sprite> ListEye = new List<Sprite>();
    public Image ImageEye;

    public List<GameObject> ListScreen = new List<GameObject>();
    public int RndScreen;
    public GameObject ButtonScreen;
    public float TimerInvokeButton;
    public float TimerEye;

    void Start()
    {
        StartCoroutine(AnimationEye());
        RandomScreenGameOver();
        Invoke("ButtonScreenGameOver", TimerInvokeButton);
    }

    public IEnumerator AnimationEye()
    {
        while (true)
        {
            for (int i = 0; i < ListEye.Count; i++)
            {
                ImageEye.sprite = ListEye[i];
                yield return new WaitForSeconds(TimerEye);
            }
        }
    }

    public void RandomScreenGameOver()
    {
        RndScreen = Random.Range(0, ListScreen.Count);
        ListScreen[RndScreen].SetActive(true);
    }

    public void ButtonScreenGameOver()
    {
        ListScreen[RndScreen].SetActive(false);
        ButtonScreen.SetActive(true);
    }

    public void ReturnMenu(string NameScene)
    {
        SceneManager.LoadScene(NameScene);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
