using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SoundConfigManager : MonoBehaviour
{
    public SoundConfig soundConfig;

    public void ResetConfig () {
        if (File.Exists (Application.persistentDataPath + "/config1.snd")) {
            File.Delete (Application.persistentDataPath + "/config1.snd");
        }
    }

    private void Awake () {
        if (!File.Exists (Application.persistentDataPath + "/config1.snd")) {
            CreateNewConfig ();
        }
        Debug.Log(Application.persistentDataPath + "/config1.snd");
    }

    public void CreateNewConfig () {
        FileStream file = File.Create (Application.persistentDataPath + "/config1.snd");
        BinaryFormatter binary = new BinaryFormatter ();
        var jsonConfig = JsonUtility.ToJson (soundConfig);
        binary.Serialize (file, jsonConfig);
        file.Close ();
        LoadConfig();
    }

    public void SaveConfig () {
        FileStream file = File.Create (Application.persistentDataPath + "/config1.snd");
        BinaryFormatter binary = new BinaryFormatter ();
        var jsonConfig = JsonUtility.ToJson (soundConfig);
        binary.Serialize (file, jsonConfig);
        file.Close ();
    }

    public void LoadConfig () {
        if (File.Exists (Application.persistentDataPath + "/config1.snd")) {
            FileStream file = File.Open (Application.persistentDataPath + "/config1.snd", FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter ();
            JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), soundConfig);
            file.Close ();
        }
    }
}
