using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationManager : MonoBehaviour {
    public static Operationtree.Node IsBalanced (string input) {
        Dictionary<char, char> bracketPairs = new Dictionary<char, char> () { { '(', ')' }
        };

        Stack<char> brackets = new Stack<char> ();
        input = RemoveSpaces(input);

        try {
            // Iterate through each character in the input string
            for (int i = 0; i < input.Length; i++) {
                // check if the character is one of the 'opening' brackets
                if (input[i] == '(') {
                    if (i > 0 && brackets.Count == 0) {
                        return ( new Operationtree.Node(RemoveSpaces(input.Substring (0, i - 3)),RemoveSpaces(input.Substring (i - 3, 3)), RemoveSpaces(input.Substring (i))));
                    }
                    // if yes, push to stack
                    brackets.Push (input[i]);
                } else
                    // check if the character is one of the 'closing' brackets
                    if (input[i] == ')') {
                        // check if the closing bracket matches the 'latest' 'opening' bracket
                        if (input[i] == ')') {
                            brackets.Pop ();
                            if (i > 0 && brackets.Count == 0) {
                                return ( new Operationtree.Node(RemoveSpaces(input.Substring (1, i - 1)),RemoveSpaces(input.Substring (i + 1, 3)), RemoveSpaces(input.Substring (i + 4))));
                            }
                        } else
                            // if not, its an unbalanced string
                            return ( new Operationtree.Node(RemoveSpaces(input.Substring (1, i - 5)),RemoveSpaces(input.Substring (i - 4, 3)), RemoveSpaces(input.Substring (i + 1, input.Length - i - 1))));
                    }
                else
                    // continue looking
                    continue;
            }
        } catch {
            // an exception will be caught in case a closing bracket is found, 
            // before any opening bracket.
            // that implies, the string is not balanced. Return false
            return null;
        }

        // Ensure all brackets are closed
        return ( new Operationtree.Node(RemoveSpaces(input)));
    }

    static string RemoveSpaces(string s){
        if(s[0] ==' '){
            s = s.Substring(1);
        }
        if(s[s.Length - 1] ==' '){
            s = s.Substring(0, s.Length - 1);
        }
        return s;
    }
    // checar se existem parenteses e separá-los (1 + (2 + 3) - 1) + (4 + 2) - 3 => par1 + par2 - 3 => op1 (par1 + par2) - op2 (3)
    // 
    //
    //
    //
    //
    //
}