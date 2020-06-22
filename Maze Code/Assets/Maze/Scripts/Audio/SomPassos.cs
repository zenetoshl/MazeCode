using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomPassos : MonoBehaviour
{
    public AudioClip Passos;

    public AudioSource PassosSom;
    public static SomPassos current;
    void Start()
    {
        current = this;
        PassosSom = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayMusic()
    {
        PassosSom.Play();
    }
    public void StopMusic()
    {
        PassosSom.Stop();
    }
}