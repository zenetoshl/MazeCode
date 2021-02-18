using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TerminalWhile : TerminalBlocks {
    public int alternativeScopeId;
    public TerminalBlocks alternativeBlock;
    private bool isScopeCreated = false;
    public string operation;

    private TextMeshProUGUI op;

    private string oldOp;
    //MathOperation condition;
    public override IEnumerator RunBlock () {
        if (!isScopeCreated) {
            alternativeScopeId = SymbolTable.instance.CreateScope (scopeId);
            isScopeCreated = true;
        }

        if (alternativeBlock != null) {
            alternativeBlock.scopeId = alternativeScopeId;

            while (OperationManager.StartOperation (operation, TerminalEnums.varTypes.Bool, scopeId) == "True") {
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
        if(cd == ConnectionPoint.ConnectionDirection.South){
            alternativeBlock = block;
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