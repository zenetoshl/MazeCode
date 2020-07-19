using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalSoundManager : MonoBehaviour
{

    public SoundConfig soundConfig;
    public AudioSource music;

    private void Start() {
        if(soundConfig.music){
            StopMusic();
        }
    }

    public void PlayMusic()
    {
        music.Play();
    }
    public void StopMusic()
    {
        music.Stop();
    }
}
