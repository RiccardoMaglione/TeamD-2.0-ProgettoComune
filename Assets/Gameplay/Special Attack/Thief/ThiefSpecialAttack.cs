using SwordGame;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ThiefSpecialAttack : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float time;
    public bool isSpecialActive = false;

    public static ThiefSpecialAttack instance;

    public bool DecreaseEnergy;

    public IEnumerator Attack()
    {
        DecreaseEnergy = true;
        isSpecialActive = true;
        yield return new WaitForSeconds(time);
        DecreaseEnergy = false;
        GetComponentInParent<PSMController>().CurrentEnergy = (int)GetComponentInParent<PSMController>().CurrentEnergy;
        isSpecialActive = false;
        animator.SetBool("IsAttack", false);
        animator.GetComponentInParent<PSMController>().GetComponent<Animator>().SetBool("PSM-SpecialAttack", false);
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (DecreaseEnergy == true)
        {
            GetComponentInParent<PSMController>().CurrentEnergy -= Time.deltaTime * ((GetComponentInParent<PSMController>().MaxEnergy / time));
            EnergyBar.EBInstance.glowing.GetComponent<Image>().fillAmount -= (Time.deltaTime * ((GetComponentInParent<PSMController>().MaxEnergy / time)) / 100);

        }
    }
}
