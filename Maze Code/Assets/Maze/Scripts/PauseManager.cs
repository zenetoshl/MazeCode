using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {
    private bool isPaused;
    private bool isInventory;

    public GameObject pausePanel;
    public GameObject inventoryPanel;
    public GameObject buttonMusic;
    public GameObject buttonSound;

    public SoundConfig soundConfig;
    public AudioSource somPassos;

    public string mainMenu;

    [Header("Music Button")]
    public Color musicON;
    public Color musicOFF;

    [Header("Sound Button")]
    public Color soundON;
    public Color soundOFF;

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
            buttonMusic.GetComponent<Image>().color = musicOFF;
            SomSala.current.StopMusic ();
        } else {
            buttonMusic.GetComponent<Image>().color = musicON;
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
            buttonSound.GetComponent<Image>().color = soundOFF;
            SomPassos.current.StopMusic ();
        } else {
            buttonSound.GetComponent<Image>().color = soundON;
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
            buttonMusic.GetComponent<Image>().color = musicOFF;
            SomSala.current.StopMusic ();
        } else {
            buttonMusic.GetComponent<Image>().color = musicON;
            SomSala.current.PlayMusic ();
        }
        if (sound) {
            buttonSound.GetComponent<Image>().color = soundOFF;
            somPassos.Stop ();
        } else {
            buttonSound.GetComponent<Image>().color = soundON;
            somPassos.Play ();
        }
    }
    public void QuitToMain () {
        SceneManager.LoadScene (mainMenu);
        Time.timeScale = 1f;
    }
}