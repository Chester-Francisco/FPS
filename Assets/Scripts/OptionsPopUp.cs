using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPopUp : BasePopUp
{

    [SerializeField] private UIController uiController;
    [SerializeField] private SettingsPopUp settingsPopup;


    
    public void OnSettingsButton()
    {
        base.Close();
        settingsPopup.Open();
    }
    public void OnExitGameButton()
    {
        Application.Quit();
        
    }
    public void OnReturnToGameButton()
    {
        base.Close();
        uiController.SetGameActive(true);
    }

    
}
