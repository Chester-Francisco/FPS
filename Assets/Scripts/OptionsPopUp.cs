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
        Debug.Log("settings clicked");
        Close();
        settingsPopup.Open();
    }
    public void OnExitGameButton()
    {
        Debug.Log("exit game");
        Application.Quit();
        
    }
    public void OnReturnToGameButton()
    {
        Debug.Log("return to game");
        Close();
        uiController.SetGameActive(true);
    }
}
