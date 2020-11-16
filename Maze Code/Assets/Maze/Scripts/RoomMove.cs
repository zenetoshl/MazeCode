using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour {
    public Vector2 cameraChange;
    public Vector3 playerChange;
    public bool needText;
    public string placeName;
    public Text placeText;
    private bool init;
    public Puzzle puzzleStatus;
    public BoxCollider2D roomTransfer;

    private CameraMovement cam;

    private void Awake() {
        
    }

    // Start is called before the first frame update
    void Start () {
        roomTransfer = GetComponent<BoxCollider2D> ();
        cam = Camera.main.GetComponent<CameraMovement> ();
        init = true;
    }

    void Update () {
        roomTransfer.isTrigger = puzzleStatus.runtimeValue;
        if (init) {
            init = false;
        }
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("Player") && !init) {
            SomPorta.current.PlayMusic ();
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            cam.minPositionMap.initialValue += cameraChange;
            cam.maxPositionMap.initialValue += cameraChange;
            other.transform.position += playerChange;

            if (needText) {
                StartCoroutine (placeNameCo ());
            }
        }
    }

    private IEnumerator placeNameCo () {
        placeText.gameObject.SetActive (true);
        placeText.text = placeName;
        yield return new WaitForSeconds (3f);
        placeText.gameObject.SetActive (false);
    }
}