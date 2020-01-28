using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionAux : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 screenPoint;
    private Vector3 offset;

    private bool first = true;
    private void OnMouseEnter() {
        if (first)
        {
            first = false;
            ClickController.isClickingOnObject = true;
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        }
    }
    void OnMouseDrag()
    {
        
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    void OnMouseUp()
    {
        ClickController.isClickingOnObject = false;
        Destroy(this.gameObject);
    }
}
