using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VariableManager : MonoBehaviour {
    static VariableManager _instance;
    public static VariableManager instance {
        get {
            if (!_instance) {
                //first try to find one in the scene
                _instance = FindObjectOfType<VariableManager> ();

                if (!_instance) {
                    //if that fails, make a new one
                    GameObject go = new GameObject ("_VariablesManager");
                    _instance = go.AddComponent<VariableManager> ();

                    if (!_instance) {
                        //if that still fails, we have a big problem;
                        Debug.LogError ("Fatal Error: could not create VariableManager");
                    }
                }
            }

            return _instance;
        }
    }
    public enum Type {
        Int,
        Float,
        Any
    }

    public enum StructureType {
        Matriz,
        Array,
        Variable
    }
    public class CodeVar {
        public Type type;
        public StructureType structType;

        public string name;

        public CodeVar (string _name, Type _type, StructureType _structureType) {
            name = _name;
            type = _type;
            structType = _structureType;
        }
    }

    private int _i = 0;

    private static List<CodeVar> vars = new List<CodeVar> ();

    public static bool changed = true;

    private void LateUpdate () {
        if (changed) {
            if (_i >= 1) {
                changed = false;
                _i = 0;
            } else
                _i++;
        }
    }

    public static bool ExistSameName (string name) {
        foreach (string option in VariableManager.ListNames ()) {
            if (option == name) {
                return true;
            }
        }
        return false;
    }

    public static bool Create (string name, Type type, StructureType structType) {
        if (isInList (name) && type == Type.Any) {
            return false;
        }
        vars.Add (new CodeVar (name, type, structType));
        PrintNames ();
        changed = true;
        return true;
    }

    private static bool isInList (string name) {
        foreach (CodeVar var in vars) {
            if (var.name == name) {
                return true;
            }
        }
        return false;
    }

    public static List<string> ListNames () {
        List<string> list = new List<string> ();
        foreach (CodeVar var in vars) {
            //if(var.structType == st){
            list.Add (var.name);
            //}
        }
        return list;
    }

    public static List<string> ListNames (Type type) {
        if (type == Type.Any) return ListNames ();
        List<string> list = new List<string> ();
        foreach (CodeVar var in vars) {
            if (var.type == type) {
                list.Add (var.name);
            }
        }
        return list;
    }

    public static List<string> ListNames (StructureType st) {
        List<string> list = new List<string> ();
        foreach (CodeVar var in vars) {
            if (var.structType == st) {
                list.Add (var.name);
            }
        }
        return list;
    }

    public static bool RemoveFromList (string name) {
        foreach (CodeVar var in vars) {
            if (var.name == name) {
                vars.Remove (var);
                changed = true;
                PrintNames ();
                return true;
            }
        }
        PrintNames ();
        return false;
    }

    private static void PrintNames () {
        string print = "";
        foreach (CodeVar var in vars) {
            print = print + " " + var.name;
        }
        Debug.Log (print);
    }

    public static string NextName () {
        string name = "";
        char nextChar = 'a';
        while (ExistsInList (name + nextChar)) {
            if (nextChar == 122) {
                name += nextChar;
                nextChar = 'a';
            } else {
                nextChar++;
            }
        }
        name += nextChar;
        return name;
    }

    private static bool ExistsInList (string a) {
        foreach (CodeVar c in vars) {
            if (c.name == a) {
                return true;
            }
        }
        return false;
    }

    public static List<string> GetScope (RectTransform rt) {
        List<string> scopeList = new List<string> ();
        GameObject obj = ConnectionManager.GetOtherSide (rt, ConnectionPoint.ConnectionDirection.West);
        BlocoVariavel variable;
        BlocoMatriz matriz;
        BlocoVetor vetor;
        while (obj != null) {
            obj = obj.transform.parent.gameObject;
            variable = obj.transform.GetComponent<BlocoVariavel> ();
            if (variable != null) {
                scopeList.Add (variable.GetVarName ());
            } else {
                vetor = obj.transform.GetComponent<BlocoVetor> ();
                if (vetor != null) {
                    scopeList.Add (vetor.GetVarName ());
                } else {
                    matriz = obj.transform.GetComponent<BlocoMatriz> ();
                    if (matriz != null) {
                        scopeList.Add (matriz.GetVarName ());
                    }
                }
            }
            obj = ConnectionManager.GetOtherSide (obj.transform.GetComponent<RectTransform> (), ConnectionPoint.ConnectionDirection.West);
        }
        print (scopeList);
        return scopeList;
    }

    private static void print (List<string> a) {
        string print = "";
        foreach (string s in a) {
            print += " " + s;
        }
        Debug.Log (print);
    }

    public static StructureType ReturnStructureType (string name) {
        foreach (CodeVar c in vars) {
            if (c.name == name) {
                return c.structType;
            }
        }
        return StructureType.Variable;
    }

    public static Type GetTypeOf (string name) {
        foreach (CodeVar c in vars) {
            if (c.name == name) {
                return c.type;
            }
        }
        return Type.Float;
    }
}