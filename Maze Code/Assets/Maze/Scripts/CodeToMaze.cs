using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CodeToMaze : MonoBehaviour
{
    [Header("New Scene Variables")]
    public string sceneToLoad;

    [Header("Transition Variables")]
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    [Header("Puzzle Status")]
    public Puzzle puzzleStatus;

    public void Awake()
    {
        if(fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1); 
        }
    }
    
    public void ReturnToMaze()
    {
        // O jogador conseguiu realizar o desafio e destravar a porta
        //puzzleStatus.runtimeValue = true;

        // TODO: Incrementar o invetário com o bonus do puzzle

        StartCoroutine(FadeControl());
    }

    public IEnumerator FadeControl()
    {
        if(fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while(!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
