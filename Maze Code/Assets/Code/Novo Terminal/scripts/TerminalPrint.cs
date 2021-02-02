using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalPrint : TerminalBlocks
{
    public string var;
    public static string printText = "";
    public override IEnumerator RunBlock(){
        printText = printText + " " + SymbolTable.instance.GetValueFromString(var, scopeId);

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
    public override void SetNextBlock (TerminalBlocks block, ConnectionPoint.ConnectionDirection cd){
        nextBlock = block;
    }
    public override TerminalBlocks GetNextBlock (){
        return null;
    }
    public override void HidefromCamera (){

    }
}
