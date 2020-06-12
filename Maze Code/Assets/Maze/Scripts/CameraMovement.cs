using System.Collections;
using System.Collections.Generic;
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
        maxPositionMap = camMax.initialValue;
        minPositionMap = camMin.initialValue;
        float vertExtent = Camera.main.GetComponent<Camera> ().orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;
        Debug.Log (vertExtent);
        Debug.Log (horzExtent);

        minPosition.x = (minPositionMap.x + (horzExtent));
        maxPosition.x = (maxPositionMap.x - (horzExtent));
        minPosition.y = (minPositionMap.y + (vertExtent));
        maxPosition.y = (maxPositionMap.y - (vertExtent));

        transform.position = new Vector3 (target.position.x, target.position.y, transform.position.z);
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
    void OnApplicationQuit()
    {
        //maxPosition.x = Current;
        //maxPosition.y = Current;
    }
}