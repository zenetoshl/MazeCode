using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationManager : MonoBehaviour {
    public static string IsBalanced (string input, string typeOp) {
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
                            input = ReplaceOp (input, init, i - init, IsBalanced (RemoveSpaces (input.Substring (init + 1, i - init - 1)), typeOp));
                            Debug.Log(input);
                            i = 0;
                            continue;
                        }
                    }
                } else
                    continue;
        }
        // Ensure all brackets are closed
        return ResolveOp (input, typeOp);
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
        return str.Replace (RemoveSpaces (str.Substring (init, size + 1)), newStr);
    }

    static string ResolveOp (string op, string typeOp) {
        for (int i = 0; i < op.Length; i++) {
            if ((op[i] == '*' || op[i] == '/' || op[i] == '%') && op[i + 1] == ' ') {
                string subOp = FindOp (i, op);
                op = op.Replace (RemoveSpaces (subOp), CalculateOp (subOp, typeOp, op[i]));
                i = 0;
            }
        }
        for (int i = 0; i < op.Length; i++) {
            if ((op[i] == '+' || op[i] == '-') && op[i + 1] == ' ') {
                string subOp = FindOp (i, op);
                op = op.Replace (RemoveSpaces (subOp), CalculateOp (RemoveSpaces (subOp), typeOp, op[i]));
                i = 0;
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

    static string CalculateOp (string op, string typeOp, char _) {
        Debug.Log(op);
        string[] items = op.Split (' ');
        if (items.Length < 3) {
            if (items[0] != "")
                return items[0];
            if (items[1] != "")
                return items[1];
            else return "";
        } else
        if (typeOp == "int") {
            return CalculateInt (Convert.ToInt32 (double.Parse (items[0])), items[1], Convert.ToInt32 (double.Parse (items[2])));
        } else
        if (typeOp == "double") {
            return CalculateDouble (double.Parse (items[0]), items[1], double.Parse (items[2]));
        } else {
            return items[0] + " " + items[2];
        }
        return null;
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
            return Convert.ToString (var1 * var2);
        }
        if (op == "/") {
            return Convert.ToString (var1 / var2);
        }
        if (op == "%") {
            return Convert.ToString (var1 % var2);
        }
        if (op == "+") {
            return Convert.ToString (var1 + var2);
        }
        return Convert.ToString (var1 - var2);
    }
}