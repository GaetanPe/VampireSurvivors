using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] AudioClip[] playlist;
    private int musicIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            playNextSongs();
        }
    }
    void playNextSongs()
    {
        musicIndex += 1 % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

}

