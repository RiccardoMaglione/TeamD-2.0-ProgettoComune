using UnityEngine;

public class ScoreMultiplierManager : MonoBehaviour
{
    public static ScoreMultiplierManager instance;

    [Header("NUMERO DI NEMICI PER ATTIVARE OGNI MOLTIPLICATORE")]
    
    [ReadOnly]
    public float enemyDeathCount = 0;
    public int enemyMultiplier1Count = 0;
    public int enemyMultiplier2Count = 0;
    public int enemyMultiplier3Count = 0;
    public int enemyMultiplier4Count = 0;
    public int enemyMultiplier5Count = 0;

    [Header("MULTIPLIERS VALUES")]
    public float multiplier1Value = 0;
    public float multiplier2Value = 0;
    public float multiplier3Value = 0;
    public float multiplier4Value = 0;
    public float multiplier5Value = 0;

    [ReadOnly]
    public float actualMultiplierValue = 1;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Update()
    {
        if (enemyDeathCount >= enemyMultiplier5Count)
            actualMultiplierValue = multiplier5Value;

        else
        if(enemyDeathCount >= enemyMultiplier4Count)
            actualMultiplierValue = multiplier4Value;

        else
        if (enemyDeathCount >= enemyMultiplier3Count)
            actualMultiplierValue = multiplier3Value;

        else
        if (enemyDeathCount >= enemyMultiplier2Count)
            actualMultiplierValue = multiplier2Value;

        else
        if (enemyDeathCount >= enemyMultiplier1Count)
            actualMultiplierValue = multiplier1Value;

        else
        if (enemyDeathCount < enemyMultiplier1Count)
            actualMultiplierValue = 1;
    }
}
