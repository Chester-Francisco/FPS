using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image crossHair;
    [SerializeField] private OptionsPopUp optionsPopup;
    [SerializeField] private SettingsPopUp settingsPopup;
    [SerializeField] private GameOverPopUp gameOverPopUp;

    private int popupsActive = 0;


    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth(1.0f);
        SetGameActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyUp(KeyCode.Escape) && !optionsPopup.IsActive() && !settingsPopup.IsActive())
        //{
        //    SetGameActive(false); 
        //    optionsPopup.Open();
        //}
        if (Input.GetKeyUp(KeyCode.Escape) && popupsActive == 0)
        {
         
            optionsPopup.Open();
        }
    }

    public void UpdateScore(int newScore)
    {
        scoreValue.text = newScore.ToString();
    }

    public void SetGameActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            crossHair.gameObject.SetActive(true);
            Messenger<bool>.Broadcast(GameEvent.GAME_ACTIVE, active);
        }
        else
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            crossHair.gameObject.SetActive(false);
            Messenger<bool>.Broadcast(GameEvent.GAME_INACTIVE, active);
        }

    }

    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.HEALTH_CHANGED, OnHealthChange);
        Messenger.AddListener(GameEvent.POPUP_OPENED, OnPopUpOpened);
        Messenger.AddListener(GameEvent.POPUP_CLOSED, OnPopUpClosed);
    }

    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.HEALTH_CHANGED, OnHealthChange);
        Messenger.RemoveListener(GameEvent.POPUP_OPENED, OnPopUpOpened);
        Messenger.RemoveListener(GameEvent.POPUP_CLOSED, OnPopUpClosed);
    }

    private void OnHealthChange(float newVal)
    {
       UpdateHealth(newVal);
    }

    private void UpdateHealth(float healthPercentage)
    {
        healthBar.color = Color.Lerp(Color.red, Color.green, healthPercentage);
        healthBar.fillAmount = healthPercentage;
    }

    private void OnPopUpOpened()
    {
        if(popupsActive == 0)
        {
            SetGameActive(false);
        }
        popupsActive++;
    }

    private void OnPopUpClosed()
    {
        popupsActive--;
        if(popupsActive == 0)
        {
            SetGameActive(true);
        }
    }

    public void ShowGameOverPopup()
    {
        gameOverPopUp.Open();
    }

}
