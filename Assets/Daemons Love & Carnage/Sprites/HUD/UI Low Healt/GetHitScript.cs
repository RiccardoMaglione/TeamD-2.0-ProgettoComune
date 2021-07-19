using UnityEngine;

public class GetHitScript : MonoBehaviour
{
    public static GetHitScript getHitScript;

    private void Awake()
    {
        getHitScript = this;
        gameObject.SetActive(false);
    }
}
