using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidationManager : MonoBehaviour
{
    public class ResultItem{
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

    public TerminalInit ti;

    public ResultItem[] results;

    private void Start() {
        //teste
        results = new ResultItem[1];
        results[0] = new ResultItem(new string[]{"10", "20"}, " 30");
    }

    public IEnumerator Validate(){
        hasError = false;
        validationMode = true;
        foreach(ResultItem res in results){
            ExecTimeManager.instance.MinExecTime();
            IOManager.instance.inputs = res.input;
            yield return StartCoroutine(ti.RunBlock());

            string outp = IOManager.instance.output;
            TerminalEventManager.instance.resetEvent.Invoke();
            if(res.output != outp){
                validationMode = false;
                hasError = true;
                Debug.Log("false");
                yield break;
            }
        }
        Debug.Log("deu certo meu camarada");
        validationMode = false;
    }
}
