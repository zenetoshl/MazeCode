using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
using Lean.Gui;

public class BlocoFor : Bloco
{
    private Var_Vet_Mat var;
    private TMP_InputField initial;
    private TMP_InputField end;
    private TextMeshProUGUI op;

    private string oldOp;
    private string oldEnd;
    private string oldInitial;

    private void Start() {
        uiText.text = "---";
        LeanWindow myWindow = this.GetComponent<InstantiateTerminal>().GetMyWindow();
        var = myWindow.transform.Find("Panel/Operandos/var_vet_mat").GetComponent<Var_Vet_Mat>();
        op = myWindow.transform.Find("Panel/Operandos/Incremento/Label").GetComponent<TextMeshProUGUI>();
        initial = myWindow.transform.Find("Panel/Operandos/de/Entrada").GetComponent<TMP_InputField>();
        end = myWindow.transform.Find("Panel/Operandos/ate/Entrada").GetComponent<TMP_InputField>();
        oldOp = op.text;
        oldEnd = end.text;
        oldInitial = initial.text;
    }


    public override string ToCode()
    {
        string BlocoCode = "for(" + var.GetText() + " = " + initial.text + " ;" + var.GetText() + "<=" + end.text + ";" +var.GetText()+op.text + ")";
        return BlocoCode;
    }

    public override void UpdateUI(bool isOk){
        if(isOk){
            var.SaveConfig();
            oldOp = op.text;
            oldEnd = end.text;
            oldInitial = initial.text;
            Bloco.changed = true;
            ToUI();
        } else {
            var.ResetConfig();
            op.text = oldOp;
            initial.text = oldInitial;
            end.text = oldEnd;
        }
    }

    public override bool Compile(){
        return  MarkError((uiText.text != "---") && CheckVars() && CheckString(op.text) && CheckString(initial.text) && CheckString(end.text) && int.Parse(initial.text) <= int.Parse(end.text));
    }

    private bool CheckString(string s){
        return s != null && s != "";
    }

    private bool CheckVars(){
        List<string> scope = VariableManager.GetScope(this.GetComponent<RectTransform>());
        return var.Compile(scope);
    }

    public override void ToUI(){
        uiText.text = var.GetText() + "\nDe " + initial.text + "\nAté " + end.text;
    }
}
