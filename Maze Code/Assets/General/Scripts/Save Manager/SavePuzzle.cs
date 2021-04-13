using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SavePuzzle : MonoBehaviour
{
    [Header("Lista de todos os Puzzles do jogo")]
    public List<Puzzle> objects = new List<Puzzle>();


    public void SaveScriptables()
    {
        for (int i = 0; i < objects.Count; i ++)
        {
            FileStream file = File.Create(Application.persistentDataPath + "/puzzles.pzl");
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(objects);
            binary.Serialize(file, json);
            file.Close();
        }
    }

    public void LoadScriptables()
    { 
        for(int i = 0; i < objects.Count; i ++)
        {
            if(TerminalInventoryManager.done){
                if(TerminalInventoryManager.puzzleDone == i + 1){
                    objects[i].runtimeValue = true;
                }
            }
        }
            if(File.Exists(Application.persistentDataPath + "/puzzles.pzl"))
            {
                FileStream file = File.Open(Application.persistentDataPath + "/puzzles.pzl", FileMode.Open);
                BinaryFormatter binary = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), objects);
                file.Close(); 
            }
    }

    public void ResetScriptables()
    {
        for(int i = 0; i < objects.Count; i ++)
        {
            // Retorna objetos ao estado inicial
            objects[i].runtimeValue = objects[i].initialValue;
            // Exclui arquivos
            
        }
        if(File.Exists(Application.persistentDataPath + "/puzzles.pzl"))
        {
            File.Delete(Application.persistentDataPath + "/puzzles.pzl");
        }
        //Debug.Log("Reset Puzzles OK");
    }
}