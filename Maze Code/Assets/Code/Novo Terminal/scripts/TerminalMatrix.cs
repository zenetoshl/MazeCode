using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TerminalMatrix : TerminalBlocks {
    public string name;
    public TerminalEnums.varTypes newType;
    VariableManager.Type type;
    public int sizex;
    public int sizey;
    SymbolTable st;

    private TMP_InputField var;
    private TMP_InputField i;
    private TMP_InputField j;
    private TextMeshProUGUI typeInput;
    private string oldVar;
    private string logicOp;
    private string oldType;
    private string oldI;
    private string oldJ;

    private void Start () {
        st = SymbolTable.instance;
        i = window.transform.Find ("Panel/Operandos/Operando 2/Entrada").GetComponent<TMP_InputField> ();
        j = window.transform.Find ("Panel/Operandos/Operando 2 (1)/Entrada").GetComponent<TMP_InputField> ();
        var = window.transform.Find ("Panel/Operandos/Description/Name/Nome").GetComponent<TMP_InputField> ();
        typeInput =  window.transform.Find ("Panel/Operandos/tipo/Label").GetComponent<TextMeshProUGUI> ();
        oldVar = var.text;
        oldI = i.text;
        oldJ = j.text;
        oldType = typeInput.text;
        type = GetType(oldType);
    }
    public override IEnumerator RunBlock () {
        MarkExec();

        st.symbolTable[scopeId].CreateVar (name, CreateInitMat (GetInitValue (newType), sizex, sizey), newType, sizex, sizey);
        yield return new WaitForSeconds(ExecTimeManager.instance.execTime);
        if (nextBlock != null) {
            nextBlock.scopeId = scopeId;
            yield return StartCoroutine (nextBlock.RunBlock ());
        }
        AfterExec();
        yield return null;
    }
    public override void ToUI () {
        name = var.text;
        sizey = Int32.Parse(j.text);
        sizex = Int32.Parse(i.text);
        uiText.text = name + " [" + sizex + "]" + "[" + sizey + "]";
    }
    public override void UpdateUI (bool isOk) {
        if (isOk) {
            oldI = i.text;
            oldJ = j.text;
            type = GetType (typeInput.text);
            if (!(oldVar == var.text)) {
                if (VariableManager.Create (var.text, type, VariableManager.StructureType.Array)) {
                    VariableManager.RemoveFromList (oldVar);
                    oldVar = var.text;
                    oldType = typeInput.text;
            
                }
            } else if (!(oldType == typeInput.text)) {
                VariableManager.RemoveFromList (oldVar);
                VariableManager.Create (var.text, type, VariableManager.StructureType.Array);
                oldVar = var.text;
                oldType = typeInput.text;
            }
        } else {
            var.text = oldVar;
            i.text = oldI;
            j.text = oldJ;
            typeInput.text = oldType;
        }
        ToUI ();
        return;
    }
    public override bool Compile () {
        nextBlock.Compile ();
        return MarkError (((name[0] >= 'a' && name[0] <= 'z') || (name[0] >= 'A' && name[0] <= 'Z')) && (sizex > 0 && sizex < 1000) && (sizey > 0 && sizey < 1000));
    }
    public override bool Reset () {
        name = "";
        sizex = 0;
        sizey = 0;
        UpdateUI (true);
        return true;
    }
    public override void SetNextBlock (TerminalBlocks block, ConnectionPoint.ConnectionDirection cd) {
        nextBlock = block;
    }
    public override TerminalBlocks GetNextBlock () {
        return nextBlock;
    }
    public override void HidefromCamera () {

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

    //cria um vetor no formato 1,2,3,4,5,6,7,8,3 onde os valores podem ser facilmente retirados utilizando um split(',')
    private string CreateInitMat (string initVal, int size1, int size2) {
        string returnValue = "";
        int size = size1 * size2;
        for (int i = 0; i < size; i++) {
            if (i != size - 1)
                returnValue = returnValue + initVal + ",";
            else
                returnValue = returnValue + initVal;
        }

        return returnValue;
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