using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Lean.Gui;

public class BlocoWhile : Bloco
{
    private Var_Vet_Mat var;
    private Num_Var_Vet_Mat val;
    private TextMeshProUGUI op;
    
    private string oldOp;

    private void Start() {
        uiText.text = "---";
        LeanWindow myWindow = this.GetComponent<InstantiateTerminal>().GetMyWindow();
        var = myWindow.transform.Find("Panel/Operandos/var_vet_mat").GetComponent<Var_Vet_Mat>();
        op = myWindow.transform.Find("Panel/Operandos/Operador/Label").GetComponent<TextMeshProUGUI>();
        val = myWindow.transform.Find("Panel/Operandos/num_var_vet_mat").GetComponent<Num_Var_Vet_Mat>();
        oldOp = op.text;
    }


    public override string ToCode()
    {
        string BlocoCode = "while("+ var.GetText()+ op.text + val.GetActiveText()+ ")";
        return BlocoCode;
    }

    public override void UpdateUI(bool isOk){
        if(isOk){
            Compiler.instance.Uncompile();
            var.SaveConfig();
            oldOp = op.text;
            val.SaveConfig();
            Bloco.changed = true;
            ToUI();
        } else {
            var.ResetConfig();
            op.text = oldOp;
            val.ResetConfig();
        }
    }

    public override bool Compile(){
        bool noError = true;
        if(!(uiText.text != "---"))
        {
            ErrorLogManager.instance.CreateError("Bloco não inicializado corretamente");
            noError = MarkError(false);
        }
        if(!CheckVars()){
            ErrorLogManager.instance.CreateError("Alguma variavel nao existe no escopo deste bloco");
            noError = MarkError(false);
        }
        if(!(op.text != null && op.text != "")){
            ErrorLogManager.instance.CreateError("Operador invalido");
            noError = MarkError(false);
        }
        return noError;
    }

    private bool CheckVars(){
        List<string> scope = VariableManager.GetScope(this.GetComponent<RectTransform>());
        return var.Compile(scope) && val.Compile(scope);
    }

    public override void ToUI(){
        uiText.text = var.GetText() +"\n"+ op.text + "\n"+ val.GetActiveText();
    }
}
