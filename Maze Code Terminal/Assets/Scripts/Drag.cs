using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Lean.Gui;

public class Drag : MonoBehaviour
{
    private LeanWindow thisWindow;
    private Vector3 screenPoint;
    private Vector3 offset;
    private int holdFrameCount;
    public int minFrameCount = 30;
    private bool drag;
    private bool changed;

    void OnMouseDown()
    {
        ClickController.isClickingOnObject = true;
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
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

    private void OnMouseUp()
    {
        changed = false;
        holdFrameCount = 0;
        ClickController.isClickingOnObject = false;
        drag = false;
    }

    private void Start()
    {
        holdFrameCount = 0;
        drag = false;
        changed = false;
        thisWindow = this.GetComponentInChildren<LeanWindow>();
    }

    private void OnMouseOver() {
        if (Input.GetMouseButton(0))
        {
            if (!drag)
            {
                holdFrameCount++;
                if (!changed)
                {
                    changed = true;
                }
            }

        }
    }


    private void OnMouseUpAsButton()
    {
        if (!drag)
        {
            thisWindow.TurnOn();
        }
    }

    private void FixedUpdate()
    {
        if (holdFrameCount > minFrameCount && changed)
        {
            drag = true;
            changed = false;
        }
    }
}