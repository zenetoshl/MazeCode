using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [Header ("Position Variables")]
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    private Vector2 maxPositionMap;
    private Vector2 minPositionMap;

    [Header ("Position Reset")]
    public VectorValue camMin;
    public VectorValue camMax;

    // Start is called before the first frame update
    void Start () {
        //maxPosition = camMax.initialValue;
        //minPosition = camMin.initialValue;
        float vertExtent = Camera.main.GetComponent<Camera> ().orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;
        Debug.Log (vertExtent);
        Debug.Log (horzExtent);

        minPositionMap.x = (minPosition.x + (horzExtent));
        maxPositionMap.x = (maxPosition.x - (horzExtent));
        minPositionMap.y = (minPosition.y + (vertExtent));
        maxPositionMap.y = (maxPosition.y - (vertExtent));


        Debug.Log (minPositionMap);
        Debug.Log (maxPositionMap);
        transform.position = new Vector3 (target.position.x, target.position.y, transform.position.z);
    }

    // Update is called once per frame
    void LateUpdate () {
        if (transform.position != target.position) {
            Vector3 targetPosition = new Vector3 (target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp (targetPosition.x, minPositionMap.x, maxPositionMap.x);
            targetPosition.y = Mathf.Clamp (targetPosition.y, minPositionMap.y, maxPositionMap.y);
            transform.position = Vector3.Lerp (transform.position, targetPosition, smoothing);
        }
    }
}