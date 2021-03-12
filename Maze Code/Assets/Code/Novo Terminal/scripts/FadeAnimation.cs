using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeAnimation : MonoBehaviour {
    public Animator animator;
    public float duration;

    static FadeAnimation _instance;
    public static FadeAnimation current {
        get {
            if (!_instance) {
                //first try to find one in the scene
                _instance = FindObjectOfType<FadeAnimation> ();

                if (!_instance) {
                    //if that fails, make a new one
                    GameObject go = new GameObject ("FadeAnimation");
                    _instance = go.AddComponent<FadeAnimation> ();

                    if (!_instance) {
                        //if that still fails, we have a big problem;
                        Debug.LogError ("Fatal Error: could not create FadeAnimation");
                    }
                }
            }

            return _instance;
        }
    }
    private void Start () {
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