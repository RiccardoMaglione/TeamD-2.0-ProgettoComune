using UnityEngine;

public class ToBossFight : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] cameras;
    [SerializeField] GameObject[] cameraConfiners;
    [SerializeField] GameObject Enemies0;

    [SerializeField] GameObject graphicsToEnable1;
    [SerializeField] GameObject graphicsToEnable2;


    public void ToBossFightButton()
    {
        if (Enemies0 != null)
            Enemies0.SetActive(false);

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
        graphicsToEnable1.SetActive(true);
        graphicsToEnable2.SetActive(true);

        //SceneManager.LoadScene(3);
        //Time.timeScale = 1;

    }


}
