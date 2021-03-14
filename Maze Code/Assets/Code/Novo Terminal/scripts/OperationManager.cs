using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class OperationManager : MonoBehaviour {
    public static string StartOperation (string input, TerminalEnums.varTypes typeOp, int scope) {
        input = ClearVarNames (input, scope);
        return DoSubOperation (input, typeOp);
    }

    private static string ClearVarNames (string input, int scope) {
        SymbolTable st = SymbolTable.instance;
        bool begin = true;
        bool found = false;
        int beginVarName = -1;
        Debug.Log(input);
        for (int i = 0; i < input.Length; i++) {
            if (input[i] == '!' || input[i] == '(' || input[i] == ' ' || input[i] == ')' || i == input.Length - 1) {
                begin = true;
                if (((input[i] == ')' || input[i] == ' ') || i == input.Length - 1) && found) {
                    found = false;
                    if(i == input.Length - 1){
                        if (beginVarName > -1) { //achou o nome de uma variavel
                        input = ReplaceOp (input, beginVarName, i - beginVarName, st.GetValueFromString (input.Substring (beginVarName, i - beginVarName + 1), scope));
                        i = 0;
                        continue;
                    }
                    }
                    if (beginVarName > -1) { //achou o nome de uma variavel
                        input = ReplaceOp (input, beginVarName, i - beginVarName - 1, st.GetValueFromString (input.Substring (beginVarName, i - beginVarName), scope));
                        i = 0;
                        continue;
                    }
                }
                continue;
            } else if (((input[i] <= 'z' && input[i] >= 'a') || (input[i] <= 'Z' && input[i] >= 'A')) && begin) {
                found = true;
                beginVarName = i;
                
                    Debug.Log("achou um");
                if(i == input.Length - 1){
                    Debug.Log("entrou");
                        found = true;
                        input = ReplaceOp (input, beginVarName, i - beginVarName, st.GetValueFromString (input.Substring (beginVarName, i - beginVarName + 1), scope));
                        i = 0;
                        continue;
                }
            }
            Debug.Log(input[i]);
            begin = false;
        }
        Debug.Log(input);
        return input;
    }

    private static string DoSubOperation (string input, TerminalEnums.varTypes typeOp) {
        Dictionary<char, char> bracketPairs = new Dictionary<char, char> () { { '(', ')' }
        };
        Stack<char> brackets = new Stack<char> ();
        input = RemoveSpaces (input);
        int init = -1;
        // Iterate through each character in the input string
        for (int i = 0; i < input.Length; i++) {
            // check if the character is one of the 'opening' brackets
            if (input[i] == '(') {
                if (brackets.Count == 0)
                    init = i;
                // if yes, push to stack
                brackets.Push (input[i]);
            } else
                // check if the character is one of the 'closing' brackets
                if (brackets.Count > 0) {
                    // check if the closing bracket matches the 'latest' 'opening' bracket
                    if (input[i] == ')') {
                        brackets.Pop ();
                        if (brackets.Count == 0) {
                            input = ReplaceOp (input, init, i - init, DoSubOperation (RemoveSpaces (input.Substring (init + 1, i - init - 1)), typeOp));
                            i = -1;
                            continue;
                        }
                    }
                } else
                    continue;
        }
        // Ensure all brackets are closed
        Debug.Log(typeOp);
        if (typeOp == TerminalEnums.varTypes.Bool) {
            return ResolveBoolOp (input, typeOp);
        } else {
            return ResolveOp (input, typeOp);
        }

    }

    static string RemoveSpaces (string s) {
        if (s[0] == ' ') {
            s = s.Substring (1);
        }
        if (s[s.Length - 1] == ' ') {
            s = s.Substring (0, s.Length - 1);
        }
        return s;
    }

    static string ReplaceOp (string str, int init, int size, string newStr) {
        Debug.Log(newStr);
        return str.Replace (RemoveSpaces (str.Substring (init, size + 1)), newStr);
    }

    static string ResolveOp (string op, TerminalEnums.varTypes typeOp) {
        for (int i = 0; i < op.Length; i++) {
            if ((op[i] == '*' || op[i] == '/' || op[i] == '%')) {
                if (i < op.Length - 1) {
                    if (op[i + 1] == ' ') {
                        string subOp = FindOp (i, op);
                        op = op.Replace (RemoveSpaces (subOp), CalculateOp (RemoveSpaces (subOp), typeOp, op[i]));
                        i = -1;
                    }
                } else {
                    string subOp = FindOp (i, op);
                    op = op.Replace (RemoveSpaces (subOp), CalculateOp (RemoveSpaces (subOp), typeOp, op[i]));
                    i = -1;
                }

            }
        }
        for (int i = 0; i < op.Length; i++) {
            if ((op[i] == '+' || op[i] == '-')) {
                if (i < op.Length - 1) {
                    if (op[i + 1] == ' ') {
                        string subOp = FindOp (i, op);
                        op = op.Replace (RemoveSpaces (subOp), CalculateOp (RemoveSpaces (subOp), typeOp, op[i]));
                        i = -1;
                    }
                } else {
                    string subOp = FindOp (i, op);
                    op = op.Replace (RemoveSpaces (subOp), CalculateOp (RemoveSpaces (subOp), typeOp, op[i]));
                    i = -1;
                }
            }
        }
        return op;
    }

    static string ResolveBoolOp (string op, TerminalEnums.varTypes typeOp) {
        for (int i = 0; i < op.Length; i++) {
            if ((op[i] == '>' || op[i] == '<' || op[i] == '=')) {
                string subOp = FindOp (i, op);
                op = op.Replace (RemoveSpaces (subOp), CalculateBoolOp (subOp, typeOp, op[i]));
                i = -1;
            }
        }
        for (int i = 0; i < op.Length; i++) {
            if ((op[i] == '|' || op[i] == '&')) {
                string subOp = FindOp (i, op);
                op = op.Replace (RemoveSpaces (subOp), CalculateBoolOp (RemoveSpaces (subOp), typeOp, op[i]));
                i = -1;
            }
        }
        return op;
    }

    static string FindOp (int i, string op) {
        int init = 0, end = op.Length;
        int blankCont = 0;
        for (int j = i; j >= 0; j--) {
            if (op[j] == ' ') {
                blankCont++;
                if (blankCont >= 2) {
                    init = j + 1;
                    break;
                }
            }
        }
        blankCont = 0;
        for (int j = i; j < op.Length; j++) {
            if (op[j] == ' ') {
                blankCont++;
                if (blankCont >= 2) {
                    end = j;
                    break;
                }
            }
        }

        return op.Substring (init, end - init);
    }

    static string CalculateOp (string op, TerminalEnums.varTypes typeOp, char _) {
        string[] items = op.Split (' ');
        Debug.Log(op);
        if (items.Length < 3) {
            if (items[0] != "")
                return items[0];
            if (items[1] != "")
                return items[1];
            else return "";
        } else
        if (typeOp == TerminalEnums.varTypes.Int) {
            return CalculateInt (Convert.ToInt32 (double.Parse (items[0], CultureInfo.InvariantCulture)), items[1], Convert.ToInt32 (double.Parse (items[2], CultureInfo.InvariantCulture)));
        } else
        if (typeOp == TerminalEnums.varTypes.Double) {
            return CalculateDouble (double.Parse (items[0], CultureInfo.InvariantCulture), items[1], double.Parse (items[2], CultureInfo.InvariantCulture));
        } else {
            return items[0] + " " + items[2];
        }
        return null;
    }

    static string CalculateBoolOp (string op, TerminalEnums.varTypes typeOp, char _) {
        string[] items = op.Split (' ');
        if (items.Length < 3) {
            if (items[0] != "")
                return items[0];
            if (items[1] != "")
                return items[1];
            else return "";
        } else
        if (typeOp == TerminalEnums.varTypes.Bool) {
            return CalculateBool (items[0], items[1], items[2]);
        } else {
            return "True";
        }
    }

    static string CalculateBool (string var1, string op, string var2) {
        Debug.Log(var1);
        Debug.Log(var2);
        string solution = "True";
        if (op == ">") {
            if (var1[0] == '\"' || var2[0] == '\"') {
                solution = "False";
            } else {
                solution = BoolToString (double.Parse (var1, CultureInfo.InvariantCulture) > double.Parse (var2, CultureInfo.InvariantCulture));
            }
        }
        if (op == "<") {
            if (var1[0] == '\"' || var2[0] == '\"') {
                solution = "False";
            } else {
                solution = BoolToString (double.Parse (var1, CultureInfo.InvariantCulture) < double.Parse (var2, CultureInfo.InvariantCulture));
            }
        }
        if (op == ">=") {
            if (var1[0] == '\"' || var2[0] == '\"') {
                solution = "False";
            } else {
                solution = BoolToString (double.Parse (var1, CultureInfo.InvariantCulture) >= double.Parse (var2, CultureInfo.InvariantCulture));
            }
        }
        if (op == "<=") {
            if (var1[0] == '\"' || var2[0] == '\"') {
                solution = "False";
            } else {
                solution = BoolToString (double.Parse (var1, CultureInfo.InvariantCulture) <= double.Parse (var2, CultureInfo.InvariantCulture));
            }
        }
        if (op == "==") {
            if (var1[0] == '\"' || var2[0] == '\"') {
                solution = BoolToString (var1 == var2);
            } else {
                solution = BoolToString (double.Parse (var1, CultureInfo.InvariantCulture) == double.Parse (var2, CultureInfo.InvariantCulture));
            }
        }
        if (op == "!=") {
            if (var1[0] == '\"' || var2[0] == '\"') {
                solution = BoolToString (var1 != var2);
            } else {
                solution = BoolToString (double.Parse (var1, CultureInfo.InvariantCulture) != double.Parse (var2, CultureInfo.InvariantCulture));
            }
        }
        if (op == "&&") {
            bool b1 = NegateBool (var1);
            bool b2 = NegateBool (var2);
            solution = BoolToString (b1 && b2);
        }
        if (op == "||") {
            bool b1 = NegateBool (var1);
            bool b2 = NegateBool (var2);
            solution = BoolToString (b1 && b2);
        }
        return solution;
    }

    static bool NegateBool (string var) {
        if (var [0] == '!') {
            string s = var.Substring (1);
            if (s == "False") {
                return true;
            } else return false;
        }
        if (var == "True") {
            return true;
        } else {
            return false;
        }
    }

    static string BoolToString (bool b) {
        if (b) {
            return "True";
        }
        return "False";
    }

    static string CalculateInt (int var1, string op, int var2) {
        if (op == "*") {
            return Convert.ToString (var1 * var2, 10);
        }
        if (op == "/") {
            return Convert.ToString (var1 / var2, 10);
        }
        if (op == "%") {
            return Convert.ToString (var1 % var2, 10);
        }
        if (op == "+") {
            return Convert.ToString (var1 + var2, 10);
        }
        return Convert.ToString (var1 - var2, 10);
    }

    static string CalculateDouble (double var1, string op, double var2) {
        if (op == "*") {
            return Convert.ToString (var1 * var2,  CultureInfo.InvariantCulture);
        }
        if (op == "/") {
            return Convert.ToString (var1 / var2,  CultureInfo.InvariantCulture);
        }
        if (op == "%") {
            return Convert.ToString (var1 % var2,  CultureInfo.InvariantCulture);
        }
        if (op == "+") {
            return Convert.ToString (var1 + var2,  CultureInfo.InvariantCulture);
        }
        return Convert.ToString (var1 - var2,  CultureInfo.InvariantCulture);
    }
}