using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    protected JoyButtonInventory joybutton;

    private bool isPaused;
    public GameObject pausePanel;
    public GameObject inventoryPanel;
    public bool usingPausePanel; 
    public string mainMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        joybutton = FindObjectOfType<JoyButtonInventory>();
        
        isPaused = false;
        pausePanel.SetActive(false);
        inventoryPanel.SetActive(false);
        usingPausePanel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(joybutton.Pressed)
        {
            ChangePause();
        }
        
    }

    public void ChangePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            usingPausePanel = true;
        }
        else
        {
            inventoryPanel.SetActive(false);
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }

    public void SwitchPanels()
    {
        usingPausePanel = !usingPausePanel;
        if(usingPausePanel)
        {
            pausePanel.SetActive(true);
            inventoryPanel.SetActive(false);
        }
        else {
            pausePanel.SetActive(false);
            inventoryPanel.SetActive(true);
        }
    }
}