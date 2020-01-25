using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewConnection : MonoBehaviour
{

    public GameObject connectionMaker;

    private bool wasPressed = false;
    public ConnectionPoint.ConnectionDirection connectionDir = ConnectionPoint.ConnectionDirection.North;
    public bool isEmpty = true;
    public bool changed = false;
    public Sprite[] sprites = new Sprite[2];
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private int plusOrMinus()
    {
        return isEmpty ? 0 : 1;
    }

     private void CancelConnectionMode()
    {
        ConnectionMaker cm = GameObject.Find("_ConnectionMaker(Clone)").GetComponent<ConnectionMaker>();
        Destroy(cm.gameObject);
    }

    private void OnMouseUp()
    {
        if (wasPressed){
            isEmpty = true;
            CancelConnectionMode();
        }else if (!ConnectionMaker.isConnectionMode && isEmpty)
        {
            isEmpty = false;
            wasPressed = true;
            Instantiate(connectionMaker);
            ConnectionMaker connectionM = GameObject.Find("_ConnectionMaker(Clone)").GetComponent<ConnectionMaker>();
            connectionM.AddConnection(this.transform.parent.GetComponent<RectTransform>(), connectionDir);
        }
        else if (!ConnectionMaker.isConnectionMode && !isEmpty)
        {
            GameObject gObj = ConnectionManager.GetOtherSide(this.transform.parent.GetComponent<RectTransform>(), connectionDir);
            if (gObj != null)
            {
                EntryPoint ep = gObj.GetComponent<EntryPoint>();
                if (ConnectionManager.DeleteThisConnection(this.transform.parent.GetComponent<RectTransform>(), connectionDir))
                {
                    isEmpty = true;
                    changed = true;
                    ep.isEmpty = true;
                    ep.changed = true;
                    Debug.Log("sucesso");
                }
                else
                {
                    Debug.Log("sem sucesso");
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        updateSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if(!ConnectionMaker.isConnectionMode){
            wasPressed = false;
        }
        if (ConnectionMaker.isConnectionMode && !changed)
        {
            if (wasPressed)
            {
                changed = true;
                boxCollider.enabled = true;
                spriteRenderer.enabled = true;
            }
            else
            {
                changed = true;
                boxCollider.enabled = false;
                spriteRenderer.enabled = false;
            }
            updateSprite();
        }
        else if (!ConnectionMaker.isConnectionMode && changed)
        {
            changed = false;
            boxCollider.enabled = true;
            spriteRenderer.enabled = true;
            updateSprite();
        }
    }
    private void updateSprite()
    {
        spriteRenderer.sprite = sprites[plusOrMinus()];
    }
}