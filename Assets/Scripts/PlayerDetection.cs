using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public GameObject canvas;

    private void OnTriggerEnter(Collider character){
        if (character.gameObject.CompareTag("Player"))
        { 
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider character)
    {
        if (character.gameObject.CompareTag("Player"))
        {
            canvas.SetActive(false);
        }
    }
}
