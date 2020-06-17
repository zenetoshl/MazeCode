using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [Header ("Position Variables")]
    public Transform target;
    public float smoothing;
    public VectorValue maxPositionMap;
    public VectorValue minPositionMap;

    public Vector2 maxPosition;
    public Vector2 minPosition;

    // Start is called before the first frame update
    void Start () {

        CalculateLimits ();

        Debug.Log(minPositionMap.initialValue);
        Debug.Log(maxPositionMap.initialValue);

        transform.position = new Vector3 (target.position.x, target.position.y, transform.position.z);
    }

    void CalculateLimits () {
        float vertExtent = Camera.main.GetComponent<Camera> ().orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;
        minPosition.x = (minPositionMap.initialValue.x + (horzExtent));
        maxPosition.x = (maxPositionMap.initialValue.x - (horzExtent));
        minPosition.y = (minPositionMap.initialValue.y + (vertExtent));
        maxPosition.y = (maxPositionMap.initialValue.y - (vertExtent));
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
}