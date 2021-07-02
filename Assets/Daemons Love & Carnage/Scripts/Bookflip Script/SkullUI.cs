using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkullUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] TMP_Text skullDescription;
    [SerializeField] TMP_Text skullCounterText;

    [HideInInspector] public int skullCounter = 0;

    public bool skullActive = false;

    public Sprite SkulNormal;
    public Sprite SkullOvered;
    public Sprite SkullPressed;
    public Sprite SkullSelected;

    public void OnPointerEnter(PointerEventData eventData)
    {
        skullDescription.text = "Skull description placeholder";

    }

    private void Update()
    {
        skullCounterText.text = skullCounter.ToString();
        if (skullActive)
        {
            //this.GetComponent<Button>().Select();
        }

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        skullDescription.text = "Move on an unlocked skull to read its description";
    }
    public void ActivateSkull()
    { 
        if (skullActive == false)
        {
            if (AudioManager.instance != null)
            {
                AudioManager.instance.Play("Sfx_skull_activate");
            }
            skullActive = true;
            skullCounter++;
            GetComponent<Image>().sprite = SkullSelected;
            //this.GetComponent<Button>().Select();
            SkullEffect();
        }

        else
        {
            if (AudioManager.instance != null)
            {
                AudioManager.instance.Play("Sfx_skull_deactivate");
            }
            skullActive = false;
            skullCounter--;
            GetComponent<Image>().sprite = SkulNormal;
            SkullEffect();
        }
    }

    public void SkullEffect()
    {
        if (skullActive)
        {
            //Qui ci metteremo l'effetto del teschio in game
        }
        else
        {
            //Disattivazione dell'effetto
        }
    }

    public void HoverSkull()
    {
        if(GetComponent<Image>().sprite != SkullSelected)
        {
            GetComponent<Image>().sprite = SkullOvered;
        }
    }
    public void DeHoverSkull()
    {
        if (GetComponent<Image>().sprite != SkullSelected)
        {
            GetComponent<Image>().sprite = SkulNormal;
        }
    }
    public void PressedSkull()
    {
        GetComponent<Image>().sprite = SkullPressed;
    }
}
