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
       //difficultyValue.text = slider.value.ToString();
    }

    public void UpdateDifficulty(float difficulty)
    {
        difficultyValue.text = ((int)difficulty).ToString();
    }
    public void OnDifficultyValueChanged(float difficulty)
    {
        UpdateDifficulty(difficulty);
    }
    public void OnOKButton()
    {
        Close();
        optionsPopup.Open();
        PlayerPrefs.SetInt("difficulty", (int)slider.value);
    }

    public void OnCancelButton()
    {
        Close();
        optionsPopup.Open();
    }

    public void Open()
    {
        gameObject.SetActive(true);
        slider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(slider.value);
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
