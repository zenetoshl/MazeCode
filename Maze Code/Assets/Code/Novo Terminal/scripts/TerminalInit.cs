using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalInit : TerminalBlocks
{
    private void Start() {
        uiText.text = "Inicio";
    }
    public override IEnumerator RunBlock(){
        UIManager.ToggleRunMode(true);
        TerminalCancelManager.instance.OnStart();
        scopeId = SymbolTable.instance.CreateScope();
        MarkExec();
        TerminalPrint.printText = "";
        yield return new WaitForSeconds(ExecTimeManager.instance.execTime);
        //call Next
        if(nextBlock != null  && !TerminalCancelManager.instance.cancel){
            nextBlock.scopeId = scopeId;
            yield return StartCoroutine (nextBlock.RunBlock ());
        }
        Debug.Log(TerminalPrint.printText);
        UIManager.ToggleRunMode(false);
        AfterExec();
        yield return null;
    }
    public override void ToUI (){

    }
    public override void UpdateUI (bool isOk){

    }
    public override bool Compile (){
        return true;
    }
    public override void Reset (){
        return;
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
