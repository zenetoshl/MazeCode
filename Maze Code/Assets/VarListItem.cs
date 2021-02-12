using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VarListItem : MonoBehaviour
{
    public string varName = "";
    public TextMeshProUGUI name;
    public ToggleManager x;
    public ToggleManager y;
    public NumberPad numpad;

    public void Initialize(string s){
        varName = s;
        name.text = varName;
    }

    public void SendToUi(){
        numpad.InsertToOperation(varName);
    }
}
