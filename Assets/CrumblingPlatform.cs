using UnityEngine;

public class CrumblingPlatform : MonoBehaviour
{
    public GameObject physicalPlatform;
    public Smash2 smash2;
    void Update()
    {
        if (smash2.crumblingPlatforms)
        {
            GetComponent<Animator>().SetBool("Crumbling", true);
            physicalPlatform.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
