using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //public Slider BossLife;
    //public Boss boss;
    public GameObject arrow;
    public static UIManager instance;

    void Update()
    {
        //BossLife.value = boss.life / boss.maxLife;
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
