using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOManager : MonoBehaviour
{
    static IOManager _instance;
    public static IOManager instance {
        get {
            if (!_instance) {
                //first try to find one in the scene
                _instance = FindObjectOfType<IOManager> ();

                if (!_instance) {
                    //if that fails, make a new one
                    GameObject go = new GameObject ("_VariablesManager");
                    _instance = go.AddComponent<IOManager> ();

                    if (!_instance) {
                        //if that still fails, we have a big problem;
                        Debug.LogError ("Fatal Error: could not create IOManager");
                    }
                }
            }

            return _instance;
        }
    }
    public string output = "";
    public string input;
    public string varName = "";
    public bool readEnded;

    public int i = 0;
    public string[] inputs;
    

    public void Write(string s){
        Debug.Log(s);
        if(output != ""){
            output = output + "\n" + s;
        } else output = s;
        Debug.Log(output);
    }

    public void Read(string s){
        input = s;
        readEnded = true;
    }

    public void ReadNext(){
        input = inputs[i];
        if(i != inputs.Length - 1)
            i++;
    }

    private void Start() {
        Reset();
        TerminalEventManager.instance.resetEvent.AddListener(Reset);
    }

    public void Reset(){
        output = "";
        input = "";
        i = 0;
        readEnded = false;
    }

}
