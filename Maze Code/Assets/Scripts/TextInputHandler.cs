using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextInputHandler : MonoBehaviour
{
    public TextMeshProUGUI textInput;
    private bool changed = false;

    // Start is called before the first frame update
    public void OnValueChanged(){
        if(!changed){
            TextInputInstantiator.InstantiateText(this.transform.parent);
            changed = true;
        }
    }

    public void OnDeselect(){
        if (textInput.text.Length <= 1 && changed){
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
