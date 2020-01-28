using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{

    public GameObject connectionMaker;
    public ConnectionPoint.ConnectionDirection connectionDir = ConnectionPoint.ConnectionDirection.West;
    public bool isEmpty = true;
    private bool showAdd = false;
    public bool changed = true;
    public Sprite[] sprites = new Sprite[2];
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private int plusOrMinus()
    {
        return isEmpty ? 0 : 1;
    }

    private void OnMouseUp()
    {
        if (ConnectionMaker.isConnectionMode)
        {
            isEmpty = false;
            changed = true;
            ConnectionMaker cm = GameObject.Find("_ConnectionMaker(Clone)").GetComponent<ConnectionMaker>();
            cm.AddConnection(this.transform.parent.GetComponent<RectTransform>(), connectionDir);
        }
        else if (!ConnectionMaker.isConnectionMode)
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
    }
    // Start is called before the first frame update
    void Start()
    {
        changed = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        updateSprite();
    }

    // Update is called once per frame
    void Update()
    {
        //atualização de estado depois de um connection mode
        if (!ConnectionMaker.isConnectionMode && changed) 
        {
            if (!isEmpty)
            {
                changed = false;
                boxCollider.enabled = true;
                spriteRenderer.enabled = true;
            }
            else
            {
                changed = false;
                boxCollider.enabled = false;
                spriteRenderer.enabled = false;
            }
            updateSprite();
        }
        else if (ConnectionMaker.isConnectionMode && !changed)
        {
            if (!isEmpty || CheckConnectionsParent() || IsInChain())
            {
                changed = true;
                boxCollider.enabled = false;
                spriteRenderer.enabled = false;
            }
            else
            {
                changed = true;
                boxCollider.enabled = true;
                spriteRenderer.enabled = true;
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
        spriteRenderer.sprite = sprites[plusOrMinus()];
    }
}