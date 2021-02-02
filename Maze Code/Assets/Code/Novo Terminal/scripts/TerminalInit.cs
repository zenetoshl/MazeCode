using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalInit : TerminalBlocks
{
    public override IEnumerator RunBlock(){
        scopeId = SymbolTable.instance.CreateScope();
        TerminalPrint.printText = "";
        yield return null;
        //call Next
        if(nextBlock != null){
            nextBlock.scopeId = scopeId;
            yield return StartCoroutine (nextBlock.RunBlock ());
            Debug.Log(TerminalPrint.printText);
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
        Debug.Log(block);
        nextBlock = block;
    }
    public override TerminalBlocks GetNextBlock (){
        return null;
    }
    public override void HidefromCamera (){

    }
}
