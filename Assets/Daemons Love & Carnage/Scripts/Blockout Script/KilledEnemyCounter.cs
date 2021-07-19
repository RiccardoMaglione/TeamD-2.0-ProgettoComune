using UnityEngine;

public class KilledEnemyCounter : MonoBehaviour
{
    public static KilledEnemyCounter KilledEnemyCounterInstance;
    public int killedEnemyCounter;

    private void Awake()
    {
        KilledEnemyCounterInstance = this;
    }
}
