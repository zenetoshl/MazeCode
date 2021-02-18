using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerminalFor : TerminalBlocks {
    public int alternativeScopeId;
    public TerminalBlocks alternativeBlock;

    public string varName;
    public string initialvalue;
    public string operation;
    private bool isScopeCreated = false;
    //MathOperation step;

    private Var_Vet_Mat var;
    private TMP_InputField initial;
    private TMP_InputField end;
    private TextMeshProUGUI op;

    private string oldOp;
    private string oldEnd;
    private string oldInitial;

    public override IEnumerator RunBlock () {
        if (!isScopeCreated) {
            alternativeScopeId = SymbolTable.instance.CreateScope (scopeId);
            isScopeCreated = true;
        }

        if (alternativeBlock != null) {
            SymbolTable st = SymbolTable.instance;
            alternativeBlock.scopeId = alternativeScopeId;
            //criar variavel do for com o valor inicial
            st.symbolTable[alternativeScopeId].CreateVar (varName, OperationManager.StartOperation (initialvalue, TerminalEnums.varTypes.Int, alternativeScopeId), TerminalEnums.varTypes.Int);
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
        varName = var.GetText();
        initialvalue = initial.text;
        operation = var.GetText() + " " + op.text + " " + end.text;
        uiText.text = operation;

    }
    public override void UpdateUI (bool isOk) {
        if(isOk){
            var.SaveConfig();
            oldOp = op.text;
            oldEnd = end.text;
            oldInitial = initial.text;
            Bloco.changed = true;
            ToUI();
        } else {
            var.ResetConfig();
            op.text = oldOp;
            initial.text = oldInitial;
            end.text = oldEnd;
        }
    }

    public override bool Compile () {
        bool noError = true;
        if(!(uiText.text != "---"))
        {
            ErrorLogManager.instance.CreateError("Bloco não inicializado corretamente");
            noError = MarkError(false);
        }
        if(!CheckVars()){
            ErrorLogManager.instance.CreateError("Variavel nao existe no escopo deste bloco");
            noError = MarkError(false);
        }
        if(!CheckString(op.text)){
            ErrorLogManager.instance.CreateError("Operador invalido");
            noError = MarkError(false);
        }
        if(!CheckString(initial.text)){
            ErrorLogManager.instance.CreateError("Variavel inicial invalida");
            noError = MarkError(false);
        }
        if(!CheckString(end.text)){
            ErrorLogManager.instance.CreateError("Variavel final invalida");
            noError = MarkError(false);
        }
        if(!(int.Parse(initial.text) <= int.Parse(end.text))){
            ErrorLogManager.instance.CreateError("valor inicial é maior que o final");
            noError = MarkError(false);
        }
        MarkError(noError);
        return noError;
    }

    private bool CheckString(string s){
        return s != null && s != "";
    }
    private bool CheckVars(){
        List<string> scope = VariableManager.GetScope(this.GetComponent<RectTransform>());
        return var.Compile(scope);
    }

    public override bool Reset () {
        return true;
    }

    public override void SetNextBlock (TerminalBlocks block, ConnectionPoint.ConnectionDirection cd) {
        if (cd == ConnectionPoint.ConnectionDirection.South) {
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