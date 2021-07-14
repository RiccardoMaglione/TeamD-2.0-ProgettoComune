﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
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
    [SerializeField] GameObject SadPage;
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

        if (SadPage != null)
        {
            OpenSadPage();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && tornPageOpen == true)
        {
            MoveOutTornPage();
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1) && CheckInput.XboxController == true)
        {
            MoveOutTornPage();
            EventSystem.current.SetSelectedGameObject(ChangeButton.PrecedentButton.gameObject);     //Controller - sistemare
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button2) && CheckInput.PlaystationController == true)
        {
            MoveOutTornPage();
            EventSystem.current.SetSelectedGameObject(ChangeButton.PrecedentButton.gameObject);     //Controller - sistemare
        }
    }

    public void MoveOutTornPage()
    {
        StopAllCoroutines();
        StartCoroutine(MoveOutTornPageCoroutine());
    }
    public void OptionsButton()
    {
        if (tornPageOpen == false && tornPageIsMoving == false && pageFlipper.aPageIsFlipping == false)
        {
            Options.SetActive(true);
            RateUs.SetActive(false);
            Credits.SetActive(false);
            Quit.SetActive(false);
            SkullPage.SetActive(false);
            newGame.SetActive(false);
            Controls.SetActive(false);
            SadPage.SetActive(false);



            StopAllCoroutines();
            StartCoroutine(MoveInTornPage());
        }
    }
    public void RateUsButton()
    {
        if (tornPageOpen == false && tornPageIsMoving == false && pageFlipper.aPageIsFlipping == false)
        {
            Options.SetActive(false);
            RateUs.SetActive(true);
            Credits.SetActive(false);
            Quit.SetActive(false);
            SkullPage.SetActive(false);
            newGame.SetActive(false);
            Controls.SetActive(false);
            SadPage.SetActive(false);


            StopAllCoroutines();
            StartCoroutine(MoveInTornPage());
        }
    }
    public void CreditsButton()
    {
        if (tornPageOpen == false && tornPageIsMoving == false && pageFlipper.aPageIsFlipping == false)
        {

            Options.SetActive(false);
            RateUs.SetActive(false);
            Credits.SetActive(true);
            Quit.SetActive(false);
            SkullPage.SetActive(false);
            newGame.SetActive(false);
            Controls.SetActive(false);
            SadPage.SetActive(false);


            StopAllCoroutines();
            StartCoroutine(MoveInTornPage());
        }
    }
    public void ControlsButton()
    {
        if (tornPageOpen == false && tornPageIsMoving == false && pageFlipper.aPageIsFlipping == false)
        {

            Options.SetActive(false);
            RateUs.SetActive(false);
            Credits.SetActive(false);
            Quit.SetActive(false);
            SkullPage.SetActive(false);
            newGame.SetActive(false);
            Controls.SetActive(true);
            SadPage.SetActive(false);


            StopAllCoroutines();
            StartCoroutine(MoveInTornPage());
        }
    }
    public void NewGameButton()
    {
        if (tornPageOpen == false && tornPageIsMoving == false && pageFlipper.aPageIsFlipping == false)
        {
            if (PlayerPrefs.GetInt("NewGameFirst") == 1)
            {
                Options.SetActive(false);
                RateUs.SetActive(false);
                Credits.SetActive(false);
                Quit.SetActive(false);
                SkullPage.SetActive(false);
                newGame.SetActive(true);
                Controls.SetActive(false);
                SadPage.SetActive(false);

                StopAllCoroutines();
                StartCoroutine(MoveInTornPage());

            }
            if (PlayerPrefs.GetInt("NewGameFirst") == 0)
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
        if (tornPageOpen == false && tornPageIsMoving == false && pageFlipper.aPageIsFlipping == false)
        {

            Options.SetActive(false);
            RateUs.SetActive(false);
            Credits.SetActive(false);
            Quit.SetActive(true);
            SkullPage.SetActive(false);
            newGame.SetActive(false);
            Controls.SetActive(false);
            SadPage.SetActive(false);



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
        if (tornPageOpen == false && tornPageIsMoving == false && pageFlipper.aPageIsFlipping == false)
        {

            Options.SetActive(false);
            RateUs.SetActive(false);
            Credits.SetActive(false);
            Quit.SetActive(false);
            SkullPage.SetActive(true);
            newGame.SetActive(false);
            Controls.SetActive(false);
            SadPage.SetActive(false);

            StopAllCoroutines();
            StartCoroutine(MoveInTornPage());
        }
    }
    public void OpenSadPage()
    {
        if (tornPageOpen == false && tornPageIsMoving == false && pageFlipper.aPageIsFlipping == false)
        {

            Options.SetActive(false);
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

    public IEnumerator MoveInTornPage()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_book_torn_page");
        }

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
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_book_torn_page");
        }

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
