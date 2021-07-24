using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControllerManagement : MonoBehaviour
{
    public static ControllerManagement ControllerManagementInstance;

    public GameObject PageSelectionLevel;

    public GameObject PrecedentSelectedCheck;               //Pulsante precedente alla pagina
    public GameObject CurrentSelected;                      //Pulsante corrente nella pagina
    
    public GameObject PrecedentSelected;
    public GameObject PageBetaNote;
    private void Awake()                        //Creare singleton
    {
        ControllerManagementInstance = this;
    }

    private void Update()
    {
        if (PageBetaNote.activeSelf == true && PrecedentSelected == null)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void SetSelectedGameObjectController(GameObject NextSelected)
    {
        PrecedentSelected = EventSystem.current.currentSelectedGameObject;
        EventSystem.current.SetSelectedGameObject(NextSelected);
    }

    public void SetPrecedentSelectedGameObjectController()
    {
        if(PrecedentSelected == null)
        {
            PrecedentSelected = EventSystem.current.firstSelectedGameObject;
            EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(PrecedentSelected);
        }
    }

    public void CheckCurrentPage(GameObject CurrentPage)
    {
        if (CurrentPage == PageSelectionLevel)
        {
            SetSelectedGameObjectController(CurrentSelected);
        }
        else 
        {
            SetSelectedGameObjectController(PrecedentSelectedCheck);
        }
    }
}


//TODO: Metodo di selezione quando va indietro

//Quando sono nella pagina di selezione livelli devo settare quello corrente, il successivo e il precedente
//- Precedente: pulsante continue o new game
//- Corrente: pulsante 3
//- Successivo: pulsante play

//Quando apro la storia dal new game, devo deselezionare tutti i tasti