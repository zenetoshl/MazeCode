using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Lean.Gui;

public class BlocoVariavel : Bloco
{
    
    private TMP_InputField var;
    private string oldVar;
    private string logicOp;

    private void Start() {
        LeanWindow myWindow = this.GetComponent<InstantiateTerminal>().GetMyWindow();
        var = myWindow.transform.Find("Panel/Description/Nome").GetComponent<TMP_InputField>();
        oldVar = var.text;
        ToUI();
    }
    public override string ToCode()
    {
        return "int " + var.text + "= 0"+ ";";
    }

    public override void UpdateUI(bool isOk){
        if(isOk){
            if(!(oldVar == var.text)){
                if(VariableManager.Create( var.text, VariableManager.Type.Int, VariableManager.StructureType.Variable)){
                    VariableManager.RemoveFromList(oldVar);
                    oldVar = var.text;
                    Bloco.changed = true;
                    ToUI();
                    return;
                }
            }
        }
        Debug.Log(oldVar);
        var.text = oldVar;
        Bloco.changed = true;
        ToUI();
    }

    private void OnDestroy() {
        VariableManager.RemoveFromList(oldVar);
    }

    public override bool Compile(){
        //TODO: implementação
        return MarkError(true);
    }

    public string GetVarName(){
        return var.text;
    }

    public override void ToUI(){
        uiText.text = var.text;
    }
}
