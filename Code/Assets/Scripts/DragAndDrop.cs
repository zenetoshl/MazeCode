﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler
{

    public Transform prefab;

    private Transform spawn;

    void Update()
    {
        if (Input.GetMouseButton(0) && spawn != null)
        {
            var pos = Input.mousePosition;
            pos.z = -Camera.main.transform.position.z;
            spawn.transform.position = Camera.main.ScreenToWorldPoint(pos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            ClickController.isClickingOnObject = false;
            spawn = null;
        }


    }

    public void OnPointerDown(PointerEventData eventData){
        ClickController.isClickingOnObject = true;
        var pos = Input.mousePosition;
        pos.z = -Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);
        spawn = Instantiate(prefab, pos, Quaternion.identity) as Transform;
    }

    void OnGUI() {
         
     }
}