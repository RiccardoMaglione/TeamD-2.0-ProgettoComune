using UnityEngine;

public class RandomStartAnimation : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Animator>().speed = Random.Range(0.6f, 1.2f);
    }
}
