using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Slider BossLife;
    public Boss boss;
    public GameObject arrow;
    public GameObject go;
    public static UIManager instance;

    void Update()
    {
        BossLife.value = boss.life / boss.maxLife;
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
