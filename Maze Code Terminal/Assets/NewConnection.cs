﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewConnection : MonoBehaviour
{
    
    public GameObject connectionMaker;
    public ConnectionPoint.ConnectionDirection connectionDir = ConnectionPoint.ConnectionDirection.North;
    private bool isEmpty = true;
    public Sprite[] sprites = new Sprite[2];
    private SpriteRenderer spriteRenderer;

    private int plusOrMinus(){
        return isEmpty ? 0 : 1;
    }

    private void OnMouseUp() {
        Debug.Log("cliquei");
        Instantiate(connectionMaker);
        ConnectionMaker connectionM = GameObject.Find("_ConnectionMaker(Clone)").GetComponent<ConnectionMaker>();
        connectionM.AddConnection(this.transform.parent.GetComponent<RectTransform>(), connectionDir);
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[plusOrMinus()];
        Debug.Log(this.transform.parent.transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {

    }
}