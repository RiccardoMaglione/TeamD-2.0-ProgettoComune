using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float enemyKillPoints = 0;
    public float bossKillPoints = 0;
    public float possessionPoints = 0;
    public float specialAttackActivationPoints = 0;
    public float skullCollectPoints = 0;
    public float lightAttackPoints = 0;
    public float heavyAttackPoints = 0;

    [ReadOnly]
    public float totatPoints;

    public void AddEnemyKillPoints()
    {
        totatPoints = totatPoints + enemyKillPoints * ScoreMultiplierManager.instance.actualMultiplierValue;
    }

    public void AddBossKillPoints()
    {
        totatPoints = totatPoints + bossKillPoints * ScoreMultiplierManager.instance.actualMultiplierValue;
    }

    public void AddPossessionPoints()
    {
        totatPoints = totatPoints + possessionPoints * ScoreMultiplierManager.instance.actualMultiplierValue;
    }

    public void AddSpecialAttackActivationPoints()
    {
        totatPoints = totatPoints + specialAttackActivationPoints * ScoreMultiplierManager.instance.actualMultiplierValue;
    }

    public void AddSkullCollectionPoints()
    {
        totatPoints = totatPoints + skullCollectPoints * ScoreMultiplierManager.instance.actualMultiplierValue;
    }

    public void AddLightAttackPoints()
    {
        totatPoints = totatPoints + lightAttackPoints * ScoreMultiplierManager.instance.actualMultiplierValue;
    }

    public void AddHeavyAttackPoints()
    {
        totatPoints = totatPoints + heavyAttackPoints * ScoreMultiplierManager.instance.actualMultiplierValue;
    }
}
