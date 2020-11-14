using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Lean.Gui;
using RoslynCSharp;
using RoslynCSharp.Compiler;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Runner : MonoBehaviour {

    ScriptType type = null;
    ScriptProxy proxy = null;

    public BlocoInicial initBlock;
    public TextMeshProUGUI outputText;
    public Transform ListParent;

    public void RunTest () {
        string source = ConnectionManager.ToCode (initBlock.GetComponent<RectTransform> ()) + "}}}";
        ///teste
        //string source = "using System;using System.Collections.Generic;using UnityEngine;using System.Text;namespace teste { class MazeCode {int _i = 0;string _output = \"\";List<int> _inputs = new List<int>() {};void teste(){var a = 3.0f;a = float.Parse (\"3\");a = a*a/6f;_output += a;}}}";
        StartCoroutine (RunAsync (source, outputText, TextInputInstantiator.ToListInt (ListParent),TextInputInstantiator.ToListFloat (ListParent) ));
    }

    public IEnumerator RunAsync (string source, TextMeshProUGUI textUI, List<int> list, List<double> listD) {
        LoadingCircle.UpdateLoad(true);
        Debug.Log (source);
        ScriptDomain domain = ScriptDomain.CreateDomain ("resposta");
        AsyncCompileOperation compileRequest = domain.CompileAndLoadSourceAsync (source, ScriptSecurityMode.UseSettings);
        // Wait for operation to complete
        yield return compileRequest;
        // Check for compiler errors
        if (compileRequest.IsSuccessful == false) {
            // Get all errors
            foreach (CompilationError error in compileRequest.CompileDomain.CompileResult.Errors) {
                if (error.IsError == true) {
                    Debug.LogError (error.ToString ());
                    textUI.text = error.ToString ();
                } else if (error.IsWarning == true) {
                    Debug.LogWarning (error.ToString ());
                }
            }
        } else {
            type = compileRequest.CompiledType;
            proxy = type.CreateInstance (this.gameObject);
            proxy.Fields["_inputs"] = list;
            proxy.Fields["_Dinputs"] = listD;
            proxy.Call (initBlock.name);
            if((string) proxy.Fields["_loopError"] != null){
                textUI.text = (string) proxy.Fields["_loopError"];
            } else {
                textUI.text = (string) proxy.Fields["_output"];
            }
        }
        LoadingCircle.UpdateLoad(false);
    }
}