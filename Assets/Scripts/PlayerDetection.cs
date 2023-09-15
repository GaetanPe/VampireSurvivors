using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    public GameObject canvas;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip victory;
    [SerializeField] ScoreSystem scoreSystem;
    [SerializeField] TextMeshProUGUI finalScore;

    void Start()
    {
        canvas.SetActive(false);    
    }

    private void OnTriggerEnter(Collider character){
        if (character.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            canvas.SetActive(true);
            audioSource.PlayOneShot(victory);
            finalScore.text = "Score: " + scoreSystem.currentScore;
        }
    }

    public void MenutButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }

    private void OnTriggerExit(Collider character)
    {
        if (character.gameObject.CompareTag("Player"))
        {
            canvas.SetActive(false);
        }
    }
}
