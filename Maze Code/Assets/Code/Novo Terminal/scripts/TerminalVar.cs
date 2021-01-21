using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalVar : TerminalBlocks {
    public string name;
    public TerminalEnums.varTypes type;
    SymbolTable st;

    private void Start () {
        st = SymbolTable.instance;
    }
    public override IEnumerator RunBlock () {
        Debug.Log("Inicializando " + name + "...");
        st.symbolTable[scopeId].CreateVar (name, GetInitValue (type), type);
        yield return null;
        if (nextBlock != null) {
            nextBlock.scopeId = scopeId;
            yield return StartCoroutine (nextBlock.RunBlock ());
        }
        yield return null;
    }
    public override void ToUI () {

    }
    //transformar em evento;
    public override void UpdateUI (bool isOk) {
        uiText.text = name + " = " + st.GetVarValue (name, scopeId);
    }
    public override bool Compile () {
        nextBlock.Compile();  
        return MarkError((name[0] >= 'a' && name[0] <= 'z') || (name[0] >= 'A' && name[0] <= 'Z'));
    }
    public override bool Reset () {
        name = "";
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
}