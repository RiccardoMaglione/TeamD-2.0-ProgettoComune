using System.Collections;
using UnityEngine;

public class PageFlipper : MonoBehaviour
{
    [SerializeField]
    private GameObject page1Pivot;
    [SerializeField]
    private GameObject page2Pivot;
    [SerializeField]
    private GameObject page3Pivot;
    [SerializeField]
    private GameObject page4Pivot;
    [SerializeField]
    private GameObject page5Pivot;
    [SerializeField]
    private GameObject page6Pivot;

    private Quaternion notFlippedPosition;
    private Quaternion flippedPosition;

    private int pageCounter;

    private float flipTime = 5;
    [SerializeField]
    private float flipSpeed;

    private void Start()
    {
        pageCounter = 0;
        notFlippedPosition = Quaternion.Euler(0, 0, 0);
        flippedPosition = Quaternion.Euler(0, 180, 0);
    }
    public void Page1FlipForward()
    {
        StopAllCoroutines();
        StartCoroutine(Page1FlipForwardCoroutine());
    }
    public void Page1FlipFBackward()
    {
        StopAllCoroutines();
        StartCoroutine(Page1FlipBackwardCoroutine());
    }

    IEnumerator Page1FlipForwardCoroutine()
    {
        float progress = 0;
        while (progress < flipTime)
        {
            page1Pivot.transform.rotation = Quaternion.Lerp(flippedPosition, notFlippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            /*if (page1Pivot.transform.rotation.y == 0)
            {
                progress = flipTime;
            }*/
            yield return null;
        }
    }
    IEnumerator Page1FlipBackwardCoroutine()
    {
        float progress = 0;
        while (progress < flipTime)
        {
            page1Pivot.transform.rotation = Quaternion.Lerp(notFlippedPosition, flippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            /*if (page1Pivot.transform.rotation.y == 180)
            {
                progress = flipTime;
            }*/
            yield return null;
        }
    }

}
