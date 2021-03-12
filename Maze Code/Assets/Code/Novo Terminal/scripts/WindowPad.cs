using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Lean.Gui;

public abstract class WindowPad : MonoBehaviour {

    public TextMeshProUGUI operationText;
    public TextMeshProUGUI errorText;
    public string[] operation = { };

    public LeanWindow window;

    public abstract void InsertToOperation (string charPut);

    public abstract void Clear ();

    public abstract void EraseAtIndex ();

    public abstract string[] InsertAt (string[] arr, string item, int pos);

    public abstract string[] ReplaceAt (string[] arr, string item, int i);

    public bool CheckOperation(){
        int i = operation.Length - 1;
        if(operation[i] == "+" || operation[i] == "-" || operation[i] == "*" || operation[i] == "/" || operation[i] == "%" || operation[i] == ">" || operation[i] == "<" || operation[i] == ">=" || operation[i] == "<=" || operation[i] == "==" || operation[i] == "!=" || operation[i] == "&&" || operation[i] == "||"){
            return false;        
        }
        for (int j = 0; j < operation.Length - 2; j++) {
            if(operation[j] == "+" || operation[j] == "-" || operation[j] == "*" || operation[j] == "/" || operation[j] == "%" || operation[j] == ">" || operation[j] == "<" || operation[j] == ">=" || operation[j] == "<=" || operation[j] == "==" || operation[j] == "!=" || operation[j] == "&&" || operation[j] == "||"){
            j = j + 1;
                if(operation[j] == "+" || operation[j] == "-" || operation[j] == "*" || operation[j] == "/" || operation[j] == "%" || operation[j] == ">" || operation[j] == "<" || operation[j] == ">=" || operation[j] == "<=" || operation[j] == "==" || operation[j] == "!=" || operation[j] == "&&" || operation[j] == "||"){
                    return false;        
                }
                j = j - 1;       
            }
        }
        return true;
    }

    public void CloseWindow(){
        if(CheckOperation()){
            window.transform.GetComponent<BlockWindow>().OnOk();
            errorText.gameObject.SetActive(false);
            window.TurnOff();
        } else {
            errorText.gameObject.SetActive(true);
        }
    }
}