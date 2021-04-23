using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TerminalPrint : TerminalBlocks
{
    public string varName;

    private Var_Vet_Mat var;
    public static string printText = "";

    private string saveVarName;

    private void Start() {
        var = window.transform.Find("Panel/var_vet_mat").GetComponent<Var_Vet_Mat>();
    }
    
    public override IEnumerator RunBlock(){
        if(TerminalCancelManager.instance.cancel){
            yield return null;
        }
        saveVarName = varName;
        Debug.Log(varName);
        Debug.Log(scopeId);
        SymbolTable.instance.PrintSymbolTable();

        printText = SymbolTable.instance.GetValueFromString(varName, scopeId);
        MarkExec();

        IOManager.instance.Write(printText);
        
        yield return new WaitForSeconds(ExecTimeManager.instance.execTime);
        uiText.text = printText;
        printText = "";
        if (nextBlock != null && !TerminalCancelManager.instance.cancel) {
            nextBlock.scopeId = scopeId;
            yield return StartCoroutine (nextBlock.RunBlock ());
        }
        AfterExec();
        varName = saveVarName;
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
    
    public override void Reset (){
        ToUI();
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
