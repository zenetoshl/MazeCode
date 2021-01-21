using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalMatrix : TerminalBlocks {
    public string var;
    public TerminalEnums.varTypes type;
    public int sizex;
    public int sizey;
    SymbolTable st;

    private void Start () {
        st = SymbolTable.instance;
    }
    public override IEnumerator RunBlock () {
        st.symbolTable[scopeId].CreateVar (name, CreateInitMat (GetInitValue (type), sizex, sizey), type, sizex, sizey);
        yield return null;
        if (nextBlock != null) {
            nextBlock.scopeId = scopeId;
            yield return StartCoroutine (nextBlock.RunBlock ());
        }
        yield return null;
    }
    public override void ToUI () {

    }
    public override void UpdateUI (bool isOk) {
        uiText.text = name + " [" + sizex + "]" + "[" + sizey + "]";
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
    public override void SetNextBlock (TerminalBlocks block) {
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
}