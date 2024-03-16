using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SettingsPopUp : BasePopUp
{
    [SerializeField] private OptionsPopUp optionsPopup;
    [SerializeField] private TextMeshProUGUI difficultyValue;
    [SerializeField] private Slider slider;


    // Start is called before the first frame update
    void Start()
    {
       
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
        base.Close();
        base.Open();
        PlayerPrefs.SetInt("difficulty", (int)slider.value);
        Messenger<int>.Broadcast(GameEvent.DIFFICULTY_CHANGED, (int)slider.value);
    }

    public void OnCancelButton()
    {
        base.Close();
        //optionsPopup.Open();
        base.Open();
    }

    override public void Open()
    {
        gameObject.SetActive(true);
        slider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(slider.value);

    }
}
