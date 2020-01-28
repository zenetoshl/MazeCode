using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coder : MonoBehaviour
{

    public GameObject begin;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp() {
        ToCode();
    }

    public void ToCode(){
        Debug.Log(ConnectionManager.ToCode(begin.GetComponent<RectTransform>()));
    }
}
