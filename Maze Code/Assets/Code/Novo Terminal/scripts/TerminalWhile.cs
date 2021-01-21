using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalWhile : TerminalBlocks {
    public int alternativeScopeId;
    public TerminalBlocks alternativeBlock;
    private bool isScopeCreated = false;
    public string boolOperation;
    //MathOperation condition;
    public override IEnumerator RunBlock () {
        if (!isScopeCreated) {
            alternativeScopeId = SymbolTable.instance.CreateScope (scopeId);
            isScopeCreated = true;
        }

        if (alternativeBlock != null) {
            alternativeBlock.scopeId = alternativeScopeId;

            while (OperationManager.StartOperation (boolOperation, TerminalEnums.varTypes.Bool, scopeId) == "True") {
                yield return StartCoroutine (alternativeBlock.RunBlock ());
            }
        }

        yield return null;
        //call Next
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