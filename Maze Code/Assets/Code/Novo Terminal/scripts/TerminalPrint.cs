using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalPrint : TerminalBlocks
{
    public string var;
    public override IEnumerator RunBlock(){
        Debug.Log(var + " : " + SymbolTable.instance.GetValueFromString(var, scopeId));
        yield return null;
        if (nextBlock != null) {
            nextBlock.scopeId = scopeId;
            yield return StartCoroutine (nextBlock.RunBlock ());
        }
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
