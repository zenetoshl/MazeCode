using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;

public class BlocoPrint : Bloco
{
    private Var_Vet_Mat var;

    private void Start()
    {
        uiText.text = "---";
        LeanWindow myWindow = this.GetComponent<InstantiateTerminal>().GetMyWindow();
        var = myWindow.transform.Find("Panel/var_vet_mat").GetComponent<Var_Vet_Mat>();
    }
    public override string ToCode()
    {
        return "_output += " + var.GetText() + "+ \" \";";
    }

    public override void UpdateUI(bool isOk){
        if(isOk){
            var.SaveConfig();
            Bloco.changed = true;
            ToUI();
        } else {
            var.ResetConfig();
        }
    }

    public override bool Compile(){
        List<string> scope = VariableManager.GetScope(this.GetComponent<RectTransform>());
        return MarkError((uiText.text != "---") && var.Compile(scope));
    }

    public override void ToUI(){
        uiText.text = var.GetText();
    }
}
