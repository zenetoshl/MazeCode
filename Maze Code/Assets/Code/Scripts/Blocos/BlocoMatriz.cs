using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlocoMatriz : Bloco {
    // Start is called before the first frame update
    private TMP_InputField var;
    private TMP_InputField i;
    private TMP_InputField j;
    private string oldVar;
    private string oldI;
    private string oldJ;
    private TextMeshProUGUI typeInput;
    private string oldType;

    public VariableManager.Type type;

    private void Start () {
        uiText.text = "---";
        LeanWindow myWindow = this.GetComponent<InstantiateTerminal> ().GetMyWindow ();
        i = myWindow.transform.Find ("Panel/Operandos/Operando 2/Entrada").GetComponent<TMP_InputField> ();
        j = myWindow.transform.Find ("Panel/Operandos/Operando 2 (1)/Entrada").GetComponent<TMP_InputField> ();
        var = myWindow.transform.Find ("Panel/Operandos/Description/Name/Nome").GetComponent<TMP_InputField> ();
        typeInput =  myWindow.transform.Find ("Panel/Operandos/tipo/Label").GetComponent<TextMeshProUGUI> ();
        oldVar = var.text;
        oldI = i.text;
        oldJ = j.text;
        oldType = typeInput.text;
        type = GetNewType(oldType);
    }

    public override string ToCode () {
        string matInit = "";
        string matType = "";
        switch (type) {
            case VariableManager.Type.Float:
                matInit = RepeatInit ("0.0", Convert.ToInt32 (oldI), Convert.ToInt32 (oldJ));
                matType = "double";
                break;
            case VariableManager.Type.Int:
                matInit = RepeatInit ("0", Convert.ToInt32 (oldI), Convert.ToInt32 (oldJ));
                matType = "int";
                break;
            default:
                matInit = RepeatInit ("0.0", Convert.ToInt32 (oldI), Convert.ToInt32 (oldJ));
                matType = "double";
                break;
        }
        return matType + "[,] " + var.text + "= " + matInit;
    }

    private string RepeatInit (string s, int iLimit, int jLimit) {
        string returnString = "{ ";
        for (int i = 0; i < iLimit; i++) {
            returnString += "{";
            for (int j = 0; j < jLimit; j++) {
                if (j == jLimit - 1) {
                    returnString += (s);
                } else {
                    returnString += (s + ", ");
                }
            }
            if (i == iLimit - 1) {
                returnString += "}";
            } else {
                returnString += "},";
            }
        }
        returnString += "};";
        return returnString;
    }

    public override void UpdateUI (bool isOk) {
        if (isOk) {
            Compiler.instance.Uncompile();
            oldI = i.text;
            oldJ = j.text;
            type = GetNewType(typeInput.text);
            if (!(oldVar == var.text)) {
                if (VariableManager.Create (var.text, type, VariableManager.StructureType.Matriz)) {
                    VariableManager.RemoveFromList (oldVar);
                    oldVar = var.text;
                    oldType = typeInput.text;
                }
            }
             else if(!(oldType == typeInput.text)){
                VariableManager.RemoveFromList (oldVar);
                VariableManager.Create (var.text, type, VariableManager.StructureType.Matriz);
                oldVar = var.text;
                oldType = typeInput.text;
            }
            Bloco.changed = true;
            ToUI ();
        } else {
            var.text = oldVar;
            i.text = oldI;
            j.text = oldJ;
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
        return MarkError ((uiText.text != "---") && CheckString (i.text) && CheckString (j.text));
    }

    private bool CheckString (string s) {
        return s != null && s != "";
    }

    public string GetVarName () {
        return var.text;
    }

    public override void ToUI () {
        uiText.text = var.text + "[" + i.text + "]" + "[" + j.text + "]";
    }
}