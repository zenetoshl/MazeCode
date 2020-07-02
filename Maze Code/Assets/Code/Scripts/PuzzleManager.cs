using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour {
    public Puzzle puzzle;
    public CodeSender codeSender;
    
    public Text objectiveTitle;
    public Text objective;

    private void Start () {
        puzzle = StaticLoadPuzzle.puzzle;
        Debug.Log (puzzle.correctCode);
        codeSender.correctCode = puzzle.correctCode;
        codeSender.inputs = puzzle.inputs;
        codeSender.puzzle = puzzle;
        
        objectiveTitle.text = puzzle.objectiveTitle;
        objective.text = puzzle.objective;
        
    }

}