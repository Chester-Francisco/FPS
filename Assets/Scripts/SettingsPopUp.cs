using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SettingsPopUp : MonoBehaviour
{
    [SerializeField] private OptionsPopup optionsPopup;
    [SerializeField] private TextMeshProUGUI difficultyValue;
    [SerializeField] private Slider slider;


    // Start is called before the first frame update
    void Start()
    {
       difficultyValue.text = slider.value.ToString();
    }

    public void UpdateDifficulty()
    {
        difficultyValue.text = slider.value.ToString();
    }
    public void OnOKButton()
    {
        Close();
        optionsPopup.Open();
    }

    public void OnCancelButton()
    {
        Close();
        optionsPopup.Open();
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
