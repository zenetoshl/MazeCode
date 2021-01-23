using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TerminalEntryConnection : MonoBehaviour {
    public GameObject connectionMaker;
    public ConnectionPoint.ConnectionDirection connectionDir = ConnectionPoint.ConnectionDirection.West;
    public bool isEmpty = true;
    public bool changed = true;
    public Color[] sprites = new Color[2];
    private Image image;
    private BoxCollider2D collider;

    private int NewOrRemove () {
        return isEmpty ? 0 : 1;
    }

    private void CancelConnection () {
        GameObject gObj = ConnectionManager.GetOtherSide (this.transform.parent.GetComponent<RectTransform> (), connectionDir);
        if (gObj != null) {
            TerminalBlockConnection nc = gObj.GetComponent<TerminalBlockConnection> ();
            if (nc != null) {
                if (ConnectionManager.DeleteThisConnection (this.transform.parent.GetComponent<RectTransform> (), connectionDir)) {
                    isEmpty = true;
                    changed = true;
                    nc.isEmpty = true;
                    nc.changed = true;
                }
            }
        }
    }

    public void OnMouseUp () {

        if (!ConnectionManager.isConnectionMode && !isEmpty && !EventSystem.current.IsPointerOverGameObject ()) {
            CancelConnection ();
        }
    }
    // Start is called before the first frame update
    void Start () {
        changed = true;
        image = this.transform.GetComponent<Image> ();
        collider = GetComponent<BoxCollider2D> ();
        updateSprite ();
    }

    private void OnDestroy () {
        if (!isEmpty) {
            CancelConnection ();
        }
    }

    // Update is called once per frame
    void Update () {
        //atualização de estado depois de um connection mode
        if (!ConnectionManager.isConnectionMode) {
            if (changed) {
                changed = false;
                collider.enabled = !isEmpty;
                image.enabled = !isEmpty;
                updateSprite ();
            }
        } else if (!changed) {
            bool enable = (isEmpty && !CheckConnectionsParent () && !IsInChain ());
            Debug.Log (!CheckConnectionsParent ());
            changed = true;
            collider.enabled = enable;
            image.enabled = enable;
            updateSprite ();
        }
    }
    private bool IsInChain () {
        return ConnectionManager.IsInChain (this.transform.parent.GetComponent<RectTransform> (), TerminalConnectionManager.connectionPos[0]);
    }

    private bool CheckConnectionsParent () {
        return TerminalConnectionManager.connectionPos[0].transform == this.transform.parent;
    }

    private void updateSprite () {
        image.color = sprites[NewOrRemove ()];
    }
}