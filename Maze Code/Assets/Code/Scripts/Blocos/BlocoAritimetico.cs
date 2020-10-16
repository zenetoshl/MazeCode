using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlocoAritimetico : Bloco {
    private Var_Vet_Mat var;
    private Num_Var_Vet_Mat val;
    private Num_Var_Vet_Mat val2;
    private TextMeshProUGUI op;

    private string oldOp;

    private void Start () {
        uiText.text = "---";
        LeanWindow myWindow = this.GetComponent<InstantiateTerminal> ().GetMyWindow ();
        var = myWindow.transform.Find ("Panel/Operandos/var_vet_mat").GetComponent<Var_Vet_Mat> ();
        op = myWindow.transform.Find ("Panel/Operandos/Operador/Label").GetComponent<TextMeshProUGUI> ();
        val = myWindow.transform.Find ("Panel/Operandos/num_var_vet_mat").GetComponent<Num_Var_Vet_Mat> ();
        val2 = myWindow.transform.Find ("Panel/Operandos/num_var_vet_mat (1)").GetComponent<Num_Var_Vet_Mat> ();
        oldOp = op.text;
    }

    public override string ToCode () {
        string BlocoCode = var.GetText () + " = " + val.GetActiveText () + op.text + val2.GetActiveText () + ";";
        return BlocoCode;
    }

    public override void UpdateUI (bool isOk) {
        if (isOk) {
            Compiler.instance.Uncompile();
            var.SaveConfig ();
            oldOp = op.text;
            val.SaveConfig ();
            val2.SaveConfig ();
            Bloco.changed = true;
            ToUI ();
        } else {
            var.ResetConfig ();
            op.text = oldOp;
            val.ResetConfig ();
            val2.ResetConfig ();
        }
    }

    public override bool Compile () {
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

    private bool CheckVars () {
        List<string> scope = VariableManager.GetScope (this.GetComponent<RectTransform> ());
        return (CheckTypes ()) && (var.Compile (scope) && val.Compile (scope) && val2.Compile (scope));
    }

    private bool CheckTypes () {
        Debug.Log(VariableManager.GetTypeOf (var.GetName()) + " = " + val.GetType () + " + " + val2.GetType ());
        if (VariableManager.GetTypeOf (var.GetName()) == VariableManager.Type.Int) {
            return (val.GetType () == VariableManager.Type.Int) && (val2.GetType () == VariableManager.Type.Int);
        } else return true;
    }

    public override void ToUI () {
        uiText.text = var.GetText () + " = " + val.GetActiveText () + " " + op.text + " " + val2.GetActiveText ();
    }
}