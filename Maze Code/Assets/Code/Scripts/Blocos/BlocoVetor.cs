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
    private TextMeshProUGUI typeInput;
    private string oldVar;
    private string oldI;
    private string oldType;

    public VariableManager.Type type;

    private void Start () {
        uiText.text = "---";
        LeanWindow myWindow = this.GetComponent<InstantiateTerminal> ().GetMyWindow ();
        var = myWindow.transform.Find ("Panel/Operandos/Description/Name/Nome").GetComponent<TMP_InputField> ();
        i = myWindow.transform.Find ("Panel/Operandos/Operando 2/Entrada").GetComponent<TMP_InputField> ();
        typeInput =  myWindow.transform.Find ("Panel/Operandos/tipo/Label").GetComponent<TextMeshProUGUI> ();
        oldVar = var.text;
        oldI = i.text;
        oldType = typeInput.text;
        type = GetNewType(oldType);
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
            Compiler.instance.Uncompile();
            oldI = i.text;
            type = GetNewType(typeInput.text);
            if (!(oldVar == var.text)) {
                if (VariableManager.Create (var.text, type, VariableManager.StructureType.Array)) {
                    VariableManager.RemoveFromList (oldVar);
                    oldVar = var.text;
                    oldType = typeInput.text;
                }
            } else if(!(oldType == typeInput.text)){
                VariableManager.RemoveFromList (oldVar);
                VariableManager.Create (var.text, type, VariableManager.StructureType.Array);
                oldVar = var.text;
                oldType = typeInput.text;
            }
            Bloco.changed = true;
            ToUI ();
        } else {
            var.text = oldVar;
            i.text = oldI;
            typeInput.text = oldType;
        }
    }

    VariableManager.Type GetNewType(string t){
        VariableManager.Type newType;
         switch (t) {
            case "Float":
                newType = VariableManager.Type.Float;
                break;
            case "Int":
                newType = VariableManager.Type.Int;
                break;
            default:
                newType = VariableManager.Type.Float;
                break;
        }

        return newType;
    }

    private void OnDestroy () {
        VariableManager.RemoveFromList (oldVar);
    }

    public override bool Compile () {
        bool noError = true;
        if(!(uiText.text != "---"))
        {
            ErrorLogManager.instance.CreateError("Bloco não inicializado corretamente");
            noError = MarkError(false);
        }
        if(!CheckString (i.text)){
            ErrorLogManager.instance.CreateError("Valor invalido");
            noError = MarkError(false);
        }
        return noError;
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