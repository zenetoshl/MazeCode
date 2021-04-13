using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveItem : MonoBehaviour
{
    [Header("Lista de todos os blocos visíveis no Labirinto")]
    public List<BoolValue> objects = new List<BoolValue>();


    public void SaveScriptables()
    {
        
            FileStream file = File.Create(Application.persistentDataPath + "/objcts.itm");
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(objects);
            binary.Serialize(file, json);
            file.Close();
        
    }

    public void LoadScriptables()
    { 
       
            if(File.Exists(Application.persistentDataPath + "/objcts.itm"))
            {
                FileStream file = File.Open(Application.persistentDataPath + "/objcts.itm", FileMode.Open);
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
            if(File.Exists(Application.persistentDataPath + "/objcts.itm"))
            {
                File.Delete(Application.persistentDataPath + "/objcts.itm");
            }
        }
        //Debug.Log("Reset Items OK");
    }
}