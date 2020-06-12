using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class CameraReset : MonoBehaviour {
    public void ResetLimits () {
        CreateNewLimits ();
    }

    public void CreateNewLimits () {
        FileStream fileMax = File.Create (Application.persistentDataPath + "/max.cam");
        FileStream fileMin = File.Create (Application.persistentDataPath + "/min.cam");
        BinaryFormatter binary = new BinaryFormatter ();
        var jsonMax = JsonUtility.ToJson (new Vector2 (8.25f, 9.1f));
        var jsonMin = JsonUtility.ToJson (new Vector2 (-7.25f, -2.1f));
        binary.Serialize (fileMax, jsonMax);
        binary.Serialize (fileMin, jsonMin);
        fileMax.Close ();
        fileMin.Close ();
    }
}