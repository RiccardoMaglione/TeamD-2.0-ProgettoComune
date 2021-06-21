using UnityEngine;

public class LowHPScript : MonoBehaviour
{
    public static LowHPScript lowHPScript;

    private void Awake()
    {
        lowHPScript = this;
        gameObject.SetActive(false);

    }
}
