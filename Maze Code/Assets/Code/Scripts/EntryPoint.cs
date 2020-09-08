using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EntryPoint : MonoBehaviour
{

    public GameObject connectionMaker;
    public ConnectionPoint.ConnectionDirection connectionDir = ConnectionPoint.ConnectionDirection.West;
    public bool isEmpty = true;
    private bool showAdd = false;
    public bool changed = true;
    public Color[] sprites = new Color[2];
    private Image image;
    private BoxCollider2D collider;

    private int plusOrMinus()
    {
        return isEmpty ? 0 : 1;
    }

    private void CancelConnection()
    {
        GameObject gObj = ConnectionManager.GetOtherSide(this.transform.parent.GetComponent<RectTransform>(), connectionDir);
        if (gObj != null)
        {
            NewConnection nc = gObj.GetComponent<NewConnection>();
            if (ConnectionManager.DeleteThisConnection(this.transform.parent.GetComponent<RectTransform>(), connectionDir))
            {
                isEmpty = true;
                changed = true;
                nc.isEmpty = true;
                nc.changed = true;
                //Debug.Log("sucesso");
            }
            else
            {
                //Debug.Log("sem sucesso");
            }
        }
    }

    public void OnMouseUp()
    {
        if (!ConnectionManager.isConnectionMode && !EventSystem.current.IsPointerOverGameObject())
        {
            CancelConnection();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        changed = true;
        image = GetComponent<Image>();
        collider = GetComponent<BoxCollider2D>();
        updateSprite();
    }

    private void OnDestroy()
    {
        if (!isEmpty)
        {
            CancelConnection();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //atualização de estado depois de um connection mode
        if (!ConnectionManager.isConnectionMode && changed)
        {
            if (!isEmpty)
            {
                changed = false;
                collider.enabled = true;
                image.enabled = true;
            }
            else
            {
                changed = false;
                collider.enabled = false;
                image.enabled = false;
            }
            updateSprite();
        }
        else if (ConnectionManager.isConnectionMode && !changed)
        {
            if (!isEmpty || CheckConnectionsParent() || IsInChain())
            {
                changed = true;
                collider.enabled = false;
                image.enabled = false;
            }
            else
            {
                changed = true;
                collider.enabled = true;
                image.enabled = true;
            }
            updateSprite();
        }
    }
    private bool IsInChain()
    {
        return ConnectionManager.IsInChain(this.transform.parent.GetComponent<RectTransform>(), ConnectionMaker.connectionPos[0]);
    }

    private bool CheckConnectionsParent()
    {
        return ConnectionMaker.connectionPos[0].transform == this.transform.parent;
    }

    private void updateSprite()
    {
        image.color = sprites[plusOrMinus()];
    }
}