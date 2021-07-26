using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuController : MonoBehaviour
{
    #region Variables
    public List<GameObject> Page = new List<GameObject>();
    public List<GameObject> PageThatFlip = new List<GameObject>();
    public List<GameObject> PageLevel = new List<GameObject>();
    public List<GameObject> AnotherSidePageLevel = new List<GameObject>();
    public GameObject PageSelectionLevel;
    [Space(10)]
    public GameObject ShadowPanel;
    public GameObject NotInteractablePanel;
    

    public int PageFlipCount;
    bool EscBool;                
    public bool IsFlip = true;
    public bool IsTornPage;
    PageScriptableObject TempPageScriptable;
    #endregion

    private void Start()
    {
        BetaNotePage((PageScriptableObject)Resources.Load("Page/BetaNote"));
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button1))       //Manca assegnazione tasto da controller
        {
            if (TempPageScriptable != null)
            {
                ExitTornPage(TempPageScriptable);
                ControllerManagement.ControllerManagementInstance.SetPrecedentSelectedGameObjectController();
            }
            else if (TempPageScriptable == null && IsFlip == false && IsTornPage == false)
            {
                PageFlip();
            }
        }
        if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && IsFlip == false)
        {
            PageFlipBack();
        }

        for (int i = 0; i < PageLevel.Count; i++)
        {
            BackToPageLevelSelection(PageLevel[i]);
        }
    }

    #region Torn Page

    /// <summary>
    /// Metodo di assegnazione della pagina
    /// </summary>
    /// <param name="PageScriptable">Pagina assegnata</param>
    public void AssingPage(PageScriptableObject PageScriptable, bool ShadowPanelEnable, string SfxAudio)
    {
        TempPageScriptable = PageScriptable;
        if(ShadowPanel != null)
        {
            ShadowPanel.SetActive(ShadowPanelEnable);
        }
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play(SfxAudio);
        }
    }

    /// <summary>
    /// Metodo che entra nella pagina
    /// </summary>
    /// <param name="PageScriptable">Pagina da aprire</param>
    public void EnterTornPage(PageScriptableObject PageScriptable)
    {
        if(TempPageScriptable == null && EscBool == true)
        {
            PageCallback(PageScriptable, true, false, true);
            AssingPage(PageScriptable, true, "Sfx_book_torn_page");
            Page[PageScriptable.IDPage].transform.DOLocalMoveX(PageScriptable.EndPos.x, PageScriptable.EnterTransitionTime).OnComplete(() => NotInteractablePanel.SetActive(false));     //Si apre - OnComplete finito di aprirsi
            IsTornPage = true;
        }
    }

    /// <summary>
    /// Metodo che esce dalla pagina
    /// </summary>
    /// <param name="PageScriptable">Pagina da chiudere</param>
    public void ExitTornPage(PageScriptableObject PageScriptable)
    {
        if (TempPageScriptable != null)
        {
            NotInteractablePanel.SetActive(true);
            AssingPage(null, false, "Sfx_book_torn_page");
            Page[PageScriptable.IDPage].transform.DOLocalMoveX(PageScriptable.StartPos.x, PageScriptable.ExitTransitionTime).OnComplete(() => { PageCallback(PageScriptable, false, true, false); IsTornPage = false; });        //Si chiude - OnComplete finito di chiudersi
        }
    }

    /// <summary>
    /// Callback che attiva o disattiva la pagina e setta la bool che evita multiple pagine attive
    /// </summary>
    /// <param name="PageScriptable"></param>
    /// <param name="IsPageEnabled"></param>
    /// <param name="IsEscBool"></param>
    public void PageCallback(PageScriptableObject PageScriptable, bool IsPageEnabled, bool IsEscBool, bool TestBool)
    {
        EscBool = IsEscBool;
        Page[PageScriptable.IDPage].SetActive(IsPageEnabled);
        NotInteractablePanel.SetActive(TestBool);
    }

    /// <summary>
    /// Appare schermata di avvertimenti sui bug e demo
    /// </summary>
    /// <param name="PageScriptable"></param>
    /// <param name="IDPage"></param>
    public void BetaNotePage(PageScriptableObject PageScriptable)
    {
        if (CheckFirstPlay.IsStartExe == true)
        {
            CheckFirstPlay.IsStartExe = false;
            AssingPage(PageScriptable, true, null);
            Page[PageScriptable.IDPage].SetActive(true);
            Page[PageScriptable.IDPage].transform.DOLocalMoveX(PageScriptable.EndPos.x, PageScriptable.EnterTransitionTime);
        }
    }
    
    #endregion

    #region Flip Page

    /// <summary>
    /// Metodo che gira la pagina in modo tale che si apra - Gira verso destra
    /// </summary>
    public void PageFlip()
    {
        if(PageFlipCount > 0 && IsFlip == false && CheckEnablePageLevel() == false && PageFlipCount != 1)
        {
            IsFlip = true;
            PageFlipCount--;

            if ((PageFlipCount + 1) == PageThatFlip.Count)
            {
                for (int i = 0; i < PageThatFlip.Count; i++)
                {
                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.Play("Sfx_mouse_on_button");
                    }
                    NotInteractablePanel.SetActive(true);
                    PageThatFlip[PageFlipCount].transform.DORotate(Vector3.zero, 1).OnComplete(() => { BackToMenuFromLevelSelection(); IsFlip = true; PageSelectionLevel.SetActive(false); NotInteractablePanel.SetActive(false); });
                    if (PageFlipCount > 0)
                    {
                        PageFlipCount--;
                    }
                }
            }
            else
            {
                if (AudioManager.instance != null)
                {
                    AudioManager.instance.Play("Sfx_mouse_on_button");
                }
                PageThatFlip[PageFlipCount].transform.DORotate(Vector3.zero, 1).OnComplete(() => {/* if ((PageFlipCount + 1) == PageThatFlip.Count) { PageSelectionLevel.SetActive(false); }*/ IsFlip = false; PageThatFlip[(PageFlipCount + 1)].SetActive(false); NotInteractablePanel.SetActive(false); });
            }
        }
    }

    /// <summary>
    /// Metodo che gira la pagina in modo tale che si apra - Gira verso sinistra
    /// </summary>
    public void PageFlipBack()
    {
        if(PageFlipCount < PageThatFlip.Count && IsFlip == false)
        {
            IsFlip = true;
            if (AudioManager.instance != null)
            {
                AudioManager.instance.Play("Sfx_mouse_on_button");
            }
            NotInteractablePanel.SetActive(true);
            PageThatFlip[PageFlipCount].transform.DORotate(new Vector3(0, 180, 0), 1).OnComplete(() => { IsFlip = false; NotInteractablePanel.SetActive(false); });
            PageFlipCount++;
            if (PageFlipCount < PageThatFlip.Count)
            {
                PageThatFlip[PageFlipCount].SetActive(true);
            }
            if (PageFlipCount == PageThatFlip.Count)
            {
                PageSelectionLevel.SetActive(true);
                ControllerManagement.ControllerManagementInstance.CheckCurrentPage(PageSelectionLevel);
            }
        }

    }

    //--------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Metodo che va alla pagina del livello selezionato
    /// </summary>
    /// <param name="PageLevelSelected"></param>
    public void GoToPageLevelSelected(GameObject PageLevelSelected)
    {
        if(IsFlip == true)                      //Evita che si fermi nella selezione dei livelli se viene spammato il pulsante di conferma
        {
            IsFlip = false;
            NotInteractablePanel.SetActive(true);
        }
        if(IsFlip == false)
        {
            if (AudioManager.instance != null)
            {
                AudioManager.instance.Play("Sfx_mouse_on_button");
            }
            PageSelectionLevel.transform.DORotate(new Vector3(0, 180, 0), 1).OnComplete(() => { IsFlip = false; NotInteractablePanel.SetActive(false); });
            PageLevelSelected.SetActive(true);
        }
    }
    
    /// <summary>
    /// Metodo che attiva l'altro lato della pagina in base al livello selezionato
    /// </summary>
    /// <param name="AnotherSidePageLevelSelected"></param>
    public void GoToAnotherSidePageLevelSelected(GameObject AnotherSidePageLevelSelected)
    {
        if (IsFlip == false)
        {
            IsFlip = true;
            AnotherSidePageLevelSelected.SetActive(true);
        }
    }
    
    //GoToPageLevelSelected e GoToAnotherSidePageLevelSelected vengono eseguiti in ordine - Non va cambiato l'ordine
    
    /// <summary>
    /// Metodo che torna alla pagina della selezione dei livelli
    /// </summary>
    /// <param name="PageLevelSelected"></param>
    public void BackToPageLevelSelection(GameObject PageLevelSelected)
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button1)) && PageLevelSelected.activeSelf == true && IsFlip == false && IsTornPage == false)
        {
            IsFlip = true;
            if (AudioManager.instance != null)
            {
                AudioManager.instance.Play("Sfx_mouse_on_button");
            }
            PageSelectionLevel.transform.DORotate(Vector3.zero, 1).OnComplete(() => { PageLevelSelected.SetActive(false); IsFlip = false; for (int i = 0; i < AnotherSidePageLevel.Count; i++) { AnotherSidePageLevel[i].SetActive(false); } NotInteractablePanel.SetActive(false); });
            ControllerManagement.ControllerManagementInstance.CheckCurrentPage(PageSelectionLevel);
        }

    }
    
    /// <summary>
    /// Metodo che torna dalla pagina della selezione dei livelli al menù
    /// </summary>
    public void BackToMenuFromLevelSelection()
    {
        for (int i = 1; i < PageThatFlip.Count; i++)
        {
            PageThatFlip[i].SetActive(false);
            ControllerManagement.ControllerManagementInstance.CheckCurrentPage(null);
        }
    }
    
    /// <summary>
    /// Controlla le pagine attive e aumenta il counter
    /// </summary>
    /// <returns></returns>
    public bool CheckEnablePageLevel()
    {
        int CountDetect = 0;
        for (int i = 0; i < PageLevel.Count; i++)
        {
            if (PageLevel[i].activeSelf == false)
            {
                CountDetect++;
            }
        }
        if (CountDetect == PageLevel.Count)
        {
            CountDetect = 0;
            return false;
        }
        return true;
    }

    /// <summary>
    /// Metodo che attiva le pagine della storia attraverso il new game
    /// </summary>
    public void YesNewGame()
    {
        //PageThatFlip[0].SetActive(true);
        IsFlip = false;
        ExitTornPage(TempPageScriptable);
        ControllerManagement.ControllerManagementInstance.SetSelectedGameObjectController(null);
        PageFlipBack();
    }

    /// <summary>
    /// Metodo che dal pulsante continua va alla pagina di selezione livelli
    /// </summary>
    public void ContinueToMap()
    {
        IsFlip = true;
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_mouse_on_button");
        }
        PageThatFlip[PageFlipCount].transform.DORotate(new Vector3(0, 180, 0), 1).OnComplete(() => IsFlip = false);
        PageThatFlip[PageThatFlip.Count - 1].SetActive(true);
        PageThatFlip[PageThatFlip.Count - 1].transform.DORotate(new Vector3(0, 180, 0), 1).OnComplete(() => IsFlip = false);
        PageFlipCount = PageThatFlip.Count;
        if (PageFlipCount == PageThatFlip.Count)
        {
            PageSelectionLevel.SetActive(true);
        }
    }

    #endregion

    #region Other Methods
    /// <summary>
    /// Esce dal gioco
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResetPrefsGameplay(int IDPrefs)
    {
        if (PlayerPrefs.GetInt("NewGameFirst") == IDPrefs)
        {
            PlayerPrefs.SetInt("ObtainSkull", 0);
            PlayerPrefs.SetFloat("BestTimer", 0);
            PlayerPrefs.SetString("StringTimerGameplay", "00:00:00");
            PlayerPrefs.SetFloat("TimerGameplay", 0);
            PlayerPrefs.SetInt("CountPossession", 0);
        }
    }

    public void FirstPlayMenu()
    {
        //Metodo che fa comparire la prima volta continue grigio e le altre volte no, compreso l'uscita della pagina e non
    }

    /// <summary>
    /// Metodo che apre un url tramite una stringa
    /// </summary>
    /// <param name="URLWeb">URL del sito da aprire</param>
    public void OpenUrl(string URLWeb)
    {
        Application.OpenURL(URLWeb);
    }

    public void TestDebug()
    {
        Debug.Log("Selezionato");
    }

    #endregion
}

//Aggiungere le seguenti cose
//- Bloccare indietro dalla prima pagina del new game story - fatto
//- NotInteractablePanel nella selezione livelli - non serve
//- Ho messo il not interactable panel per non rendere selezionabili i pulsanti yes e no nella transizione, verificare se tenere così o no