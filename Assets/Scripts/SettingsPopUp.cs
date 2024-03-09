using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SettingsPopUp : MonoBehaviour
{
    [SerializeField] private UIController uiController;
    [SerializeField] private OptionsPopup options;
    [SerializeField] private TextMeshProUGUI difficultyValue;
    [SerializeField] private Slider slider;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Update()
    {
        
    }

    public void UpdateDifficulty()
    {
        difficultyValue.text = slider.value.ToString();
    }
    public void OnOKButton()
    {
  
        Close();
        uiController.SetGameActive(true);
    }

    public void OnCancelButton()
    {
        Close();
        options.Open();
    }

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


}
