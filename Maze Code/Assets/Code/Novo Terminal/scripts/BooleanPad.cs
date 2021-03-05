using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BooleanPad : WindowPad {
    public TextMeshProUGUI operationText;
    private string[] operation = { };
    private bool isNumber;
    private bool hasComma;
    private int index = -1;
    private string bufferString;
    void Start () {
        isNumber = false;
    }

    public override void InsertToOperation (string charPut) {
        if (!isNumber && charPut == ",") return;
        Debug.Log (index);
        Debug.Log (operation);
        if (charPut == "!") {
            index = index + 1;
            if (index > 0) {
                if (!(IsOp (operation[index - 1]) || IsBoolOp (operation[index - 1])) && !(operation[index - 1] == "(")) {
                    if (index >= 2) {
                        if (IsBoolOp (operation[index - 2])) {
                            operation = InsertAt (operation, "&&", index);
                            index = index + 1;
                        } else {
                            operation = InsertAt (operation, "&&", index);
                            index = index + 1;
                        }
                    }
                }
            }
            operation = InsertAt (operation, "!", index);
            index = index + 1;
            operation = InsertAt (operation, ")", index);
            operation = InsertAt (operation, "(", index);
        } else if (charPut == "()") {
            isNumber = false;
            hasComma = false;
            index = index + 1;
            if (index > 0) {
                if (!(IsOp (operation[index - 1]) || IsBoolOp (operation[index - 1])) && !(operation[index - 1] == "(")) {
                    if (index >= 2) {
                        if (IsBoolOp (operation[index - 2])) {
                            operation = InsertAt (operation, "&&", index);
                            index = index + 1;
                        } else {
                            operation = InsertAt (operation, "&&", index);
                            index = index + 1;
                        }
                    }
                }
            }
            operation = InsertAt (operation, ")", index);
            operation = InsertAt (operation, "(", index);
        } else if (IsOp (charPut)) {
            if (index >= 2) {
                if (IsOp (operation[index - 2])) return;
            } else if (index <= operation.Length - 4) {
                if (IsOp (operation[index + 2])) return;
            }
            if (!IsOp (operation[index]) && !IsBoolOp (operation[index]) && !(operation[index] == "(")) {
                index = index + 1;
                bufferString = charPut;
                operation = InsertAt (operation, bufferString, index);
            } else return;
            isNumber = false;
            hasComma = false;
        } else if (IsBoolOp (charPut)) {
            if (index <= 1) {
                return;
            } else if (index == 2) {
                if (operation[0] == "!") {
                    return;
                }
            }

            if (IsBoolOp (operation[index - 1])) return;

            if (index <= operation.Length - 4) {
                if (IsBoolOp (operation[index + 3])) return;
            }
            if (!IsOp (operation[index]) && !IsBoolOp (operation[index]) && !(operation[index] == "(")) {
                index = index + 1;
                bufferString = charPut;
                operation = InsertAt (operation, bufferString, index);
            } else return;
            isNumber = false;
            hasComma = false;
        } else if (IsNumber (charPut)) {
            if (isNumber) {
                if (hasComma && charPut == ",") {
                    return;
                } else if (!hasComma && charPut == ",") {
                    hasComma = true;
                }
                bufferString = bufferString + charPut;
                operation = ReplaceAt (operation, bufferString, index);
            } else {
                isNumber = true;
                hasComma = false;
                index = index + 1;
                if (index > 0) {
                    if (!(IsOp (operation[index - 1]) || IsBoolOp (operation[index - 1])) && !(operation[index - 1] == "(")) {
                        if (index >= 2) {
                            if (IsBoolOp (operation[index - 2])) {
                                operation = InsertAt (operation, "==", index);
                                index = index + 1;
                            } else {
                                operation = InsertAt (operation, "&&", index);
                                index = index + 1;
                            }
                        }
                    }
                }
                bufferString = charPut;
                operation = InsertAt (operation, bufferString, index);
            }
        } else {
            isNumber = false;
            hasComma = false;
            index = index + 1;
            if (index > 0) {
                if (!(IsOp (operation[index - 1]) || IsBoolOp (operation[index - 1])) && !(operation[index - 1] == "(")) {
                    if (index >= 2) {
                        if (IsBoolOp (operation[index - 2])) {
                            operation = InsertAt (operation, "==", index);
                            index = index + 1;
                        } else {
                            operation = InsertAt (operation, "&&", index);
                            index = index + 1;
                        }
                    }
                }
            }
            bufferString = charPut;
            operation = InsertAt (operation, bufferString, index);
        }
        operationText.text = operation.Join (" ");
    }

    public override void Clear () {
        operationText.text = "";
        operation = new string[0];
        index = -1;
        isNumber = false;
        hasComma = false;
        bufferString = "";
    }

    public override void EraseAtIndex () {
        if (index == -1) {
            return;
        }

        if (operation[index] == "(") {
            int j = FindClosingBrackets (index);
            if (j != -1) {
                List<string> tmp2 = new List<string> (operation);
                tmp2.RemoveAt (j);
                operation = tmp2.ToArray ();
            }
        } else if (operation[index] == ")") {
            int j = FindOpeningBrackets (index);
            if (j != -1) {
                List<string> tmp2 = new List<string> (operation);
                tmp2.RemoveAt (j);
                operation = tmp2.ToArray ();
                index = index - 1;
            }
        }
        List<string> tmp = new List<string> (operation);
        tmp.RemoveAt (index);
        operation = tmp.ToArray ();

        isNumber = false;
        hasComma = false;
        bufferString = "";
        index = index - 1;
        operationText.text = operation.Join (" ");
    }

    private int FindClosingBrackets (int ind) {
        var stack = new Stack<int> ();
        for (int i = ind; i < operation.Length; i++) {
            switch (operation[i]) {
                case "(":
                    stack.Push (i);
                    break;
                case ")":
                    stack.Pop ();
                    if (stack.Count == 0) {
                        return i;
                    }
                    break;
                default:
                    break;
            }
        }
        return -1;
    }

    private int FindOpeningBrackets (int ind) {
        var stack = new Stack<int> ();
        for (int i = ind; i > 0; i--) {
            switch (operation[i]) {
                case ")":
                    stack.Push (i);
                    break;
                case "(":
                    stack.Pop ();
                    if (stack.Count == 0) {
                        return i;
                    }
                    break;
                default:
                    break;
            }
        }
        return -1;
    }

    public override string[] InsertAt (string[] arr, string item, int pos) {
        if (arr.Length == 0) {
            string[] newar = { item };
            return newar;
        }
        string[] newarr = new string[arr.Length + 1];
        for (int i = 0; i < arr.Length + 1; i++) {
            if (i < pos)
                newarr[i] = arr[i];
            else if (i == pos)
                newarr[i] = item;
            else
                newarr[i] = arr[i - 1];
        }
        return newarr;
    }

    public override string[] ReplaceAt (string[] arr, string item, int i) {
        arr[i] = item;
        return arr;
    }

    public bool IsNumber (string s) {
        switch (s) {
            case "0":
            case "1":
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
            case ",":
                return true;
            default:
                return false;
        }
    }

    public bool IsOp (string s) {
        switch (s) {
            case ">=":
            case ">":
            case "<=":
            case "<":
            case "==":
            case "!=":
                return true;
            default:
                return false;
        }
    }

    public bool IsBoolOp (string s) {
        switch (s) {
            case "&&":
            case "||":
                return true;
            default:
                return false;
        }
    }

    private void Print (string[] arr) {
        string s = "";
        for (int i = 0; i < arr.Length; i++) {
            s = s + " " + arr[i];
        }
        Debug.Log (s);
    }

    public bool CheckOperation (string[] arr) {
        for (int i = 0; i < arr.Length; i++) {
            if (IsOp (arr[i])) {
                if (i == 0 || i == arr.Length - 1) {
                    return false;
                } else if ((IsOp (arr[i + 1]) || IsBoolOp (arr[i + 1])) || !IsBoolOp (arr[i + 2])) {
                    return false;
                }
            } else if (IsBoolOp (arr[i])) {
                if (i == 0 || i == arr.Length - 1) {
                    return false;
                } else if (!IsOp (arr[i + 2]) || (IsBoolOp (arr[i + 1]) || IsOp (arr[i + 1]))) {
                    return false;
                }
            }
        }
        return true;
    }
}