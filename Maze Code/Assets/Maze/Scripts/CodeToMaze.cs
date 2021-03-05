using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CodeToMaze : MonoBehaviour {
    [Header ("New Scene Variables")]
    public string sceneToLoad;

    [Header ("Transition Variables")]
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;

    [Header ("Puzzle Status")]
    public Puzzle puzzleStatus;

    [Header ("Incrementar Bonus")]
    public PlayerInventory inventory = null;

    private FadeAnimation fade;
    public SavePuzzle savePuzzleManager;

    static CodeToMaze _instance;
    public static CodeToMaze instance {
        get {
            if (!_instance) {
                //first try to find one in the scene
                _instance = FindObjectOfType<CodeToMaze> ();

                if (!_instance) {
                    //if that fails, make a new one
                    GameObject go = new GameObject ("_VariablesManager");
                    _instance = go.AddComponent<CodeToMaze> ();

                    if (!_instance) {
                        //if that still fails, we have a big problem;
                        Debug.LogError ("Fatal Error: could not create CodeToMaze");
                    }
                }
            }

            return _instance;
        }
    }

    public void Awake () {
        if (fadeInPanel != null) {
            GameObject panel = Instantiate (fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy (panel, 1);
        }
        puzzleStatus = StaticLoadPuzzle.puzzle;
    }

    private void Start () {
        fade = FadeAnimation.current;
    }

    public void ReturnToMaze () {
        if (!puzzleStatus.runtimeValue) {
            //o puzzle ainda não havia sido completado
            TerminalInventoryManager.puzzleDone = puzzleStatus.destravaSala;
            TerminalInventoryManager.done = true;
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

            foreach (InventoryItem item in inventory.myInventory)
            {
                CalculateDiff (item);
            }            
        }
        fade.StartAnimationAndLoadAsync (sceneToLoad);
    }

    private void CalculateDiff (InventoryItem item) {

        switch (item.itemName) {
            case "variavel":
                item.numberHeld -= TerminalInventoryManager.varUsed;
                Debug.Log(TerminalInventoryManager.varUsed);
                break;
            case "vetor":
                item.numberHeld -= TerminalInventoryManager.vetUsed;
                break;
            case "matriz":
                item.numberHeld -= TerminalInventoryManager.matUsed;
                break;
            case "loopIndefinido":
                item.numberHeld -= TerminalInventoryManager.whileUsed;
                break;
            case "loopDefinido":
                item.numberHeld -= TerminalInventoryManager.forUsed;
                break;
            case "condicional":
                item.numberHeld -= TerminalInventoryManager.ifUsed;
                break;
            case "imprime":
                item.numberHeld -= TerminalInventoryManager.writeUsed;
                break;
            case "leitura":
                item.numberHeld -= TerminalInventoryManager.readUsed;
                break;
            case "matematica":
                item.numberHeld -= TerminalInventoryManager.mathUsed;
                break;
        }

    }

    public IEnumerator FadeControl () {
        if (fadeOutPanel != null) {
            Instantiate (fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds (0.5f);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync (sceneToLoad);
        while (!asyncOperation.isDone) {
            yield return null;
        }
    }

    public void SaveScriptables () {
        for (int i = 0; i < inventory.myInventory.Count; i++) {
            FileStream file = File.Create (Application.persistentDataPath + string.Format ("/{0}.inv", i));
            BinaryFormatter binary = new BinaryFormatter ();
            var json = JsonUtility.ToJson (inventory.myInventory[i]);
            binary.Serialize (file, json);
            file.Close ();
        }
    }
}