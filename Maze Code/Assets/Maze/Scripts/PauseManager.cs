using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {
    private bool isPaused;
    private bool isInventory;

    public GameObject pausePanel;
    public GameObject inventoryPanel;

    public SoundConfig soundConfig;
    public AudioSource somPassos;

    public string mainMenu;

    // Start is called before the first frame update
    void Start () {
        isPaused = false;
        isInventory = false;
        pausePanel.SetActive (false);
        inventoryPanel.SetActive (false);
        LoadSound();
    }

    // Update is called once per frame
    void Update () {

    }

    public void ChangePause () {
        isPaused = !isPaused;
        if (isPaused) {
            pausePanel.SetActive (true);
            Time.timeScale = 0f;
        } else {
            pausePanel.SetActive (false);
            Time.timeScale = 1f;
        }
    }

    public void ChangeInventory () {
        isInventory = !isInventory;
        if (isInventory) {
            inventoryPanel.SetActive (true);
            Time.timeScale = 0f;
        } else {
            inventoryPanel.SetActive (false);
            Time.timeScale = 1f;
        }
    }
    public void MuteMusic () {
        soundConfig.music = !soundConfig.music;
        SomSala.current.SalaSom.mute = soundConfig.music;
        if (soundConfig.music) {
            SomSala.current.StopMusic ();
        } else {
            SomSala.current.PlayMusic ();
        }

    }
    public void MuteSongs () {
        soundConfig.sound = !soundConfig.sound;
        bool sound = soundConfig.sound;
        SomComputador.current.ComputadorSom.mute = sound;
        SomPorta.current.PortaSom.mute = sound;
        SomItem.current.ItemSom.mute = sound;
        if (sound) {
            SomPassos.current.StopMusic ();
        } else {
            SomPassos.current.PlayMusic ();
        }
        SomPassos.current.PassosSom.mute = true;
    }

    public void LoadSound () {
        bool sound = soundConfig.sound;
        SomComputador.current.ComputadorSom.mute = sound;
        SomPorta.current.PortaSom.mute = sound;
        SomItem.current.ItemSom.mute = sound;

        SomSala.current.SalaSom.mute = soundConfig.music;


        if (soundConfig.music) {
            SomSala.current.StopMusic ();
        } else {
            SomSala.current.PlayMusic ();
        }
        if (sound) {
            somPassos.Stop ();
        } else {
            somPassos.Play ();
        }
    }
    public void QuitToMain () {
        SceneManager.LoadScene (mainMenu);
        Time.timeScale = 1f;
    }
}