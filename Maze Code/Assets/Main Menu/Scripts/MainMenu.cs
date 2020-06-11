using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string SceneToLoad;

    public void Continue()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
