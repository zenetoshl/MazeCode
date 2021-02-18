using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TerminalPrint : TerminalBlocks
{
    public string varName;

    private Var_Vet_Mat var;
    public static string printText = "";
    public override IEnumerator RunBlock(){
        printText = printText + " " + SymbolTable.instance.GetValueFromString(varName, scopeId);

        yield return null;
        if (nextBlock != null) {
            nextBlock.scopeId = scopeId;
            yield return StartCoroutine (nextBlock.RunBlock ());
        }
        yield return null;
    }
    public override void ToUI (){
        varName = var.GetText();
        uiText.text = varName;
    }
    public override void UpdateUI (bool isOk){
        if(isOk){
            var.SaveConfig();
            ToUI();
        } else {
            var.ResetConfig();
        }
    }
    public override bool Compile (){
        List<string> scope = VariableManager.GetScope(this.GetComponent<RectTransform>());
        bool noError = true;
        if(!(uiText.text != "---"))
        {
            ErrorLogManager.instance.CreateError("Bloco não inicializado corretamente");
            noError = MarkError(false);
        }
        if(!var.Compile (scope)){
            ErrorLogManager.instance.CreateError("Variavel nao existe no escopo deste bloco");
            noError = MarkError(false);
        }
        MarkError(noError);
        return noError;
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
