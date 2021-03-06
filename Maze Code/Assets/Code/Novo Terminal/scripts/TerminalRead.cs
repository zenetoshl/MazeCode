﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TerminalRead : TerminalBlocks
{
    public string varName;

    private Var_Vet_Mat var;
    private string saveVarName;

    private void Start() {
        var = window.transform.Find ("Panel/var_vet_mat").GetComponent<Var_Vet_Mat> ();
    }

    public override IEnumerator RunBlock(){
        if(TerminalCancelManager.instance.cancel){
            yield return null;
        }
        saveVarName = varName;
        SymbolTable st = SymbolTable.instance;
        MarkExec();
        if(ValidationManager.instance.validationMode){
            IOManager.instance.ReadNext();
            st.SetValueFromString(varName, scopeId, IOManager.instance.input);
        } else {
            IOManager.instance.varName = varName;
            RunReadWindow.instance.TurnOn();
            yield return StartCoroutine(WaitRead());
            st.SetValueFromString(varName, scopeId, IOManager.instance.input);
        }
        IOManager.instance.input = "";
        IOManager.instance.varName = "---";
        yield return new WaitForSeconds(ExecTimeManager.instance.execTime);
        if (nextBlock != null  && !TerminalCancelManager.instance.cancel) {
            nextBlock.scopeId = scopeId;
            yield return StartCoroutine (nextBlock.RunBlock ());
        }
        varName = saveVarName;
        AfterExec();
        yield return null;
    }

    public IEnumerator WaitRead(){
        while(!IOManager.instance.readEnded){
            yield return null;
        }
        IOManager.instance.readEnded = false;
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
