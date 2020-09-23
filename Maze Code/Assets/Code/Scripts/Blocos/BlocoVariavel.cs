using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlocoVariavel : Bloco {

    private TMP_InputField var;
    private TextMeshProUGUI typeInput;
    private string oldVar;
    private string logicOp;
    private string oldType;

    public VariableManager.Type type;

    private void Start () {
        LeanWindow myWindow = this.GetComponent<InstantiateTerminal> ().GetMyWindow ();
        var = myWindow.transform.Find ("Panel/Description/Name/Nome").GetComponent<TMP_InputField> ();
        typeInput = myWindow.transform.Find ("Panel/tipo/Label").GetComponent<TextMeshProUGUI> ();
        oldVar = var.text;
        oldType = typeInput.text;
        type = GetNewType(oldType);
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
            type = GetNewType(typeInput.text);
            if (!(oldVar == var.text)) {
                if (VariableManager.Create (var.text, type, VariableManager.StructureType.Variable)) {
                    VariableManager.RemoveFromList (oldVar);
                    oldVar = var.text;
                    Bloco.changed = true;
                    oldType = typeInput.text;
                    ToUI ();
                    return;
                }
            } else if (!(oldType == typeInput.text)) {
                VariableManager.RemoveFromList (oldVar);
                VariableManager.Create (var.text, type, VariableManager.StructureType.Variable);
                oldVar = var.text;
                oldType = typeInput.text;
                Bloco.changed = true;
                ToUI ();
                return;
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

    VariableManager.Type GetNewType (string t) {
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

    public string GetVarName () {
        return var.text;
    }

    public override void ToUI () {
        uiText.text = var.text;
    }
}