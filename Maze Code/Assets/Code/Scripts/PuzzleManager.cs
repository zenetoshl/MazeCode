using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour {
    public Puzzle puzzle;
    public CodeSender codeSender;
    public Text objective;
    public Text objectiveTitle;

    private void Start () {
        puzzle = StaticLoadPuzzle.puzzle;
        Debug.Log (puzzle.correctCode);
        codeSender.correctCode = puzzle.correctCode;
        codeSender.inputs = puzzle.inputs;
        objectiveTitle.text = puzzle.objectiveTitle;
        objective.text = puzzle.objective;
        codeSender.puzzle = puzzle;
    }

}