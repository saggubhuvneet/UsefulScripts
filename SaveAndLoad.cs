using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// save data | load presteting data
/// </summary>
public class SaveAndLoad : MonoBehaviour
{
    [SerializeField] Slider SencitivityControl;
    [SerializeField] Slider VolumeControl;
    [SerializeField] Toggle AutoFire;
    [SerializeField] TMP_Dropdown noOfEnemy;

    private void Start()
    {
        InitialValues();

        SencitivityControl.onValueChanged.AddListener(SencitivityValueChanged);
        VolumeControl.onValueChanged.AddListener(VolumeValueChanged);
        AutoFire.onValueChanged.AddListener(AutoFireCheck);
        noOfEnemy.onValueChanged.AddListener(MaxEnemy);
    }

    /// <summary>
    /// if not changed set the initial values
    /// </summary>
    void InitialValues()
    {
        if (PlayerPrefs.HasKey("sensitity"))
            SencitivityControl.value = PlayerPrefs.GetFloat("sensitity");
        else
            PlayerPrefs.SetFloat("sensitity", SencitivityControl.value);

        if (PlayerPrefs.HasKey("volume"))
            VolumeControl.value = PlayerPrefs.GetFloat("volume");
        else
            PlayerPrefs.SetFloat("volume", VolumeControl.value);

        if (PlayerPrefs.HasKey("autofire"))
            AutoFire.isOn = PlayerPrefs.GetInt("autofire") == 1;

        if (PlayerPrefs.HasKey("maxenemy"))
            noOfEnemy.value = PlayerPrefs.GetInt("maxenemy");
        else
            PlayerPrefs.SetInt("maxenemy", noOfEnemy.value);
        

        PlayerPrefs.Save();
    }
    /// <summary>
    /// set sencitivity value
    /// </summary>
    public void SencitivityValueChanged(float value)
    {
        if (!PlayerPrefs.HasKey("sensitity"))
        {
            PlayerPrefs.SetFloat("sensitity", value);
        }
        else
        {
            PlayerPrefs.SetFloat("sensitity", value);
        }
        PlayerPrefs.Save();
    }


    /// <summary>
    /// set volumeValue
    /// </summary>
    public void VolumeValueChanged(float value)
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", value);
        }
        else
        {
            PlayerPrefs.SetFloat("volume", value);
        }
        PlayerPrefs.Save();
    }

  
    public void AutoFireCheck(bool autoFire)
    {
        if (!PlayerPrefs.HasKey("autofire"))
        {
            PlayerPrefs.SetInt("autofire", autoFire? 1:0);
        }
        else
        {
            PlayerPrefs.SetInt("autofire", autoFire ? 1:0);
        }
        PlayerPrefs.Save();
    }

    public void MaxEnemy(int n)
    {
       
        PlayerPrefs.SetInt("maxenemy", n);
        PlayerPrefs.Save();

    }
}
