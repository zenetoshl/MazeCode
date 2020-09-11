using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleManager : MonoBehaviour {
    public Puzzle puzzle;
    public CodeSender codeSender;
    
    public Text objectiveTitle;
    public TextMeshProUGUI objective;

    private void Start () {
        puzzle = StaticLoadPuzzle.puzzle;
        codeSender.correctCode = puzzle.correctCode;
        codeSender.inputs = puzzle.inputs;
        codeSender.puzzle = puzzle;
        
        objectiveTitle.text = puzzle.objectiveTitle;
        objective.text = puzzle.objective;
        
    }

}