using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomPorta : MonoBehaviour
{
    public AudioClip Porta;

    public AudioSource PortaSom;
    public static SomPorta current;
    void Start()
    {
        current = this;
        PortaSom = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayMusic()
    {
        PortaSom.Play();
    }
    public void StopMusic()
    {
        PortaSom.Stop();
    }
}