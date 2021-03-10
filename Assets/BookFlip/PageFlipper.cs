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

    [SerializeField]
    private float flipSpeed;

    private void Start()
    {
        pageCounter = 0;
        notFlippedPosition = Quaternion.Euler(0, 0, 0);
        flippedPosition = Quaternion.Euler(0, 180, 0);
    }
    /*private void Update()
    {
        page1Pivot.transform.rotation = Quaternion.Lerp(flippedPosition, notFlippedPosition, Time.time * flipSpeed);

    }*/
    public void Page1FlipForward()
    {
        StartCoroutine(Page1FlipForwardCoroutine());
    }
    public void Page1FlipFBackward()
    {
    }

    IEnumerator Page1FlipForwardCoroutine()
    {
        while (pageCounter < 2)
            page1Pivot.transform.rotation = Quaternion.Lerp(flippedPosition, notFlippedPosition, Time.time * flipSpeed);
        yield return null;
    }
}
