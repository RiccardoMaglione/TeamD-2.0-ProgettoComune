using Cinemachine;
using SwordGame;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CircleWipe : MonoBehaviour
{
    public RectTransform RT;
    public float timer;
    public float speed;
    public GameObject deathCam;
    public GameObject mainCamera;
    public static CircleWipe CW;

    private void Awake()
    {
        CW = this;
        AudioManager.instance.FadeOut("GameplayOST1");
        AudioManager.instance.FadeOut("GameplayOST2");
        AudioManager.instance.FadeOut("BossOST");
    }
    void Start()
    {
        InitializeScaleCircle();
    }

    void Update()
    {
        ScaleCircle();
    }

    public void InitializeScaleCircle()
    {
        RT = GetComponent<RectTransform>();
        RT.sizeDelta = new Vector2(2850, 2850);
    }

    public void ScaleCircle()
    {
        if (RT.sizeDelta.x >= 0 && RT.sizeDelta.y >= 0)
        {
            timer += Time.deltaTime;
            RT.sizeDelta = new Vector2(2850 - timer * speed, 2850 - timer * speed);
        }
        if (RT.sizeDelta.x <= 0 && RT.sizeDelta.y <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void DeathCamera()
    {
        mainCamera.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time = 1f;
        deathCam.transform.position = FindObjectOfType<PSMController>().transform.position;
        deathCam.SetActive(true);
    }
}
