using System.Collections;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenControl : MonoBehaviour
{
    public GameObject loadingScreenObj;
    public Slider slider;
    public int fakeSpeed;
    AsyncOperation async;
    public static bool loadLab = false;
    public GameObject cam = null;

    private void Update() {
        if(loadLab){
            loadLab = false;
            cam.SetActive(true);
            LoadScreenExample();
        }
    }

    public void LoadScreenExample()
    {
        StartCoroutine(LoadingScreen());
    }
    IEnumerator LoadingScreen()
    {
        loadingScreenObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            //slider.value += fakeSpeed * Time.deltaTime;
            slider.value = async.progress * 0.9f;
            if(async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    public void LoadNewGame(){
        SceneManager.LoadScene ("TypeWriter", LoadSceneMode.Additive);
        cam.SetActive(false);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("TypeWriter"));        
    }
}
