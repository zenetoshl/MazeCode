using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testeee : MonoBehaviour
{
    private void Start() {
        string resultInt = OperationManager.IsBalanced("(111 - (1 + 3) - 234) - 43 * (1 + 2220) + 3 - (2 + 3)", "int");
        string resultDouble = OperationManager.IsBalanced("(111.5 - (1 + 3) - 234) - 43 * (1 + 2220.3) + 3 - (2 + 3.23)", "double");
        Debug.Log(resultInt);
        Debug.Log(resultDouble);

        SymbolTable st = SymbolTable.instance;
        st.CreateScope();
        st.symbolTable[0].CreateVar("var1", "0", TerminalEnums.varTypes.Int, TerminalEnums.varStructure.Variable);
        st.symbolTable[0].CreateVar("var1", "2", TerminalEnums.varTypes.Int, TerminalEnums.varStructure.Variable);
        st.CreateScope(0);
        st.symbolTable[1].CreateVar("var1", "0", TerminalEnums.varTypes.Int, TerminalEnums.varStructure.Variable);
        st.CreateScope(1);
        st.symbolTable[2].CreateVar("var3", resultInt, TerminalEnums.varTypes.Int, TerminalEnums.varStructure.Variable);
        st.symbolTable[2].CreateVar("var4", resultDouble, TerminalEnums.varTypes.Double, TerminalEnums.varStructure.Variable);
        st.PrintSymbolTable();
    }
}
