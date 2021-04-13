using System;
using System.Collections;
using Lean.Gui;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler {

    public Transform prefab;
    private Transform spawn;
    public UnityEvent onBlockCreated;

    private LeanButton button;
    private bool _isFingerOverUi = false;

    private void Start () {
        button = this.GetComponent<LeanButton> ();
    }

    void Update () {

        if (Application.platform == RuntimePlatform.Android && spawn != null &&  Input.touchCount > 0) {
            Touch t = Input.GetTouch (0);
            if (t.phase == TouchPhase.Began || t.phase == TouchPhase.Moved) {
                if (EventSystem.current.IsPointerOverGameObject (t.fingerId)) {
                    _isFingerOverUi = true;
                }else {
                    _isFingerOverUi = false;
                }
            } else if(t.phase == TouchPhase.Canceled || t.phase == TouchPhase.Ended){
                if (_isFingerOverUi) {
                    Destroy (spawn.gameObject);
                } else {
                    onBlockCreated.Invoke ();
                }
                Debug.Log(_isFingerOverUi);
                _isFingerOverUi = false;
                spawn = null;
            }
        } //pc
        else if (spawn != null && Input.GetMouseButtonUp (0)) {
            if (!EventSystem.current.IsPointerOverGameObject (-1)) {
                onBlockCreated.Invoke ();
            } else {
                Destroy (spawn.gameObject);
            }

            ClickController.isClickingOnObject = false;
            spawn = null;
        }

        if (spawn != null && Input.GetMouseButton (0)) {
            var pos = Input.mousePosition;
            pos.z = -Camera.main.transform.position.z;
            spawn.transform.position = Camera.main.ScreenToWorldPoint (pos);
        }

    }

    public void OnPointerDown (PointerEventData eventData) {
        if (button.interactable) {
            ClickController.isClickingOnObject = true;
            var pos = Input.mousePosition;
            pos.z = -Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint (pos);
            spawn = Instantiate (prefab, pos, Quaternion.identity) as Transform;
        }

    }
}