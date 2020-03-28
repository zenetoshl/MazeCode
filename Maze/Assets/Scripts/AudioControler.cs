using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControler : MonoBehaviour
{
    public AudioClip SomPassos;

    private AudioSource audioSource;
    public static AudioControler current;
    void Start()
    {
        current = this;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusic(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
