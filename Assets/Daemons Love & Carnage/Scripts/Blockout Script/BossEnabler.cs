using UnityEngine;

public class BossEnabler : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] GameObject bossSlider;

    public float activationTime = 0.2f;

    public void ActiveBoss()
    {
        boss.SetActive(true);
        bossSlider.SetActive(true);
    }
}
