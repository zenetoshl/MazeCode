using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeAnimation : MonoBehaviour {
    public Animator animator;
    public float duration;

    public static FadeAnimation current = null;

    private void Start () {
        current = this;
    }

    public void StartAnimationAndLoad (string sceneName) {
        LoadAndAnimate (sceneName);

    }

    public void StartAnimationAndLoadAsync (string sceneName) {
        LoadAndAnimateAsync (sceneName);

    }

    private void LoadAndAnimate (string sceneName) {
        ContainerManager.isActive = false;
        ContainerManager.changed = true; 
        SceneManager.LoadScene (sceneName, LoadSceneMode.Additive);
    }

    private void LoadAndAnimateAsync (string sceneName) {
        ContainerManager.isActive = true;
        ContainerManager.changed = true;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        SceneManager.UnloadSceneAsync ("terminal3", UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
    }
}