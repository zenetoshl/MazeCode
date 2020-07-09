using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CodeToMaze : MonoBehaviour {
    [Header ("New Scene Variables")]
    public string sceneToLoad;

    [Header ("Transition Variables")]
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    [Header ("Puzzle Status")]
    public Puzzle puzzleStatus;

    [Header ("Incrementar Bonus")]
    public PlayerInventory inventory = null;

    public void Awake () {
        if (fadeInPanel != null) {
            GameObject panel = Instantiate (fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy (panel, 1);
        }
        puzzleStatus = StaticLoadPuzzle.puzzle;
    }

    public void ReturnToMaze () {
        if (CodeSender._completed) {
            // O jogador conseguiu realizar o desafio e destravar a porta
            puzzleStatus.runtimeValue = true;

            // Incrementar o invetário com o bonus do puzzle
            // "0 - Variaveis"        
            inventory.myInventory[0].numberHeld = inventory.myInventory[0].numberHeld + puzzleStatus.bonusVariavel;
            // "1 - Leitura"
            inventory.myInventory[1].numberHeld = inventory.myInventory[1].numberHeld + puzzleStatus.bonusLeitura;
            // "2 - Imprime"
            inventory.myInventory[2].numberHeld = inventory.myInventory[2].numberHeld + puzzleStatus.bonusImprime;
            // "3 - Matematica"
            inventory.myInventory[3].numberHeld = inventory.myInventory[3].numberHeld + puzzleStatus.bonusMatematica;
            // "4 - Condicional"
            inventory.myInventory[4].numberHeld = inventory.myInventory[4].numberHeld + puzzleStatus.bonusCondicional;
            // "5 - Loop For"
            inventory.myInventory[5].numberHeld = inventory.myInventory[5].numberHeld + puzzleStatus.bonusLoopDefinido;
            // "6 - Loop While"
            inventory.myInventory[6].numberHeld = inventory.myInventory[6].numberHeld + puzzleStatus.bonusLoopIndefinido;
            // "7 - Vetor"
            inventory.myInventory[7].numberHeld = inventory.myInventory[7].numberHeld + puzzleStatus.bonusVetor;
            // "8 - Matriz"
            inventory.myInventory[8].numberHeld = inventory.myInventory[8].numberHeld + puzzleStatus.bonusMatriz;

            TerminalInventoryManager.CalculateDiff();

        }

        StartCoroutine (FadeControl ());
    }

    public IEnumerator FadeControl () {
        if (fadeOutPanel != null) {
            Instantiate (fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds (fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync (sceneToLoad);
        while (!asyncOperation.isDone) {
            yield return null;
        }
    }
}