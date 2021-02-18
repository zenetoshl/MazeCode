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

    public override IEnumerator RunBlock () {
        if (!isScopeCreated) {
            trueAlternativeScopeId = SymbolTable.instance.CreateScope (scopeId);
            falseAlternativeScopeId = SymbolTable.instance.CreateScope (scopeId);
            isScopeCreated = true;
        }

        bool resp = OperationManager.StartOperation (operation, TerminalEnums.varTypes.Bool, scopeId) == "True";

        if (nextTrue != null && resp) {
            nextTrue.scopeId = trueAlternativeScopeId;
            yield return StartCoroutine (nextTrue.RunBlock ());
        } else if (nextFalse != null && !resp) {
            nextFalse.scopeId = falseAlternativeScopeId;
            yield return StartCoroutine (nextFalse.RunBlock ());
        }
        yield return null;
        if (nextBlock != null) {
            nextBlock.scopeId = scopeId;
            yield return StartCoroutine (nextBlock.RunBlock ());
        }
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

    public override bool Reset () {
        return true;
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