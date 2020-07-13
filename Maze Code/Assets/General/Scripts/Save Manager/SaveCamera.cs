using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveCamera : MonoBehaviour {

    public VectorValue maxPositionMap;
    public VectorValue minPositionMap;
    public VectorValue resetMaxPosition;
    public VectorValue resetMinPosition;

    public void ResetLimits () {
        if (File.Exists (Application.persistentDataPath + "/min.cam")) {
            File.Delete (Application.persistentDataPath + "/min.cam");
        }
        if (File.Exists (Application.persistentDataPath + "/max.cam")) {
            File.Delete (Application.persistentDataPath + "/max.cam");
        }
    }

    private void Awake () {
        if (!File.Exists (Application.persistentDataPath + "/min.cam") || !File.Exists (Application.persistentDataPath + "/max.cam")) {
            CreateNewLimits ();
        }
    }

    public void CreateNewLimits () {
        FileStream fileMax = File.Create (Application.persistentDataPath + "/max.cam");
        FileStream fileMin = File.Create (Application.persistentDataPath + "/min.cam");
        BinaryFormatter binary = new BinaryFormatter ();
        var jsonMax = JsonUtility.ToJson (resetMaxPosition.initialValue /*new Vector2 (8.25f, 9.1f)*/ );
        var jsonMin = JsonUtility.ToJson (resetMinPosition.initialValue /*new Vector2 (-7.25f, -2.1f)*/ );
        binary.Serialize (fileMax, jsonMax);
        binary.Serialize (fileMin, jsonMin);
        fileMax.Close ();
        fileMin.Close ();
        LoadLimits();
    }

    public void SaveLimits () {
        FileStream fileMax = File.Create (Application.persistentDataPath + "/max.cam");
        FileStream fileMin = File.Create (Application.persistentDataPath + "/min.cam");
        BinaryFormatter binary = new BinaryFormatter ();
        var jsonMax = JsonUtility.ToJson (maxPositionMap.initialValue);
        var jsonMin = JsonUtility.ToJson (minPositionMap.initialValue);
        binary.Serialize (fileMax, jsonMax);
        binary.Serialize (fileMin, jsonMin);
        fileMax.Close ();
        fileMin.Close ();

    }

    public void LoadLimits () {
        if (File.Exists (Application.persistentDataPath + "/min.cam")) {
            FileStream file = File.Open (Application.persistentDataPath + "/min.cam", FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter ();
            minPositionMap.initialValue = JsonUtility.FromJson<Vector2> ((string) binary.Deserialize (file));
            file.Close ();
        }
        if (File.Exists (Application.persistentDataPath + "/max.cam")) {
            FileStream file = File.Open (Application.persistentDataPath + "/max.cam", FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter ();
            maxPositionMap.initialValue = JsonUtility.FromJson<Vector2> ((string) binary.Deserialize (file));
            file.Close ();
        }
    }
}