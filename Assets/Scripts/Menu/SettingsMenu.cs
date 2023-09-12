using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] GameObject settingsWindow;
    [SerializeField] TMP_Dropdown dropdown;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        dropdown.ClearOptions();
        
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " X " + resolutions[i].height;
            options.Add(option);
        }
        dropdown.AddOptions(options);
    }

    public void CloseWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        Debug.Log(isFullScreen);
    }

    public void SetMusic(float music)
    {
        audioMixer.SetFloat("Music", music);
    }

    public void SetSound(float sound)
    {
        audioMixer.SetFloat("Sound", sound);
    }
}
