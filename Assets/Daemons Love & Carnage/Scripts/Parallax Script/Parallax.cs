using Cinemachine;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    float lenght, startPos;
    public CinemachineVirtualCamera cam;
    public float parallaxEffect;

    void Start()
    {
        startPos = transform.position.x;

        if (GetComponent<SpriteRenderer>() != null)
            lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        //cam = FindObjectOfType<CinemachineVirtualCamera>();

        foreach (CinemachineVirtualCamera CamItem in ChangeFollow.CFInstance.CamList)
        {
            if(CamItem.isActiveAndEnabled == true)
            {
                cam = CamItem;
            }
        }
        
        
        
        cam.transform.position = new Vector3(FixParallax.position.x, FixParallax.position.y, FixParallax.position.z);
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + lenght) startPos += lenght;
        else
            if (temp < startPos - lenght) startPos -= lenght;
    }
}
