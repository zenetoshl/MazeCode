using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomComputador : MonoBehaviour
{
    public AudioClip Computador;

    public AudioSource ComputadorSom;
    public static SomComputador current;
    void Start()
    {
        current = this;
        ComputadorSom = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayMusic()
    {
        ComputadorSom.Play();
    }
    public void StopMusic()
    {
        ComputadorSom.Stop();
    }
}