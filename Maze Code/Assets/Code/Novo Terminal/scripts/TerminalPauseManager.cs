using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TerminalPauseManager : MonoBehaviour {
    private bool isPaused;
    public GameObject buttonMusic;
    public GameObject buttonSound;

    private List<Lean.Transition.Method.LeanPlaySound> clickSounds;

    public SoundConfig soundConfig;
    public AudioSource musicSound;

    public string mainMenu;

    [Header ("Music Button")]
    public Color musicON;
    public Color musicOFF;

    [Header ("Sound Button")]
    public Color soundON;
    public Color soundOFF;

    // Start is called before the first frame update
    void Start () {
        clickSounds = new List<Lean.Transition.Method.LeanPlaySound> ();
        isPaused = false;
        FindClickTransitions ();
        LoadSound ();

    }

    private void FindClickTransitions () {
        foreach (GameObject click in GameObject.FindGameObjectsWithTag ("clickSoundPlayer")) {
            Lean.Transition.Method.LeanPlaySound obj = click.transform.GetComponent<Lean.Transition.Method.LeanPlaySound> ();
            clickSounds.Add (obj);
        }
    }

    private void muteClickSounds (bool b) {
        foreach (Lean.Transition.Method.LeanPlaySound item in clickSounds) {
            item.Data.Volume = b ? 1 : 0;
        }
    }

    public void MuteMusic () {
        soundConfig.music = !soundConfig.music;
        if (soundConfig.music) {
            buttonMusic.GetComponent<Image> ().color = musicOFF;
            musicSound.Stop ();
        } else {
            buttonMusic.GetComponent<Image> ().color = musicON;
            musicSound.Play ();
        }

    }
    public void MuteSongs () {
        soundConfig.sound = !soundConfig.sound;
        bool sound = soundConfig.sound;
        if (sound) {
            buttonSound.GetComponent<Image> ().color = soundOFF;
            muteClickSounds (false);

        } else {
            buttonSound.GetComponent<Image> ().color = soundON;
            muteClickSounds (true);
        }
    }

    public void LoadSound () {
        bool sound = soundConfig.sound;
        if (soundConfig.music) {
            buttonMusic.GetComponent<Image> ().color = musicOFF;
            musicSound.Stop ();
        } else {
            buttonMusic.GetComponent<Image> ().color = musicON;
            musicSound.Play ();
        }
        if (sound) {
            buttonSound.GetComponent<Image> ().color = soundOFF;
            muteClickSounds (false);
        } else {
            buttonSound.GetComponent<Image> ().color = soundON;
            muteClickSounds (true);
        }
    }
    public void QuitToMain () {
        SceneManager.LoadScene (mainMenu);
        Time.timeScale = 1f;
    }
}