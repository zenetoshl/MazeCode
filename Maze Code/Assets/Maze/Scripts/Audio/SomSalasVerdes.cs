using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomSalasVerdes : MonoBehaviour
{
    public AudioClip SalaVerde;

    public AudioSource SalaVerdeSom;
    public static SomSalasVerdes current;
    // Start is called before the first frame update
    void Start()
    {
        current = this;
        SalaVerdeSom = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayMusic()
    {
        SalaVerdeSom.Play();
    }
    public void StopMusic()
    {
        SalaVerdeSom.Stop();
    }
}
