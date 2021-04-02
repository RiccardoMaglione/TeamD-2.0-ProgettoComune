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
    [SerializeField] GameObject shadowPanel;

    private float transitionTime = 10;

    public bool tornPageOpen = false;


    private void Start()
    {
        startPos = tornPage.transform.position;
        endPos = tornPageDestination.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopAllCoroutines();
            StartCoroutine(MoveOutTornPage());
        }
    }
    public void OptionsButton()
    {
        if (tornPageOpen == false && PageFlipper.aPageIsFlipping == false)
        {
            Options.SetActive(true);
            RateUs.SetActive(false);
            Credits.SetActive(false);
            Quit.SetActive(false);

            StopAllCoroutines();
            StartCoroutine(MoveInTornPage());
        }
    }

    public void RateUsButton()
    {
        if (tornPageOpen == false && PageFlipper.aPageIsFlipping == false)
        {
            Options.SetActive(false);
            RateUs.SetActive(true);
            Credits.SetActive(false);
            Quit.SetActive(false);

            StopAllCoroutines();
            StartCoroutine(MoveInTornPage());
        }
    }

    public void CreditsButton()
    {
        if (tornPageOpen == false && PageFlipper.aPageIsFlipping == false)
        {

            Options.SetActive(false);
            RateUs.SetActive(false);
            Credits.SetActive(true);
            Quit.SetActive(false);

            StopAllCoroutines();
            StartCoroutine(MoveInTornPage());
        }
    }

    public void QuitButton()
    {
        if (tornPageOpen == false && PageFlipper.aPageIsFlipping == false)
        {

            Options.SetActive(false);
            RateUs.SetActive(false);
            Credits.SetActive(false);
            Quit.SetActive(true);

            StopAllCoroutines();
            StartCoroutine(MoveInTornPage());
        }
    }


    public IEnumerator MoveInTornPage()
    {
        float progress = 0;
        while (progress < transitionTime)
        {
            PageFlipper.aPageIsFlipping = true;
            tornPage.transform.position = Vector3.MoveTowards(tornPage.transform.position, endPos, progress * speed * Time.deltaTime);
            progress += Time.deltaTime;
            if (tornPage.transform.position == endPos)
            {
                tornPageOpen = true;
                PageFlipper.aPageIsFlipping = false;
                shadowPanel.SetActive(true);
            }
            yield return null;
        }

    }

    public IEnumerator MoveOutTornPage()
    {
        shadowPanel.SetActive(false);
        float progress = 0;
        while (progress < transitionTime)
        {
            PageFlipper.aPageIsFlipping = true;
            tornPage.transform.position = Vector3.MoveTowards(tornPage.transform.position, startPos, progress * speed * Time.deltaTime);
            progress += Time.deltaTime;
            if (tornPage.transform.position == startPos)
            {
                tornPageOpen = false;
                PageFlipper.aPageIsFlipping = false;
            }
            yield return null;
        }

    }
}
