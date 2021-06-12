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


    public void OnPointerEnter(PointerEventData eventData)
    {
        skullDescription.text = "Skull description placeholder";

    }

    private void Update()
    {
        skullCounterText.text = skullCounter.ToString();
        if (skullActive)
        {
            this.GetComponent<Button>().Select();
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
            AudioManager.instance.Play("Sfx_skull_activate");
            skullActive = true;
            skullCounter++;
            this.GetComponent<Button>().Select();
            SkullEffect();
        }

        else
        {
            AudioManager.instance.Play("Sfx_skull_deactivate");
            skullActive = false;
            skullCounter--;
            EventSystem.current.SetSelectedGameObject(null);
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
}
