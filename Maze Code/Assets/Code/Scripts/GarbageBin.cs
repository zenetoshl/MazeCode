using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBin : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject gameObject = null;



    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("1");
        gameObject = other.gameObject;
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("2");
        gameObject = null;
    }
    private void OnMouseUp()
    {
        Debug.Log("3");
        if (gameObject != null)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
