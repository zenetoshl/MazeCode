using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;
    private bool isInventory;

    private int isMuteMusic = 0;
    private int isMuteSongs = 0;

    public GameObject pausePanel;
    public GameObject inventoryPanel;
    
    public string mainMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        isInventory = false;
        pausePanel.SetActive(false);
        inventoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void ChangeInventory()
    {
        isInventory = !isInventory;
        if (isInventory)
        {
            inventoryPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            inventoryPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void MuteMusic()
    {
        isMuteMusic ++;
        if(isMuteMusic %2 != 0)
        {
            SomSala.current.StopMusic();
        }
        else
        {
            SomSala.current.PlayMusic();
        }
        
    }
    public void MuteSongs()
    {
        isMuteSongs++;
        if (isMuteSongs % 2 != 0)
        {
            SomPassos.current.StopMusic();
            SomComputador.current.ComputadorSom.mute = true;
            SomPorta.current.PortaSom.mute = true;
            SomItem.current.ItemSom.mute = true;
        }
        else
        {
            SomPassos.current.PlayMusic();
            SomComputador.current.ComputadorSom.mute = false;
            SomPorta.current.PortaSom.mute = false;
            SomItem.current.ItemSom.mute = false;
        }

    }
    public void QuitToMain()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
}