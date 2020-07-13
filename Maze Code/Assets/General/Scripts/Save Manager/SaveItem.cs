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
        for (int i = 0; i < objects.Count; i ++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.itm", i));
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(objects[i]);
            binary.Serialize(file, json);
            file.Close();
        }
    }

    public void LoadScriptables()
    { 
        for(int i = 0; i < objects.Count; i ++)
        { 
            if(File.Exists(Application.persistentDataPath + string.Format("/{0}.itm", i)))
            {
                FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.itm", i), FileMode.Open);
                BinaryFormatter binary = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), objects[i]);
                file.Close();
            }
        }
    }

    public void ResetScriptables()
    {
        for(int i = 0; i < objects.Count; i ++)
        {
            // Retorna objetos ao estado inicial
            objects[i].runtimeValue = objects[i].initialValue;
            // Exclui arquivos
            if(File.Exists(Application.persistentDataPath + string.Format("/{0}.itm", i)))
            {
                File.Delete(Application.persistentDataPath + string.Format("/{0}.itm", i));
            }
        }
        //Debug.Log("Reset Items OK");
    }
}