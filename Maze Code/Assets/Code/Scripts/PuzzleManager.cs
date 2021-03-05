using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour {
    public Puzzle puzzle;
    
    public Text objectiveTitle;
    public Text objective;

    private void Start () {
        //puzzle = StaticLoadPuzzle.puzzle;
        ValidationManager.instance.results = puzzle.tests;
        
        objectiveTitle.text = puzzle.objectiveTitle;
        objective.text = puzzle.objective;
    }

}