using System.Collections;
using UnityEngine;

public class TornPage : MonoBehaviour
{
    [SerializeField] GameObject tornPage;
    [SerializeField] GameObject tornPageDestination;
    private Vector3 startPos;
    private Vector3 endPos;
    [SerializeField] float speed;

    [SerializeField] GameObject Options;
    [SerializeField] GameObject RateUs;
    [SerializeField] GameObject Credits;
    [SerializeField] GameObject Quit;
    [SerializeField] GameObject SkullPage;
    [SerializeField] GameObject newGame;
    [SerializeField] GameObject Controls;
    private PageFlipper pageFlipper;


    [SerializeField] GameObject shadowPanel;

    public static bool tornPageIsMoving;

    private float transitionTime = 10;

    public bool tornPageOpen = false;

    public bool thereAreSavedData; //bool da integrare con sistema di salvataggio


    private void Start()
    {
        startPos = tornPage.transform.position;
        endPos = tornPageDestination.transform.position;
        pageFlipper = FindObjectOfType<PageFlipper>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MoveOutTornPage();
        }
    }

    public void MoveOutTornPage()
    {
        StopAllCoroutines();
        StartCoroutine(MoveOutTornPageCoroutine());
    }

    public void OptionsButton()
    {
        if (tornPageOpen == false && tornPageIsMoving == false)
        {
            Options.SetActive(true);
            RateUs.SetActive(false);
            Credits.SetActive(false);
            Quit.SetActive(false);
            SkullPage.SetActive(false);
            newGame.SetActive(false);
            Controls.SetActive(false);


            StopAllCoroutines();
            StartCoroutine(MoveInTornPage());
        }
    }

    public void RateUsButton()
    {
        if (tornPageOpen == false && tornPageIsMoving == false)
        {
            Options.SetActive(false);
            RateUs.SetActive(true);
            Credits.SetActive(false);
            Quit.SetActive(false);
            SkullPage.SetActive(false);
            newGame.SetActive(false);
            Controls.SetActive(false);


            StopAllCoroutines();
            StartCoroutine(MoveInTornPage());
        }
    }

    public void CreditsButton()
    {
        if (tornPageOpen == false && tornPageIsMoving == false)
        {

            Options.SetActive(false);
            RateUs.SetActive(false);
            Credits.SetActive(true);
            Quit.SetActive(false);
            SkullPage.SetActive(false);
            newGame.SetActive(false);
            Controls.SetActive(false);


            StopAllCoroutines();
            StartCoroutine(MoveInTornPage());
        }
    }
    public void ControlsButton()
    {
        if (tornPageOpen == false && tornPageIsMoving == false)
        {

            Options.SetActive(false);
            RateUs.SetActive(false);
            Credits.SetActive(false);
            Quit.SetActive(false);
            SkullPage.SetActive(false);
            newGame.SetActive(false);
            Controls.SetActive(true);


            StopAllCoroutines();
            StartCoroutine(MoveInTornPage());
        }
    }
    public void NewGameButton()
    {
        if (tornPageOpen == false && tornPageIsMoving == false)
        {
            if (thereAreSavedData == true)
            {
                Options.SetActive(false);
                RateUs.SetActive(false);
                Credits.SetActive(false);
                Quit.SetActive(false);
                SkullPage.SetActive(false);
                newGame.SetActive(true);
                Controls.SetActive(false);

                StopAllCoroutines();
                StartCoroutine(MoveInTornPage());

            }
            if (thereAreSavedData == false)
            {
                pageFlipper.NewGame();
            }
        }
    }

    public void newGameConfirm()
    {
        //script che resetta i dati di gioco
        StopAllCoroutines();
        StartCoroutine(MoveOutTornPageCoroutine());

        pageFlipper.NewGame();
    }

    public void QuitButton()
    {
        if (tornPageOpen == false && tornPageIsMoving == false)
        {

            Options.SetActive(false);
            RateUs.SetActive(false);
            Credits.SetActive(false);
            Quit.SetActive(true);
            SkullPage.SetActive(false);
            newGame.SetActive(false);
            Controls.SetActive(false);



            StopAllCoroutines();
            StartCoroutine(MoveInTornPage());
        }
    }

    public void ConfirmQuit()
    {
        Application.Quit();
    }

    public void SkullCollectionButton()
    {
        if (tornPageOpen == false && tornPageIsMoving == false)
        {

            Options.SetActive(false);
            RateUs.SetActive(false);
            Credits.SetActive(false);
            Quit.SetActive(false);
            SkullPage.SetActive(true);
            newGame.SetActive(false);
            Controls.SetActive(false);


            StopAllCoroutines();
            StartCoroutine(MoveInTornPage());
        }
    }

    public IEnumerator MoveInTornPage()
    {
        shadowPanel.SetActive(true);

        float progress = 0;
        while (progress < transitionTime)
        {
            tornPageIsMoving = true;
            tornPage.transform.position = Vector3.MoveTowards(tornPage.transform.position, endPos, progress * speed * Time.deltaTime);
            progress += Time.deltaTime;
            if (tornPage.transform.position == endPos)
            {
                tornPageOpen = true;
                tornPageIsMoving = false;
            }
            yield return null;
        }

    }

    public IEnumerator MoveOutTornPageCoroutine()
    {
        shadowPanel.SetActive(false);
        float progress = 0;
        while (progress < transitionTime)
        {
            tornPageIsMoving = true;
            tornPage.transform.position = Vector3.MoveTowards(tornPage.transform.position, startPos, progress * speed * Time.deltaTime);
            progress += Time.deltaTime;
            if (tornPage.transform.position == startPos)
            {
                tornPageOpen = false;
                tornPageIsMoving = false;
            }
            yield return null;
        }

    }
}
