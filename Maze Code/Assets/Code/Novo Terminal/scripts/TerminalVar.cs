using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TerminalVar : TerminalBlocks {
    public string name;
    
    SymbolTable st;
    public TerminalEnums.varTypes newType;
    VariableManager.Type type;

    private TMP_InputField var;
    private TextMeshProUGUI typeInput;
    private string oldVar;
    private string logicOp;
    private string oldType;

    private void Start () {
        st = SymbolTable.instance;
        var = window.transform.Find ("Panel/Description/Name/Nome").GetComponent<TMP_InputField> ();
        typeInput = window.transform.Find ("Panel/tipo/Label").GetComponent<TextMeshProUGUI> ();
        oldVar = var.text;
        Debug.Log(oldVar);
        oldType = typeInput.text;
        type = GetType (oldType);
        ToUI ();
    }
    public override IEnumerator RunBlock () {
        Debug.Log("Inicializando " + name + "...");
        MarkExec();
        st.symbolTable[scopeId].CreateVar (name, GetInitValue (newType), newType);
        yield return new WaitForSeconds(ExecTimeManager.instance.execTime);
        if (nextBlock != null  && !TerminalCancelManager.instance.cancel) {
            nextBlock.scopeId = scopeId;
            yield return StartCoroutine (nextBlock.RunBlock ());
        }
        AfterExec();
        yield return null;
    }
    public override void ToUI () {
        name = var.text;
        uiText.text = name;
    }
    //transformar em evento;
    public override void UpdateUI (bool isOk) {
        if (isOk) {
            type = GetType (typeInput.text);
            if (!(oldVar == var.text)) {
                if (VariableManager.Create (var.text, type, VariableManager.StructureType.Variable)) {
                    VariableManager.RemoveFromList (oldVar);
                    oldVar = var.text;
                    oldType = typeInput.text;
            
                }
            } else if (!(oldType == typeInput.text)) {
                VariableManager.RemoveFromList (oldVar);
                VariableManager.Create (var.text, type, VariableManager.StructureType.Variable);
                oldVar = var.text;
                oldType = typeInput.text;
            }
        } else {
            var.text = oldVar;
            typeInput.text = oldType;
        }
        ToUI ();
        return;
    }

    private void OnDestroy () {
        VariableManager.RemoveFromList (oldVar);
    }
    public override bool Compile () {
        nextBlock.Compile();  
        return MarkError((name[0] >= 'a' && name[0] <= 'z') || (name[0] >= 'A' && name[0] <= 'Z'));
    }
    public override void Reset () {
        return;
    }
    public override void SetNextBlock (TerminalBlocks block, ConnectionPoint.ConnectionDirection cd) {
        nextBlock = block;
    }
    public override TerminalBlocks GetNextBlock () {
        return nextBlock;
    }
    public override void HidefromCamera () {
        //ainda n sei se vou precisar
    }

    private string GetInitValue (TerminalEnums.varTypes t) {
        switch (t) {
            case TerminalEnums.varTypes.String:
                return "\"\"";
            case TerminalEnums.varTypes.Int:
                return "0";
            case TerminalEnums.varTypes.Double:
                return "0.0";
            case TerminalEnums.varTypes.Bool:
                return "_True";
            default:
                return "";
        }
    }

    VariableManager.Type GetType (string t) {
        VariableManager.Type newType;
        switch (t) {
            case "Float":
                newType = VariableManager.Type.Float;
                break;
            case "Int":
                newType = VariableManager.Type.Int;
                break;
            default:
                newType = VariableManager.Type.Bool;
                break;
        }

        return newType;
    }

    TerminalEnums.varTypes GetNewType (string t) {
        TerminalEnums.varTypes newType;
        switch (t) {
            case "Float":
                newType = TerminalEnums.varTypes.Double;
                break;
            case "Int":
                newType = TerminalEnums.varTypes.Int;
                break;
            default:
                newType = TerminalEnums.varTypes.Bool;
                break;
        }

        return newType;
    }
}