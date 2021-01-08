using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operationtree {
    public class Node {
        Operationtree.Node left;
        Operationtree.Node right;
        string value;
        string operationSymbol;
        //no interno
        public Node (string s1, string s2, string s3) {
            left = OperationManager.IsBalanced (s1);
            operationSymbol = s2;
            right = OperationManager.IsBalanced (s3);
            value = null;
        }
        //no folha
        public Node (string s) {
            left = null;
            right = null;
            operationSymbol = null;
            value = SplitOperation (s); //resolver value depois
        }

        public string SplitOperation (string op) {
            string[] items = op.Split (' ');
            if (items.Length < 3) {
                return items[0];
            } else {
                if (items.Contains ("+")) {
                    string leftString = "";
                    string rightString = "";
                    bool found = false;
                    for (int i = items.GetLowerBound (0); i <= items.GetUpperBound (0); i++) {
                        if (!found) {
                            if (items[i] == "+") {
                                found = true;
                            } else {
                                leftString = leftString + " " + items[i];
                            }
                        } else {
                            rightString = rightString + " " + items[i];
                        }
                    }
                    left = OperationManager.IsBalanced (leftString);
                    right = OperationManager.IsBalanced (rightString);
                    operationSymbol = "+";
                    return null;
                }else if (items.Contains ("-")) {
                    string leftString = "";
                    string rightString = "";
                    bool found = false;
                    for (int i = items.GetLowerBound (0); i <= items.GetUpperBound (0); i++) {
                        if (!found) {
                            if (items[i] == "-") {
                                found = true;
                            } else {
                                leftString = leftString + " " + items[i];
                            }
                        } else {
                            rightString = rightString + " " + items[i];
                        }
                    }
                    left = OperationManager.IsBalanced (leftString);
                    right = OperationManager.IsBalanced (rightString);
                    operationSymbol = "-";
                    return null;
                }
                else if (items.Contains ("*")) {
                    string leftString = "";
                    string rightString = "";
                    bool found = false;
                    for (int i = items.GetLowerBound (0); i <= items.GetUpperBound (0); i++) {
                        if (!found) {
                            if (items[i] == "*") {
                                found = true;
                            } else {
                                leftString = leftString + " " + items[i];
                            }
                        } else {
                            rightString = rightString + " " + items[i];
                        }
                    }
                    left = OperationManager.IsBalanced (leftString);
                    right = OperationManager.IsBalanced (rightString);
                    operationSymbol = "*";
                    return null;
                } else if (items.Contains ("/")) {
                    string leftString = "";
                    string rightString = "";
                    bool found = false;
                    for (int i = items.GetLowerBound (0); i <= items.GetUpperBound (0); i++) {
                        if (!found) {
                            if (items[i] == "/") {
                                found = true;
                            } else {
                                leftString = leftString + " " + items[i];
                            }
                        } else {
                            rightString = rightString + " " + items[i];
                        }
                    }
                    left = OperationManager.IsBalanced (leftString);
                    right = OperationManager.IsBalanced (rightString);
                    operationSymbol = "/";
                    return null;
                } else {
                    string leftString = "";
                    string rightString = "";
                    bool found = false;
                    for (int i = items.GetLowerBound (0); i <= items.GetUpperBound (0); i++) {
                        if (!found) {
                            if (items[i] == "%") {
                                found = true;
                            } else {
                                leftString = leftString + " " + items[i];
                            }
                        } else {
                            rightString = rightString + " " + items[i];
                        }
                    }
                    left = OperationManager.IsBalanced (leftString);
                    right = OperationManager.IsBalanced (rightString);
                    operationSymbol = "%";
                    return null;
                }
            }
        }

        public string ResolveOperation (string type) {
            if (value != null) {
                return value;
            } else {
                if (type == "int") {
                    int var1 = Convert.ToInt32 (double.Parse (left.ResolveOperation (type)));
                    int var2 = Convert.ToInt32 (double.Parse (right.ResolveOperation (type)));
                    string result = CalculateInt (var1, operationSymbol, var2);
                    return result;
                } else if (type == "double") {
                    return CalculateDouble (double.Parse (left.ResolveOperation (type)), operationSymbol, double.Parse (right.ResolveOperation (type)));
                } else { //string
                    return left.ResolveOperation (type) + right.ResolveOperation (type);
                }
            }
        }

        private string CalculateInt (int var1, string op, int var2) {
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

        private string CalculateDouble (double var1, string op, double var2) {
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
}