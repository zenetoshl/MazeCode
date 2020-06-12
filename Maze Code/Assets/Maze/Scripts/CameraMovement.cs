using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [Header ("Position Variables")]
    public Transform target;
    public float smoothing;
    public Vector2 maxPositionMap;
    public Vector2 minPositionMap;

    public Vector2 maxPosition;
    public Vector2 minPosition;

    [Header ("Position Reset")]
    public VectorValue camMin;
    public VectorValue camMax;

    // Start is called before the first frame update
    void Start () {

        LoadLimits ();
        CalculateLimits ();

        transform.position = new Vector3 (target.position.x, target.position.y, transform.position.z);
    }

    void CalculateLimits () {
        float vertExtent = Camera.main.GetComponent<Camera> ().orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;
        minPosition.x = (minPositionMap.x + (horzExtent));
        maxPosition.x = (maxPositionMap.x - (horzExtent));
        minPosition.y = (minPositionMap.y + (vertExtent));
        maxPosition.y = (maxPositionMap.y - (vertExtent));
    }

    // Update is called once per frame
    void LateUpdate () {
        if (transform.position != target.position) {
            Vector3 targetPosition = new Vector3 (target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp (targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp (targetPosition.y, minPosition.y, maxPosition.y);
            transform.position = Vector3.Lerp (transform.position, targetPosition, smoothing);
        }
    }

    public void SaveLimits () {
        FileStream fileMax = File.Create (Application.persistentDataPath + "/max.cam");
        FileStream fileMin = File.Create (Application.persistentDataPath + "/min.cam");
        BinaryFormatter binary = new BinaryFormatter ();
        var jsonMax = JsonUtility.ToJson (maxPositionMap);
        var jsonMin = JsonUtility.ToJson (minPositionMap);
        binary.Serialize (fileMax, jsonMax);
        binary.Serialize (fileMin, jsonMin);
        fileMax.Close ();
        fileMin.Close ();

    }

    public void LoadLimits () {
        if (File.Exists (Application.persistentDataPath + "/min.cam")) {
            FileStream file = File.Open (Application.persistentDataPath + "/min.cam", FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter ();
            minPositionMap = JsonUtility.FromJson<Vector2> ((string) binary.Deserialize (file));
            file.Close ();
        }
        if (File.Exists (Application.persistentDataPath + "/max.cam")) {
            FileStream file = File.Open (Application.persistentDataPath + "/max.cam", FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter ();
            maxPositionMap = JsonUtility.FromJson<Vector2> ((string) binary.Deserialize (file));
            file.Close ();
        }

    }

    private void OnDisable () {
        SaveLimits ();
    }

    private void OnEnable () {
        LoadLimits ();
        CalculateLimits ();
    }
}