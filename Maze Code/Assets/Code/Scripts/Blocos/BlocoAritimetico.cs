using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
using Lean.Gui;

public class BlocoAritimetico : Bloco
{
    private Var_Vet_Mat var;
    private Num_Var_Vet_Mat val;
    private Num_Var_Vet_Mat val2;
    private TextMeshProUGUI op;

    private string oldOp;

    private void Start() {
        uiText.text = "---";
        LeanWindow myWindow = this.GetComponent<InstantiateTerminal>().GetMyWindow();
        var = myWindow.transform.Find("UI_Input/Panel/Operandos/var_vet_mat").GetComponent<Var_Vet_Mat>();
        op = myWindow.transform.Find("UI_Input/Panel/Operandos/Operador/Label").GetComponent<TextMeshProUGUI>();
        val = myWindow.transform.Find("UI_Input/Panel/Operandos/num_var_vet_mat").GetComponent<Num_Var_Vet_Mat>();
        val2 = myWindow.transform.Find("UI_Input/Panel/Operandos/num_var_vet_mat (1)").GetComponent<Num_Var_Vet_Mat>();
        oldOp = op.text;
    }


    public override string ToCode()
    {
        string BlocoCode = var.GetText() + " = " + val.GetActiveText() + op.text + val2.GetActiveText() + ";";
        return BlocoCode;
    }

    public override void UpdateUI(bool isOk){
        if(isOk){
            var.SaveConfig();
            oldOp = op.text;
            val.SaveConfig();
            val2.SaveConfig();
            Bloco.changed = true;
            ToUI();
        } else {
            var.ResetConfig();
            op.text = oldOp;
            val.ResetConfig();
            val2.ResetConfig();
        }
    }

    public override bool Compile(){
        return  MarkError((uiText.text != "---") && CheckVars() && op.text != null && op.text != "");
    }

    private bool CheckVars(){
        List<string> scope = VariableManager.GetScope(this.GetComponent<RectTransform>());
        return var.Compile(scope) && val.Compile(scope) && val2.Compile(scope);
    }

    public override void ToUI(){
        uiText.text = var.GetText() + " = " + val.GetActiveText() + " " + op.text + " " + val2.GetActiveText();
    }
}
