using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testeee : MonoBehaviour
{
    private void Start() {
        SymbolTable st = SymbolTable.instance;
        st.CreateScope();
        st.symbolTable[0].CreateVar("mat", "1,2,3,4,5,6", TerminalEnums.varTypes.Int, 2, 3);
        st.symbolTable[0].CreateVar("arr", "2,30", TerminalEnums.varTypes.Int, 2);
        st.symbolTable[0].CreateVar("var1", "2", TerminalEnums.varTypes.Int);
        st.symbolTable[0].CreateVar("var2", "1", TerminalEnums.varTypes.Int);
        string resultInt = OperationManager.StartOperation("(111 - (1 - 2 + var1) - 234) - 43 * (1 + 2220) + mat[1][0] - (2 + 3)", TerminalEnums.varTypes.Int, 0);
        string resultDouble = OperationManager.StartOperation("(111.5 - (var1 + 3) - 204 + arr[var2]) - 43 * (1 + 2220.3) + 3 - (2 + 3.23)",TerminalEnums.varTypes.Double, 0);
        string resultBoolean = OperationManager.StartOperation("!(var1 < 9) && True", TerminalEnums.varTypes.Bool, 0);
        Debug.Log(resultInt);
        Debug.Log(resultDouble);
        Debug.Log(resultBoolean);
    }
}
