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
    public string output;
    public string input;
    public string varName = "";
    public bool readEnded;
    

    public void Write(string s){
        output = output + "\n" + s;
    }

    public void Read(string s){
        input = s;
        readEnded = true;
    }

    private void Start() {
        Reset();
    }

    public void Reset(){
        output = "";
        input = "";
        readEnded = false;
    }

}
