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
    private Var_Vet_Mat _var;

    private string oldOp;

    private void Start() {
        op = window.transform.Find("Panel/Content/Operation").GetComponent<TextMeshProUGUI>();
        _var = window.transform.Find("Panel/Content/var_vet_mat").GetComponent<Var_Vet_Mat>();
        oldOp = op.text;
        var = _var.GetText();
    }

    public override void TurnOn () {
        if (window == null) return;
        ListVars();
        window.TurnOn ();
    }

    public override IEnumerator RunBlock(){
        SymbolTable st = SymbolTable.instance;
        MarkExec();
        string result = OperationManager.StartOperation(operation, st.GetVarType(var, scopeId), scopeId);
        st.SetValueFromString(var, scopeId, result);
        uiText.text = result;
        
        yield return new WaitForSeconds(ExecTimeManager.instance.execTime);
        if (nextBlock != null) {
            nextBlock.scopeId = scopeId;
            yield return StartCoroutine (nextBlock.RunBlock ());
        }
        AfterExec();
        yield return null;
    }
    public override void ToUI (){
        operation = op.text + " ";
        uiText.text = operation;
    }
    public override void UpdateUI (bool isOk){
        if(isOk){
            oldOp = op.text;
            var = _var.GetText();
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
    public override void Reset (){
        ToUI();
        return;
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
