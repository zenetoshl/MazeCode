using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SoundConfigManager : MonoBehaviour
{
    public SoundConfig soundConfig;

    public void ResetConfig () {
        if (File.Exists (Application.persistentDataPath + "/config.snd")) {
            File.Delete (Application.persistentDataPath + "/config.snd");
        }
    }

    private void Awake () {
        if (!File.Exists (Application.persistentDataPath + "/config.snd")) {
            CreateNewConfig ();
        }
        LoadConfig();
    }

    public void CreateNewConfig () {
        FileStream file = File.Create (Application.persistentDataPath + "/config.snd");
        BinaryFormatter binary = new BinaryFormatter ();
        var jsonConfig = JsonUtility.ToJson (soundConfig);
        binary.Serialize (file, jsonConfig);
        file.Close ();
        LoadConfig();
    }

    public void SaveConfig () {
        FileStream file = File.Create (Application.persistentDataPath + "/config.snd");
        BinaryFormatter binary = new BinaryFormatter ();
        var jsonConfig = JsonUtility.ToJson (soundConfig);
        binary.Serialize (file, jsonConfig);
        file.Close ();
    }

    public void LoadConfig () {
        if (File.Exists (Application.persistentDataPath + "/config.snd")) {
            FileStream file = File.Open (Application.persistentDataPath + "/config.snd", FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter ();
            JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), soundConfig);
            file.Close ();
        }
    }

    private void OnDisable () {
        SaveConfig ();
    }

    private void OnEnable () {
        LoadConfig ();
    }

    private void OnApplicationQuit () {
        SaveConfig ();
    }
}
