using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalIf : TerminalBlocks {
    public string operation;
    public int trueAlternativeScopeId;
    public int falseAlternativeScopeId;
    public TerminalBlocks nextTrue = null;
    public TerminalBlocks nextFalse = null;
    private bool isScopeCreated = false;

    public override IEnumerator RunBlock () {
        if (!isScopeCreated) {
            trueAlternativeScopeId = SymbolTable.instance.CreateScope (scopeId);
            falseAlternativeScopeId = SymbolTable.instance.CreateScope (scopeId);
            isScopeCreated = true;
        }

        bool resp = OperationManager.StartOperation(operation, TerminalEnums.varTypes.Bool, scopeId) == "True";
        
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

    }
    public override void UpdateUI (bool isOk) {

    }
    public override bool Compile () {
        return true;
    }
    public override bool Reset () {
        return true;
    }
    public override void SetNextBlock (TerminalBlocks block) {

    }
    public override TerminalBlocks GetNextBlock () {
        return null;
    }
    public override void HidefromCamera () {

    }
}