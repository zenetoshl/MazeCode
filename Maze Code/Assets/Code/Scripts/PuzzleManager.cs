using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    public Puzzle puzzle;
    public CodeSender codeSender;
    public TextMeshProUGUI objective;
    public TextMeshProUGUI objectiveTitle;

    private void Awake() {
        Debug.Log(StaticLoadPuzzle.path);
        
    }

    private void Start() {
        puzzle = Resources.Load(StaticLoadPuzzle.path) as Puzzle;
        Debug.Log(puzzle.correctCode);
        codeSender.correctCode = puzzle.correctCode;
        codeSender.inputs = puzzle.inputs;
        objectiveTitle.text = "<size=30>" + puzzle.objectiveTitle + "</size>";
        objective.text = puzzle.objective;
        codeSender.puzzle = puzzle;
    }

}
