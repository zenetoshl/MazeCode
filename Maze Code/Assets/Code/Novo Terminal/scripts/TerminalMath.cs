using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TerminalMath : TerminalBlocks
{
    //MathOperation operation;
    public string operation;
    public string var;

    private TextMeshProUGUI op;

    private string oldOp;
    public override IEnumerator RunBlock(){
        SymbolTable st = SymbolTable.instance;
        Debug.Log(var + " = " + operation);
        st.SetValueFromString(var, scopeId, OperationManager.StartOperation(operation, st.GetVarType(var, scopeId), scopeId));
        
        yield return null;
        if (nextBlock != null) {
            nextBlock.scopeId = scopeId;
            yield return StartCoroutine (nextBlock.RunBlock ());
        }
        yield return null;
    }
    public override void ToUI (){
        operation = op.text;
        uiText.text = operation;
    }
    public override void UpdateUI (bool isOk){
        if(isOk){
            oldOp = op.text;
            ToUI();
        } else {
            op.text = oldOp;
        }
    }
    public override bool Compile (){
        bool noError = true;
        if(!(uiText.text != "---"))
        {
            ErrorLogManager.instance.CreateError("Bloco não inicializado corretamente");
            noError = MarkError(false);
        }
        if(!(op.text != null && op.text != "")){
            ErrorLogManager.instance.CreateError("Operação invalida");
            noError = MarkError(false);
        }
        MarkError(noError);
        return noError;
    }
    public override bool Reset (){
        return true;
    }
    public override void SetNextBlock (TerminalBlocks block, ConnectionPoint.ConnectionDirection cd){
        nextBlock = block;
    }
    public override TerminalBlocks GetNextBlock (){
        return null;
    }
    public override void HidefromCamera (){

    }
}
