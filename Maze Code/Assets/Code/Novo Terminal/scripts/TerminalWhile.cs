using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalWhile : TerminalBlocks
{
    public int alternativeScopeId;
    public TerminalBlocks alternativeBlock;
    //MathOperation condition;
    public override IEnumerator RunBlock(){
        nextBlock.scopeId = scopeId;
        alternativeScopeId = SymbolTable.instance.CreateScope(scopeId);
        alternativeBlock.scopeId = alternativeScopeId;
        yield return null;
    }
    public override void ToUI (){

    }
    public override void UpdateUI (bool isOk){

    }
    public override bool Compile (){
        return true;
    }
    public override bool Reset (){
        return true;
    }
    public override void SetNextBlock (TerminalBlocks block){
        
    }
    public override TerminalBlocks GetNextBlock (){
        return null;
    }
    public override void HidefromCamera (){

    }
}
