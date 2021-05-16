using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SavePuzzle : MonoBehaviour
{
    [Header("Lista de todos os Puzzles do jogo")]
    public List<Puzzle> objects = new List<Puzzle>();

    [System.Serializable]
    public class Puzzles{
        [SerializeField] public List<bool> savePuzzles = new List<bool> {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};

        public Puzzles (){
            savePuzzles = new List<bool> {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};
        }
    }
   public Puzzles puzzles = new Puzzles();
    public static bool loaded = false;

    public Puzzles SaveScriptables()
    {
        for (int i = 0; i < objects.Count; i++) {
            puzzles.savePuzzles[i] = objects[i].runtimeValue;
            Debug.Log("save " + puzzles.savePuzzles[i]);
        }
        return puzzles;
    }

    public void LoadScriptables(List<bool> _puzzles)
    { 
        puzzles.savePuzzles = _puzzles;
        for (int i = 0; i < objects.Count; i++) {
            objects[i].runtimeValue = puzzles.savePuzzles[i];
            Debug.Log("load " + puzzles.savePuzzles[i]);
        }
    }

    public Puzzles ResetScriptables()
    {
        return new Puzzles();
    }
}