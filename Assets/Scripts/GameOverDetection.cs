using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverDetection : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip gameOver;
    public void Setup()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
        audioSource.PlayOneShot(gameOver);
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void MenutButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }
}
