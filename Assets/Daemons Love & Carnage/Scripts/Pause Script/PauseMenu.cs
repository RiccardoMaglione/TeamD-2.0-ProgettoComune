using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using SwordGame;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject book;
    [SerializeField] GameObject pausePanel;

    [SerializeField] GameObject tornPage;
    [SerializeField] GameObject tornPageDestination;
    private Vector3 startPos;
    private Vector3 endPos;
    [SerializeField] float speed;

    [SerializeField] GameObject Resume;
    [SerializeField] GameObject RestartLevel;
    [SerializeField] GameObject Controls;
    [SerializeField] GameObject Options;
    [SerializeField] GameObject MainMenu;

    [SerializeField] GameObject shadowPanel;

    public bool paused = false;
    public bool menuOpen = false;

    public bool tornPageIsMoving;

    public bool tornPageOpen = false;

    public float dropSpeed;

    private void Start()
    {
        paused = false;
        menuOpen = false;
        startPos = tornPage.GetComponent<RectTransform>().anchoredPosition;
        endPos = tornPageDestination.GetComponent<RectTransform>().anchoredPosition;
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            paused = true;
        }
        if (Time.timeScale != 0)
        {
            paused = false;
        }


        if (Input.GetKeyDown(KeyCode.Escape) && paused == false && menuOpen == false)
        {
            if (AudioManager.instance != null)
                AudioManager.instance.Play("Sfx_book_drop");

            Cursor.visible = true;
            shadowPanel.SetActive(false);
            tornPage.GetComponent<RectTransform>().anchoredPosition = startPos;
            book.SetActive(true);
            StartCoroutine("BookDropCoroutine");
            pausePanel.SetActive(true);
            menuOpen = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused == true && menuOpen == true && tornPageOpen == false && tornPageIsMoving == false)
        {
            Cursor.visible = false;
            book.SetActive(false);
            pausePanel.SetActive(false);
            menuOpen = false;
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused == true && menuOpen == true && tornPageOpen == true)
        {
            StopCoroutine("MoveInTornPageCoroutine");
            StartCoroutine("MoveOutTornPageCoroutine");
        }

    }

    public void ResumeButton()
    {
        if (paused == true && menuOpen == true && tornPageOpen == false && tornPageIsMoving == false)
        {
            Cursor.visible = false;
            book.SetActive(false);
            pausePanel.SetActive(false);
            menuOpen = false;
            Time.timeScale = 1;
        }
    }

    public void RestartLevelButton()
    {
        if (tornPageOpen == false && tornPageIsMoving == false)
        {
            Resume.SetActive(false);
            RestartLevel.SetActive(true);
            Controls.SetActive(false);
            Options.SetActive(false);
            MainMenu.SetActive(false);

            StopCoroutine("MoveOutTornPageCoroutine");
            StartCoroutine("MoveInTornPageCoroutine");
        }
    }

    public void ControlsButton()
    {
        if (tornPageOpen == false && tornPageIsMoving == false)
        {
            Resume.SetActive(false);
            RestartLevel.SetActive(false);
            Controls.SetActive(true);
            Options.SetActive(false);
            MainMenu.SetActive(false);

            StopCoroutine("MoveOutTornPageCoroutine");
            StartCoroutine("MoveInTornPageCoroutine");
        }
    }

    public void OptionsButton()
    {
        if (tornPageOpen == false && tornPageIsMoving == false)
        {
            Resume.SetActive(false);
            RestartLevel.SetActive(false);
            Controls.SetActive(false);
            Options.SetActive(true);
            MainMenu.SetActive(false);

            StopCoroutine("MoveOutTornPageCoroutine");
            StartCoroutine("MoveInTornPageCoroutine");
        }
    }
    public void MainMenuButton()
    {
        if (tornPageOpen == false && tornPageIsMoving == false)
        {
            Resume.SetActive(false);
            RestartLevel.SetActive(false);
            Controls.SetActive(false);
            Options.SetActive(false);
            MainMenu.SetActive(true);

            StopCoroutine("MoveOutTornPageCoroutine");
            StartCoroutine("MoveInTornPageCoroutine");
        }
    }

    public void NoButton()
    {
        if (paused == true && menuOpen == true && tornPageOpen == true)
        {
            StopCoroutine("MoveInTornPageCoroutine");
            StartCoroutine("MoveOutTornPageCoroutine");
        }

    }

    public void ConfirmRestart()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        FindObjectOfType<FadeInOutTransition>().BlackPanelAppears();
        FindObjectOfType<FadeInOutTransition>().FadeIn();
        Invoke("Reload", 0.5f);
    }

    public void ConfirmBackToMenu()
    {
        Time.timeScale = 1;
        FindObjectOfType<FadeInOutTransition>().BlackPanelAppears();
        FindObjectOfType<FadeInOutTransition>().FadeIn();
        Invoke("ToMainMenu", 0.5f);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void Reload()
    {
        PlayerPrefs.GetInt("IDCheckpoint", -1);
        CheckpointManager.ContinueGame = false;
        SceneManager.LoadScene(2);
    }
    public IEnumerator MoveInTornPageCoroutine()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.Play("Sfx_book_torn_page");

        shadowPanel.SetActive(true);

        while (tornPage.GetComponent<RectTransform>().anchoredPosition.x != endPos.x)
        {
            tornPageIsMoving = true;
            tornPage.GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(tornPage.GetComponent<RectTransform>().anchoredPosition, endPos, speed * Time.unscaledDeltaTime);
            if (tornPage.GetComponent<RectTransform>().anchoredPosition.x == endPos.x)
            {
                tornPageOpen = true;
                tornPageIsMoving = false;
            }
            yield return null;
        }

    }

    public IEnumerator MoveOutTornPageCoroutine()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.Play("Sfx_book_torn_page");

        shadowPanel.SetActive(false);

        while (tornPage.GetComponent<RectTransform>().anchoredPosition.x != startPos.x)
        {
            tornPageIsMoving = true;
            tornPage.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(tornPage.GetComponent<RectTransform>().anchoredPosition, startPos, speed * Time.unscaledDeltaTime);
            if (tornPage.GetComponent<RectTransform>().anchoredPosition.x == startPos.x)
            {
                tornPageOpen = false;
                tornPageIsMoving = false;
            }
            yield return null;
        }

    }

    public IEnumerator BookDropCoroutine()
    {
        float elapsedTime = 0;
        Vector3 startScale = new Vector3(2.24f, 2.24f, 1f);
        Vector3 targetScale = new Vector3(1.12f, 1.12f, 1f);

        book.transform.localScale = startScale;

        float timeTakes = dropSpeed;


        while (elapsedTime < timeTakes)
        {
            book.transform.localScale = Vector3.Lerp(book.transform.localScale, targetScale, (elapsedTime / timeTakes));

            elapsedTime += Time.unscaledDeltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
