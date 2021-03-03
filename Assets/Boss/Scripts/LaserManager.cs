using UnityEngine;

public class LaserManager : MonoBehaviour
{
    [SerializeField] GameObject crack1;
    [SerializeField] GameObject crack2;
    [SerializeField] GameObject crack3;

    [SerializeField] GameObject particle1;
    [SerializeField] GameObject particle2;
    [SerializeField] GameObject particle3;

    public static LaserManager instance;

    [HideInInspector] public bool isActive = false;
    
    int rand;

    float timer = 0;
    bool isRandom = false;
    [SerializeField] float coolDown = 0;

    void Update()
    {
        if (isActive == false)
        {
            if(isRandom == false)
            {
                rand = Random.Range(1, 4);

                if (rand == 1)
                    particle1.SetActive(true);
                
                if (rand == 2)
                    particle2.SetActive(true);

                if (rand == 3)
                    particle3.SetActive(true);

                isRandom = true;
            }
                       
            timer += Time.deltaTime;

            if (rand == 1 && timer > coolDown)
            {
                crack1.SetActive(true);
                particle1.SetActive(false);
                timer = 0;
                isRandom = false;
            }

            if (rand == 2 && timer > coolDown)
            {
                crack2.SetActive(true);
                particle2.SetActive(false);
                timer = 0;
                isRandom = false;
            }


            if (rand == 3 && timer > coolDown)
            {
                crack3.SetActive(true);
                particle3.SetActive(false);
                timer = 0;
                isRandom = false;
            }               
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
