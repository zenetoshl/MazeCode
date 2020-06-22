using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomItem : MonoBehaviour
{
    public AudioClip Item;

    public AudioSource ItemSom;
    public static SomItem current;
    void Start()
    {
        current = this;
        ItemSom = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayMusic()
    {
        ItemSom.Play();
    }
    public void StopMusic()
    {
        ItemSom.Stop();
    }
}