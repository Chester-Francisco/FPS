using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPopup : MonoBehaviour
{

    [SerializeField] private UIController uiController;
    [SerializeField] private SettingsPopUp settingsPopup;


    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
    public void OnSettingsButton()
    {
        Close();
        settingsPopup.Open();
    }
    public void OnExitGameButton()
    {
        Application.Quit();
        
    }
    public void OnReturnToGameButton()
    {
        Close();
        uiController.SetGameActive(true);
    }
}
