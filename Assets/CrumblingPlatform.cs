using UnityEngine;

public class CrumblingPlatform : MonoBehaviour
{
    public GameObject physicalPlatform;
    void Update()
    {
        if (Smash2.crumblingPlatforms)
        {
            GetComponent<Animator>().SetBool("Crumbling", true);
            physicalPlatform.SetActive(false);
        }
    }

}
