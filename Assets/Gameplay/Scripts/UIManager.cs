using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Slider BossLife;
    public Boss boss;

    void Update()
    {
        BossLife.value = boss.life / boss.maxLife;
    }
}
