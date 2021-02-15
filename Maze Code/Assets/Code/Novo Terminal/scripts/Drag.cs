using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Lean.Gui;

public class Drag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private int holdFrameCount;
    public int minFrameCount = 30;
    private bool drag;
    private bool changed;
    private bool clicked = false;
    public ScaleAnimation scaleScript;
    public RectTransform destroyButton;

    void OnMouseDown()
    {
        Debug.Log(!EventSystem.current.IsPointerOverGameObject(Input.touchCount > 0 ? Input.touches[0].fingerId : -1));
        if(!EventSystem.current.IsPointerOverGameObject(Input.touchCount > 0 ? Input.touches[0].fingerId : -1)){
            scaleScript.ToNormalScale();
            scaleScript.SetScaling(true);
            clicked = true;
            ClickController.isClickingOnObject = true;
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }

    void OnMouseDrag()
    {
        if (drag)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }

    }
    private void OnMouseUpAsButton() {
        if(!drag && !EventSystem.current.IsPointerOverGameObject(Input.touchCount > 0 ? Input.touches[0].fingerId : -1)){
            this.transform.GetChild(0).GetComponent<TerminalBlocks>().TurnOn();
        }
    }

    private void OnMouseUp()
    {
        changed = false;
        holdFrameCount = 0;
        ClickController.isClickingOnObject = false;
        if(drag && destroyButton != null) DestroyButtonManager.UpdateActive(destroyButton);
        drag = false;
        clicked = false;
        scaleScript.SetScaling(false);
        scaleScript.ResetScaling();
    }

    private void Start()
    {
        holdFrameCount = 0;
        drag = false;
        changed = false;
    }

    private void OnMouseOver() {
        if (clicked)
        {
            if (!drag)
            {
                scaleScript.Scale();
                holdFrameCount++;
                if (!changed)
                {
                    changed = true;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (holdFrameCount > minFrameCount && changed)
        {
            drag = true;
            changed = false;
            scaleScript.SetScaling(false);
        }
    }

    public bool GetDrag(){
        return drag;
    }
}