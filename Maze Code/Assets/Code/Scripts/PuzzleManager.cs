using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour {
    public Puzzle puzzle;
    public CodeSender codeSender;
    public GameObject audioManager;
    public AudioClip salasVerdes;
    public AudioClip salasAmarelas;
    public AudioClip salasLaranjas;
    public AudioClip salasVermelhas;

    public Text objectiveTitle;
    public Text objective;

    private void Start () {
        puzzle = StaticLoadPuzzle.puzzle;
        codeSender.correctCode = puzzle.correctCode;
        codeSender.inputs = puzzle.inputs;
        codeSender.puzzle = puzzle;
        objectiveTitle.text = puzzle.objectiveTitle;
        objective.text = puzzle.objective;

        if (puzzle.naSala == 0 || puzzle.naSala == 1 || puzzle.naSala == 2 || puzzle.naSala == 3 || puzzle.naSala == 4)
        {
            Debug.Log("SALAS VERDES");
            audioManager.GetComponent<AudioSource>().clip = salasVerdes;
        }
        else if (puzzle.naSala == 5 || puzzle.naSala == 8 || puzzle.naSala == 12 || puzzle.naSala == 16 || puzzle.naSala == 20)
        {
            Debug.Log("SALAS AMARELAS");
            audioManager.GetComponent<AudioSource>().clip = salasAmarelas;
        }
        else if (puzzle.naSala == 6 || puzzle.naSala == 7 || puzzle.naSala == 09 || puzzle.naSala == 17 ||
                puzzle.naSala == 22 || puzzle.naSala == 23 || puzzle.naSala == 24 || puzzle.naSala == 25)
        {
            Debug.Log("SALAS LARANJAS");
            audioManager.GetComponent<AudioSource>().clip = salasLaranjas;
        }
        else if (puzzle.naSala == 10 || puzzle.naSala == 11 || puzzle.naSala == 13 || puzzle.naSala == 14 ||
                puzzle.naSala == 15 || puzzle.naSala == 18 || puzzle.naSala == 19 || puzzle.naSala == 21)
        {
            Debug.Log("SALAS VERMELHAS");
            audioManager.GetComponent<AudioSource>().clip = salasVermelhas;
        }

    }

}