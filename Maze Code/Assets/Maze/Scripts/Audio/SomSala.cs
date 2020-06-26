using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomSala : MonoBehaviour
{
    public AudioClip Sala;

    public AudioSource SalaSom;
    public static SomSala current;
    void Start()
    {
        current = this;
        SalaSom = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayMusic()
    {
        SalaSom.Play();
    }
    public void StopMusic()
    {
        SalaSom.Stop();
    }
}