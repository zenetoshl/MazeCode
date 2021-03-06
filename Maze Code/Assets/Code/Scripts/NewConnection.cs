﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewConnection : MonoBehaviour
{
    public Transform prefab;
    private Transform spawn;
    public GameObject connectionMaker;

    private bool wasPressed = false;
    public ConnectionPoint.ConnectionDirection connectionDir;
    public bool isEmpty = true;
    public bool changed = false;
    public Color[] sprites = new Color[2];
    private Image image;
    private CircleCollider2D collider;
    public Text xButton = null;

    private int NewOrRemove()
    {
        return isEmpty ? 0 : 1;
    }

    private void CancelConnection()
    {
        GameObject gObj = ConnectionManager.GetOtherSide(this.transform.parent.GetComponent<RectTransform>(), connectionDir);
        if (gObj != null)
        {
            EntryPoint ep = gObj.GetComponent<EntryPoint>();
            if (ep != null) if( ConnectionManager.DeleteThisConnection(this.transform.parent.GetComponent<RectTransform>(), connectionDir))
            {
                isEmpty = true;
                changed = true;
                ep.isEmpty = true;
                ep.changed = true;
            }
            else
            {
                Debug.Log("ERROR");
            }
        }
    }


    public void OnMouseUpAsButton()
    {
        if (!ConnectionManager.isConnectionMode && !isEmpty && !EventSystem.current.IsPointerOverGameObject())
        {
            CancelConnection();
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        image = GetComponent<Image>();
        collider = GetComponent<CircleCollider2D>();
        updateSprite();
    }

    private void OnDestroy()
    {
        if (!isEmpty)
        {
            CancelConnection();
        }
    }
    
    private void OnMouseEnter() {
        if(!isEmpty){
            xButton.enabled = true;
        }
    }

    private void OnMouseExit() {
        xButton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ConnectionManager.isConnectionMode)
        {
            wasPressed = false;
        } else if (!changed)
        {
            if (wasPressed)
            {
                changed = true;
                collider.enabled = true;
                image.enabled = true;
            }
            else
            {
                changed = true;
                collider.enabled = false;
                image.enabled = false;
            }
            updateSprite();
        } else 
        {
            if (connectionDir == ConnectionPoint.ConnectionDirection.South || connectionDir == ConnectionPoint.ConnectionDirection.East)
            {
                collider.enabled = true;
                changed = false;
                image.enabled = true;
            }
            else
            {
                changed = false;
                collider.enabled = true;
                image.enabled = true;
            }

            updateSprite();
        }
    }

    private void updateSprite()
    {
        image.color = sprites[NewOrRemove()];
    }

    private bool FindUpperConnection()
    {
        NewConnection[] conns = this.transform.parent.GetComponentsInChildren<NewConnection>();
        foreach (NewConnection c in conns)
        {
            if (c.connectionDir == ConnectionPoint.ConnectionDirection.North && c.isEmpty)
            {
                return true;
            }
        }
        return false;
    }


    //parte do drag and drop
    private void LateUpdate() {
        if (Input.GetMouseButton(0) && spawn != null)
        {
            var pos = Input.mousePosition;
            pos.z = -Camera.main.transform.position.z;
            spawn.transform.position = Camera.main.ScreenToWorldPoint(pos);
        }

        if (Input.GetMouseButtonUp(0) && spawn != null)
        {
            spawn.transform.GetComponent<linker>().isDeselected = true;
            ClickController.isClickingOnObject = false;
            spawn = null;
        }
    }

    private void OnMouseDown() {
        if(isEmpty){
            isEmpty = false;
            wasPressed = true;
            var pos = Input.mousePosition;
            pos.z = -Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);
            spawn = Instantiate(prefab, pos, Quaternion.identity) as Transform;
            GameObject go = Instantiate(connectionMaker) as GameObject;
            TerminalConnectionManager connectionM = go.GetComponent<TerminalConnectionManager>();
            connectionM.AddConnection(this.transform.parent.GetComponent<RectTransform>(), connectionDir);
            connectionM.AddConnection(spawn.GetComponent<RectTransform>(), ConnectionPoint.ConnectionDirection.West);
        }
    }
}