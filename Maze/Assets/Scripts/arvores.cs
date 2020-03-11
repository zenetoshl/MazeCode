using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arvores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision2d)
    {
        if (collision2d.gameObject.CompareTag("arvore"))
        {
            //Debug.Log("OIIIIII");
            GetComponent<Renderer>().sortingOrder = 100;
        }
    }
    private void OnTriggerExit2D(Collider2D collision2d)
    {
        if (collision2d.gameObject.CompareTag("arvore"))
        {
            //Debug.Log("Tchauuuuuuu");
            GetComponent<Renderer>().sortingOrder = 0;
        }
    }
}
