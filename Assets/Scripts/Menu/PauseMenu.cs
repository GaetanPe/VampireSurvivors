using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsWindow;

    void Start()
    {
        settingsWindow.SetActive(false);
    }
    public void ButtonResume()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }

    public void ButtonSettings()
    {
        settingsWindow.SetActive(true);
    }

    public void ButtonMainMeu()
    {
        ButtonResume();
        SceneManager.LoadScene("MainMenuScene");

    }
}
