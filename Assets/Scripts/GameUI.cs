using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject pauseWindow;

    private void Start()
    {
        pauseWindow.SetActive(false);
    }

    public void ButtonPause()
    {
        pauseWindow.SetActive(true);
        Time.timeScale = 0;
    }
}
