using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour {
    private Vector3 ResetCamera;
    private Vector3 Origin;
    private Vector3 Diference;
    private bool Drag = false;

    public float outerLeft = -10f;
    public float outerRight = 10f;
    public float outerUp = 10f;
    public float outerDown = -10f;
    void Start () {
        ResetCamera = Camera.main.transform.position;
    }
    void LateUpdate () {
        if (!ClickController.isClickingOnObject || !EventSystem.current.IsPointerOverGameObject()) {
            if (Input.GetMouseButton (0)) {
                Diference = (Camera.main.ScreenToWorldPoint (Input.mousePosition)) - Camera.main.transform.position;
                if (Drag == false) {
                    Drag = true;
                    Origin = Camera.main.ScreenToWorldPoint (Input.mousePosition);
                }
            } else {
                Drag = false;
            }
            Vector3 newPos = Origin - Diference;

            if (Drag == true) {
                Camera.main.transform.position = new Vector3 (
                    Mathf.Clamp (newPos.x, outerLeft, outerRight),
                    Mathf.Clamp (newPos.y, outerDown, outerUp), -10);
                /*
                if (Diference.x > 0) {
                    if (Diference.y > 0) {
                        if (this.transform.position.x < outerRight && this.transform.position.y < outerUp) {
                            Camera.main.transform.position = Origin - Diference;
                        }
                    } else {
                         if (this.transform.position.x < outerRight && this.transform.position.y > outerDown) {
                            Camera.main.transform.position = Origin - Diference;
                        }
                    }
                } else {
                     if (Diference.y > 0) {
                        if (this.transform.position.x > outerLeft && this.transform.position.y < outerUp) {
                            Camera.main.transform.position = Origin - Diference;
                        }
                    } else {
                         if (this.transform.position.x > outerLeft && this.transform.position.y > outerDown) {
                            Camera.main.transform.position = Origin - Diference;
                        }
                    }
                }
                */

            }
            //RESET CAMERA TO STARTING POSITION WITH RIGHT CLICK
            if (Input.GetMouseButton (1)) {
                Camera.main.transform.position = ResetCamera;
            }
        }
    }
}