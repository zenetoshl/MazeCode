using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VarItemUI : MonoBehaviour
{
    public TextMeshProUGUI varName;
    public ToggleManager vet;
    public ToggleManager mat;
    public WindowPad pad;
    
    public void Initialize(string name, WindowPad _pad){
        varName.text = name;
        if(VariableManager.ReturnStructureType(name) != VariableManager.StructureType.Variable){
            vet.gameObject.SetActive(true);
            if(VariableManager.ReturnStructureType(name) == VariableManager.StructureType.Matriz){
               mat.gameObject.SetActive(true); 
            }
        }
        pad = _pad;
    }

    public void OnButtonPressed(){
        string sendText = varName.text;
        if(vet.gameObject.activeSelf){
            sendText = sendText + vet.GetActiveText();
        }
        if(mat.gameObject.activeSelf){
            sendText = sendText + mat.GetActiveText();
        }
        pad.InsertToOperation(sendText);
    }
}
