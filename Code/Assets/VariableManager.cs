using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class VariableManager : MonoBehaviour
{
    static VariableManager _instance;
    public static VariableManager instance
    {
        get
        {
            if (!_instance)
            {
                //first try to find one in the scene
                _instance = FindObjectOfType<VariableManager>();

                if (!_instance)
                {
                    //if that fails, make a new one
                    GameObject go = new GameObject("_VariablesManager");
                    _instance = go.AddComponent<VariableManager>();

                    if (!_instance)
                    {
                        //if that still fails, we have a big problem;
                        Debug.LogError("Fatal Error: could not create VariableManager");
                    }
                }
            }

            return _instance;
        }
    }
    public enum Type
    {
        Int, Float
    }

    public enum StructureType
    {
        Matriz, Array, Variable
    }
    public class CodeVar
    {
        public Type type;
        public StructureType structType;

        public string name;

        public CodeVar(string _name, Type _type, StructureType _structureType)
        {
            name = _name;
            type = _type;
            structType = _structureType;
        }
    }

    List<CodeVar> vars = new List<CodeVar>();

    public bool Create(string name, Type type, StructureType structType)
    {
        if (isInList(name))
        {
            return false;
        }


        vars.Add(new CodeVar(name, type, structType));
        return true;
    }

    private bool isInList(string name)
    {
        foreach (CodeVar var in vars)
        {
            if (var.name == name)
            {
                return true;
            }
        }
        return false;
    }

    public List<string> ListNames(StructureType st){
        List<string> list = new List<string>();
        foreach (CodeVar var in vars)
        {
            if(var.structType == st){
                list.Add(var.name);
            }
        }
        return list;
    }
}

