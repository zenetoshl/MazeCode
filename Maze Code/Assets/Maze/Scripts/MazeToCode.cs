using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Scene Transition
public class MazeToCode : Interactable {
    public GameObject Jogador;
    public GameObject dialogBox;
    public Text dialogText;
    public string blockLimitDialog;
    public string puzzleCompletedDialog;
    public AudioClip musicaTerminal;

    protected JoyButtonAction joybutton;
    [Header ("New Scene Variables")]
    public string sceneToLoad;

    [Header ("Transition Variables")]
    //public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    [Header ("Puzzle requirements")]
    [SerializeField] private PlayerInventory inventory = null;
    [SerializeField] private Puzzle thisPuzzle = null;

    private FadeAnimation fade;

    public void Awake () {
        /*
        if(fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1); 
        }
        */
    }

    private void Start () {
        joybutton = FindObjectOfType<JoyButtonAction> ();
        fade = FadeAnimation.current;
        blockLimitDialog = "Blocos insuficientes para este desafio";
        puzzleCompletedDialog = "Desafio concluido";
    }

    public void Update () {
        if (joybutton.Pressed && playerInRange) {
            // Confere os requerimentos do desafio
            if (CheckPuzzleRequirements ()) {
                SomComputador.current.PlayMusic ();
                //Jogador.GetComponent<SavePosition>().SalvarLocalizacao();
                StaticLoadPuzzle.puzzle = thisPuzzle;
                joybutton.Pressed = false;
                fade.StartAnimationAndLoad (sceneToLoad);

                //StartCoroutine(FadeControl());
            }
        }
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

    // Método que compara inventário com os blocos que são necessários
    public bool CheckPuzzleRequirements () {
        bool qtdVariavel = false;
        bool qtdLeitura = false;
        bool qtdImprime = false;
        bool qtdMatematica = false;
        bool qtdCondicional = false;
        bool qtdLoopDefinido = false;
        bool qtdLoopIndefinido = false;
        bool qtdVetor = false;
        bool qtdMatriz = false;

        for (int i = 0; i < inventory.myInventory.Count; i++) {
            Debug.Log (inventory.myInventory[i].itemName);
            switch (inventory.myInventory[i].itemName) {
                case "variavel":
                    if (inventory.myInventory[i].numberHeld >= thisPuzzle.variavel)
                        qtdVariavel = true;
                    break;

                case "leitura":
                    if (inventory.myInventory[i].numberHeld >= thisPuzzle.leitura)
                        qtdLeitura = true;
                    break;

                case "imprime":
                    if (inventory.myInventory[i].numberHeld >= thisPuzzle.imprime)
                        qtdImprime = true;
                    break;

                case "matematica":
                    if (inventory.myInventory[i].numberHeld >= thisPuzzle.matematica)
                        qtdMatematica = true;
                    break;

                case "condicional":
                    if (inventory.myInventory[i].numberHeld >= thisPuzzle.condicional)
                        qtdCondicional = true;
                    break;

                case "loopDefinido":
                    if (inventory.myInventory[i].numberHeld >= thisPuzzle.loopDefinido)
                        qtdLoopDefinido = true;
                    break;

                case "loopIndefinido":
                    if (inventory.myInventory[i].numberHeld >= thisPuzzle.loopIndefinido)
                        qtdLoopIndefinido = true;
                    break;

                case "vetor":
                    if (inventory.myInventory[i].numberHeld >= thisPuzzle.vetor)
                        qtdVetor = true;
                    break;

                case "matriz":
                    if (inventory.myInventory[i].numberHeld >= thisPuzzle.matriz)
                        qtdMatriz = true;
                    break;
            }
        }

        if (qtdVariavel && qtdLeitura && qtdImprime && qtdMatematica && qtdCondicional && qtdLoopDefinido && qtdLoopIndefinido && qtdVetor && qtdMatriz && !thisPuzzle.runtimeValue) {
            //Debug.Log("O problema pode SIM ser resolvido");
            dialogBox.SetActive (false);
            return true;
        } else {
            dialogBox.SetActive (true);
            dialogText.text = (thisPuzzle.runtimeValue) ? puzzleCompletedDialog : blockLimitDialog;
            return false;
        }
    }

    private void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag ("Player") && !other.isTrigger) {
            context.Raise ();
            playerInRange = false;
            dialogBox.SetActive (false);
        }
    }
}