using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] GameObject[] waves;

    int i = 0;
    private void OnEnable()
    {
        waves[i].SetActive(true);
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 1)
        {
            i++;
            if (i < waves.Length)
                waves[i].SetActive(true);

            if (i == waves.Length)
            {
                UIManager.instance.arrow.SetActive(true);
                gameObject.SetActive(false);
            }

        }
    }
}
