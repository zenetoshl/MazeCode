using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TerminalIf : TerminalBlocks {
    public string operation;
    public int trueAlternativeScopeId;
    public int falseAlternativeScopeId;
    public TerminalBlocks nextTrue = null;
    public TerminalBlocks nextFalse = null;
    private bool isScopeCreated = false;

    private TextMeshProUGUI op;

    private string oldOp;

    private void Start() {
        op = window.transform.Find("Panel/Content/Operation").GetComponent<TextMeshProUGUI>();
        oldOp = op.text;
        
    }

    public override void TurnOn () {
        if (window == null) return;
        ListVars();
        window.TurnOn ();
    }

    public override IEnumerator RunBlock () {
        trueAlternativeScopeId = SymbolTable.instance.CreateScope (scopeId);
        falseAlternativeScopeId = SymbolTable.instance.CreateScope (scopeId);
        MarkExec();

        bool resp = OperationManager.StartOperation (operation, TerminalEnums.varTypes.Bool, scopeId) == "True";
        uiText.text = "" + resp;

        if (nextTrue != null && !resp  && !TerminalCancelManager.instance.cancel) {
            nextTrue.scopeId = trueAlternativeScopeId;
            yield return StartCoroutine (nextTrue.RunBlock ());
        } else if (nextFalse != null && resp  && !TerminalCancelManager.instance.cancel) {
            nextFalse.scopeId = falseAlternativeScopeId;
            yield return StartCoroutine (nextFalse.RunBlock ());
        }
        yield return new WaitForSeconds(ExecTimeManager.instance.execTime);
        if (nextBlock != null  && !TerminalCancelManager.instance.cancel) {
            nextBlock.scopeId = scopeId;
            yield return StartCoroutine (nextBlock.RunBlock ());
        }
        AfterExec();
        yield return null;
    }
    public override void ToUI () {
        operation = op.text;
        uiText.text = operation;

    }
    public override void UpdateUI (bool isOk) {
        if(isOk){
            oldOp = op.text;
            ToUI();
        } else {
            op.text = oldOp;
        }
    }
    public override bool Compile () {
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

    public override void Reset () {
        ToUI();
        return;
    }
    public override void SetNextBlock (TerminalBlocks block, ConnectionPoint.ConnectionDirection cd) {
        if (cd == ConnectionPoint.ConnectionDirection.South) {
            nextFalse = block;
        } else if (cd == ConnectionPoint.ConnectionDirection.North) {
            nextTrue = block;
        } else {
            nextBlock = block;
        }
    }
    public override TerminalBlocks GetNextBlock () {
        return null;
    }
    public override void HidefromCamera () {

    }
}