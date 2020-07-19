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
        StartCoroutine (LoadAndAnimate (sceneName));

    }

    public void StartAnimationAndLoadAsync (string sceneName) {

        StartCoroutine (LoadAndAnimateAsync (sceneName));

    }

    private IEnumerator LoadAndAnimate (string sceneName) {
        animator.SetTrigger ("Start");

        yield return new WaitForSeconds (duration);

        SceneManager.LoadScene (sceneName);
    }

    private IEnumerator LoadAndAnimateAsync (string sceneName) {
        animator.SetTrigger ("Start");

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync (sceneName);

        yield return new WaitForSeconds (duration);
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}