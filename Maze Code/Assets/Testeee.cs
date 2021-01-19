using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testeee : MonoBehaviour
{
    private void Start() {
        SymbolTable st = SymbolTable.instance;
        st.CreateScope();
        st.symbolTable[0].CreateVar("var1", "0", TerminalEnums.varTypes.Int, TerminalEnums.varStructure.Variable);
        st.symbolTable[0].CreateVar("var1", "2", TerminalEnums.varTypes.Int, TerminalEnums.varStructure.Variable);
        string resultInt = OperationManager.StartOperation("(111 - (1 - 2 + var1) - 234) - 43 * (1 + 2220) + 3 - (2 + 3)", TerminalEnums.varTypes.Int, 0);
        string resultDouble = OperationManager.StartOperation("(111.5 - (var1 + 3) - 234) - 43 * (1 + 2220.3) + 3 - (2 + 3.23)",TerminalEnums.varTypes.Double, 0);
        string resultBoolean = OperationManager.StartOperation("!(var1 < 9) && True", TerminalEnums.varTypes.Bool, 0);
        Debug.Log(resultInt);
        Debug.Log(resultDouble);
        Debug.Log(resultBoolean);
    }
}
