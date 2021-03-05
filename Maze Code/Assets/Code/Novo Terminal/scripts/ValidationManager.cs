using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;

public class ValidationManager : MonoBehaviour
{
    [System.Serializable] public class ResultItem{
        public string[] input;
        public string output;

        public ResultItem(string[] _input, string _output){
            input = _input;
            output = _output;
        }
    }

    static ValidationManager _instance;
    public static ValidationManager instance {
        get {
            if (!_instance) {
                //first try to find one in the scene
                _instance = FindObjectOfType<ValidationManager> ();

                if (!_instance) {
                    //if that fails, make a new one
                    GameObject go = new GameObject ("_VariablesManager");
                    _instance = go.AddComponent<ValidationManager> ();

                    if (!_instance) {
                        //if that still fails, we have a big problem;
                        Debug.LogError ("Fatal Error: could not create ValidationManager");
                    }
                }
            }

            return _instance;
        }
    }
    public bool validationMode;
    public bool hasError = false;
    public GameObject correctWindow;
    public LeanWindow wrongWindow;

    public TerminalInit ti;

    public List<ResultItem> results;

    public IEnumerator Validate(){
        hasError = false;
        validationMode = true;
        foreach(ResultItem res in results){
            ExecTimeManager.instance.MinExecTime();
            IOManager.instance.inputs = res.input;
            yield return StartCoroutine(ti.RunBlock());

            string outp = IOManager.instance.output;
            if(res.output != outp){
                validationMode = false;
                hasError = true;
                wrongWindow.TurnOn();
                yield break;
            }
            TerminalEventManager.instance.resetEvent.Invoke();
        }
        if(!hasError){
            correctWindow.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            CodeToMaze.instance.ReturnToMaze();
        }
        validationMode = false;
    }

    public void StartValidation(){
        StartCoroutine(Validate());

    }
}
