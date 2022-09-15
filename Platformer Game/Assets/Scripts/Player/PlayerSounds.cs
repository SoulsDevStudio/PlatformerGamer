using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{

    AudioSource audioSource;

    public AudioClip coinSFX;
    public AudioClip jumpSFX;
    public AudioClip hitSFX;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }

    public void PlaySFX(AudioClip sfx)
    {
        audioSource.PlayOneShot(sfx);
    }
}
