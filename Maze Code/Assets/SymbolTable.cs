using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolTable : MonoBehaviour {
    public class Symbol {
        public string varValue;
        public TerminalEnums.varTypes varType;
        public TerminalEnums.varStructure varStructure;

        public Symbol (string value, TerminalEnums.varTypes type, TerminalEnums.varStructure structure) {
            varStructure = structure;
            varType = type;
            varValue = value;
        }
    }

    public class Table {
        public Dictionary<string, Symbol> scope;
        public int parent;

        public Table () {
            parent = -1;
            scope = new Dictionary<string, Symbol> ();
        }

        public Table (int fatherScope) {
            if (fatherScope < 0) {
                parent = -1;
            } else {
                parent = fatherScope;
            }
            scope = new Dictionary<string, Symbol> ();
        }

        public bool CreateVar (string name, string value, TerminalEnums.varTypes type, TerminalEnums.varStructure structure) {
            try {
                scope.Add (name, new Symbol (value, type, structure));
                return true;
            } catch (ArgumentException) {
                scope[name] = new Symbol (value, type, structure);
                return true;
            }

            return false;
        }

        public bool ModifyVarValue (string name, string value) {
            try {
                scope[name].varValue = value;
                return true;
            } catch (ArgumentException) {
                Debug.Log ("var not found");
                return false;
            }
            return false;
        }
        
        public string GetVarValue (string name) {
            try {
                return scope[name].varValue;
            } catch (ArgumentException) {
                Debug.Log ("var not found");
                return null;
            }
            return null;
        }

        public void DeleteVar(string name){
            scope.Remove(name);
        }

        public void PrintTable () {
            Debug.Log("Father = " + parent);
            foreach (KeyValuePair<string, Symbol> kvp in scope) {
                Debug.Log ("Key = " + kvp.Key + " Value = " + kvp.Value.varValue + " Type = " + kvp.Value.varType);
            }
        }
    }

    public static SymbolTable instance;
    public List<Table> symbolTable;

    private void Awake () {
        instance = this;
    }

    private void Start () {
        symbolTable = new List<Table> ();
    }

    public void CreateScope () {
        symbolTable.Add (new Table ());
    }

    public void CreateScope (int outerScope) {
        symbolTable.Add (new Table (outerScope));
    }

    public void PrintSymbolTable () {
        int i = 0;
        foreach (Table t in symbolTable) {
            Debug.Log (i + " - ");
            t.PrintTable();
            i++;
        }
    }

    public bool CreateVar (int scope, string name, string value, TerminalEnums.varTypes type, TerminalEnums.varStructure structure) {
        if(scope < symbolTable.Count){
            return symbolTable[scope].CreateVar(name, value, type, structure);
        } else return false;
    }

    public int FindVarScope(string name, int startScope){
        int searchScope = startScope;
        while (searchScope >= 0){
            string s = symbolTable[searchScope].GetVarValue(name);
            if(s != null){
                return searchScope;
            } else searchScope = symbolTable[searchScope].parent;
        }
        return -1;
    }
}