using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlocoVariavel : Bloco {

    private TMP_InputField var;
    private string oldVar;
    private string logicOp;

    public VariableManager.Type type;

    private void Start () {
        LeanWindow myWindow = this.GetComponent<InstantiateTerminal> ().GetMyWindow ();
        var = myWindow.transform.Find ("Panel/Description/Nome").GetComponent<TMP_InputField> ();
        oldVar = var.text;
        ToUI ();
    }
    public override string ToCode () {
        switch (type) {
            case VariableManager.Type.Float:
                return "var " + var.text + " = " + "0.0" + ";";
                break;
            case VariableManager.Type.Int:
                return "var " + var.text + " = " + "0" + ";";
                break;
            default:
                return "var " + var.text + " = " + "0" + ";";
        }
    }

    public override void UpdateUI (bool isOk) {
        if (isOk) {
            if (!(oldVar == var.text)) {
                if (VariableManager.Create (var.text, VariableManager.Type.Int, VariableManager.StructureType.Variable)) {
                    VariableManager.RemoveFromList (oldVar);
                    oldVar = var.text;
                    Bloco.changed = true;
                    ToUI ();
                    return;
                }
            }
        }
        Debug.Log (oldVar);
        var.text = oldVar;
        Bloco.changed = true;
        ToUI ();
    }

    private void OnDestroy () {
        VariableManager.RemoveFromList (oldVar);
    }

    public override bool Compile () {
        //TODO: implementação
        return MarkError (true);
    }

    public string GetVarName () {
        return var.text;
    }

    public override void ToUI () {
        uiText.text = var.text;
    }
}