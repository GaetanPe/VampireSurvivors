using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    public GameObject canvas;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip victory;

    private void OnTriggerEnter(Collider character){
        if (character.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            canvas.SetActive(true);
            audioSource.PlayOneShot(victory);
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
