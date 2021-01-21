using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalFor : TerminalBlocks {
    public int alternativeScopeId;
    public TerminalBlocks alternativeBlock;

    public string varName;
    public string initialvalue;
    public string boolOperation;
    public string operation;
    private bool isScopeCreated = false;
    //MathOperation step;

    public override IEnumerator RunBlock () {
        if (!isScopeCreated) {
            alternativeScopeId = SymbolTable.instance.CreateScope (scopeId);
            isScopeCreated = true;
        }

        if (alternativeBlock != null) {
            SymbolTable st = SymbolTable.instance;
            alternativeBlock.scopeId = alternativeScopeId;
            //criar variavel do for com o valor inicial
            st.symbolTable[alternativeScopeId].CreateVar (varName, OperationManager.StartOperation (operation, TerminalEnums.varTypes.Int, alternativeScopeId), TerminalEnums.varTypes.Int);
            //execução do for
            while (OperationManager.StartOperation (operation, TerminalEnums.varTypes.Bool, alternativeScopeId) == "True") {
                //roda o proximo bloco
                yield return StartCoroutine (alternativeBlock.RunBlock ());
                //passo do for
                st.SetValueFromString (varName, alternativeScopeId, OperationManager.StartOperation (operation, st.GetVarType (varName, alternativeScopeId), alternativeScopeId));
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