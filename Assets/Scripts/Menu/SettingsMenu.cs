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

    public void CloseWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
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
