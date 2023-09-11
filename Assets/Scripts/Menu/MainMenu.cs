using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenuScene");
    }

    public void Exit ()
    {
        Application.Quit();
    }
}
