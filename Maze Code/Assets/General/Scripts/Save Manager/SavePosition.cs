﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SavePosition : MonoBehaviour
{
    [SerializeField] public VectorValue position;

    private void OnEnable()
    {
        LoadScriptables();
        Debug.Log("Load Position OK");
    }

    private void OnDisable()
    {
        SaveScriptables();
        Debug.Log("Save Position OK");
    }

    public void SaveScriptables()
    {
        //ResetScriptables();
        FileStream file = File.Create(Application.persistentDataPath + string.Format("/0.pos", position));
        BinaryFormatter binary = new BinaryFormatter();
        var json = JsonUtility.ToJson(position);
        binary.Serialize(file, json);
        file.Close();
    }

    public void LoadScriptables()
    {
        if (File.Exists(Application.persistentDataPath + string.Format("/0.pos", position)))
        {
            var temp = ScriptableObject.CreateInstance<VectorValue>();
            FileStream file = File.Open(Application.persistentDataPath + string.Format("/0.pos", position), FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter();
            JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), temp);
            file.Close();

            // Carregando posição
            position.initialValue.x = temp.defaultValue.x;
            position.initialValue.y = temp.defaultValue.y;
        }
    }

    public void ResetScriptables()
    {
        // Zera inventário
        position.defaultValue.x = 0;
        position.defaultValue.y = 3;
        // Exclui arquivos
        if(File.Exists(Application.persistentDataPath + string.Format("/0.pos", position)))
        {
            File.Delete(Application.persistentDataPath + string.Format("/0.pos", position));
        }
        //Debug.Log("Reset Position OK");
    }
}