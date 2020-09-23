using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlocoVetor : Bloco {
    // Start is called before the first frame update
    private TMP_InputField var;
    private TMP_InputField i;
    private string oldVar;
    private string oldI;

    public VariableManager.Type type;

    private void Start () {
        uiText.text = "---";
        LeanWindow myWindow = this.GetComponent<InstantiateTerminal> ().GetMyWindow ();
        var = myWindow.transform.Find ("Panel/Operandos/Description/Name/Nome").GetComponent<TMP_InputField> ();
        i = myWindow.transform.Find ("Panel/Operandos/Operando 2/Entrada").GetComponent<TMP_InputField> ();
        oldVar = var.text;
        oldI = i.text;
    }
    public override string ToCode () {
        string vetInit = "";
        string vetType = "";
        switch (type) {
            case VariableManager.Type.Float:
                vetInit = RepeatInit ("0.0", Convert.ToInt32 (oldI));
                vetType = "double";
                break;
            case VariableManager.Type.Int:
                vetInit = RepeatInit ("0", Convert.ToInt32 (oldI));
                vetType = "int";
                break;
            default:
                vetInit = RepeatInit ("0.0", Convert.ToInt32 (oldI));
                vetType = "double";
                break;
        }
        return vetType + "[] " + var.text + " = " + vetInit;
    }

    private string RepeatInit (string s, int limit) {
        string returnString = "{ ";
        for (int i = 0; i < limit; i++) {
            if (i == limit - 1) {
                returnString += (s);
            } else {
                returnString += (s + ", ");
            }
        }
        returnString += "};";
        return returnString;
    }

    public override void UpdateUI (bool isOk) {
        if (isOk) {
            oldI = i.text;
            if (!(oldVar == var.text)) {
                if (VariableManager.Create (var.text, VariableManager.Type.Int, VariableManager.StructureType.Array)) {
                    VariableManager.RemoveFromList (oldVar);
                    oldVar = var.text;
                }
            }
            Bloco.changed = true;
            ToUI ();
        } else {
            var.text = oldVar;
            i.text = oldI;
        }
    }

    private void OnDestroy () {
        VariableManager.RemoveFromList (oldVar);
    }

    public override bool Compile () {
        return MarkError ((uiText.text != "---") && CheckString (i.text));
    }

    private bool CheckString (string s) {
        return s != null && s != "";
    }

    public string GetVarName () {
        return var.text;
    }

    public override void ToUI () {
        uiText.text = var.text + "[" + i.text + "]";
    }
}