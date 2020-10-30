using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using UnityEngine;

public class BlocoLeitura : Bloco {
    // Start is called before the first frame update
    private Var_Vet_Mat var;

    private void Start () {
        uiText.text = "---";
        LeanWindow myWindow = this.GetComponent<InstantiateTerminal> ().GetMyWindow ();
        var = myWindow.transform.Find ("Panel/var_vet_mat").GetComponent<Var_Vet_Mat> ();
    }
    public override string ToCode () {
        string varName = var.GetName();
        string doubleText =  varName + " = _Dinputs[_j++];";
        string intText = varName + " =  _inputs[_i++];";
        return( (var.type == VariableManager.Type.Int) ? intText : doubleText);

    }

    public override void UpdateUI (bool isOk) {
        if (isOk) {
            Compiler.instance.Uncompile ();
            var.SaveConfig ();
            Bloco.changed = true;
            ToUI ();
        } else {
            var.ResetConfig ();
        }
    }

    public override bool Compile () {
        List<string> scope = VariableManager.GetScope (this.GetComponent<RectTransform> ());
        bool noError = true;
        if(!(uiText.text != "---"))
        {
            ErrorLogManager.instance.CreateError("Bloco não inicializado corretamente");
            noError = MarkError(false);
        }
        if(!var.Compile (scope)){
            ErrorLogManager.instance.CreateError("Variavel nao existe no escopo deste bloco");
            noError = MarkError(false);
        }
        return noError;
    }

    public override void ToUI () {
        uiText.text = var.GetText ();
    }
}