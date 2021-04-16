using UnityEngine;

public class ToBossFight : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] cameras;
    [SerializeField] GameObject[] cameraConfiners;

    public void ToBossFightButton()
    {
        for (int i = 0; i < cameraConfiners.Length; i++)
        {
            if (i < 22)
                cameraConfiners[i].SetActive(false);
            if (i == 22)
            {
                cameraConfiners[22].SetActive(true);
            }
        }
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i < 22)
                cameras[i].SetActive(false);
            if (i == 22)
            {
                cameras[22].SetActive(true);
            }
        }

        player.transform.position = new Vector2(528, 27);
    }

}
