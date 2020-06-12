using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;

    public bool isOpen;
    public Puzzle puzzleStatus;
    public BoxCollider2D roomTransfer;

    private CameraMovement cam;

    // Start is called before the first frame update
    void Start()
    {
        roomTransfer = GetComponent<BoxCollider2D>();
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    void Update()
    {
        isOpen = puzzleStatus.runtimeValue;
        roomTransfer.isTrigger = isOpen;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SomPorta.current.PlayMusic();
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            cam.minPositionMap += cameraChange;
            cam.maxPositionMap += cameraChange;
            other.transform.position += playerChange;

            if(needText)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }

    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }
}
