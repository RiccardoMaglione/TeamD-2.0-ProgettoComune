using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject nextCamera;
    public GameObject currentCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            nextCamera.SetActive(true);
            this.gameObject.SetActive(false);
            currentCamera.SetActive(false);
        }
    }

}
