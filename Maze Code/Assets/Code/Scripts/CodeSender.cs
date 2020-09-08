using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lean.Gui;
using RoslynCSharp;
using RoslynCSharp.Compiler;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CodeSender : MonoBehaviour {
    ScriptDomain domain = null;
    ScriptType type = null;
    ScriptProxy proxy = null;
    ScriptDomain domainFile = null;
    ScriptType typeFile = null;
    ScriptProxy proxyFile = null;
    private bool changed = false;
    private int _rightAnwser = 0;
    private string source;
    public static int rightAnwsersPercentage = 0;
    public static bool _completed = false;
    public DeliverWindowHandler window;
    public string correctCode;
    public Puzzle puzzle;

    public BlocoInicial initBlock;
    public List<Lister> inputs;
    [System.Serializable]
    public class Lister {
        public List<int> list = new List<int> ();
    }

    private void Start () {
        _completed = false;
        inputs = new List<Lister> ();
        BetterStreamingAssets.Initialize ();
        //ReadInputFiles (SceneManager.GetActiveScene ().name);
        domain = ScriptDomain.CreateDomain ("user");
        domainFile = ScriptDomain.CreateDomain ("correto");
    }

    public void RunRoslyn () {
        string sourceUser = ConnectionManager.ToCode (initBlock.GetComponent<RectTransform> ()) + "}}}";
        //string path = "term/scripts/" + SceneManager.GetActiveScene ().name + ".txt";
        Debug.Log (correctCode);
        inputs = puzzle.inputs;
        StartCoroutine (RunAsync (sourceUser, correctCode));
    }

    private void Update () {
        if (LoadingCircle.loading && !changed) {
            changed = true;
        }
        if (changed && !LoadingCircle.loading) {
            changed = false;

            Debug.Log (((_rightAnwser / ((inputs.Count == 0) ? 1 : inputs.Count)) * 100) + "% corretos");
        }
    }

    public IEnumerator RunAsync (string sourceUser, string sourceFile) {
        _rightAnwser = 0;
        LoadingCircle.UpdateLoad (true);
        AsyncCompileOperation compileRequest = domain.CompileAndLoadSourceAsync (sourceUser, ScriptSecurityMode.UseSettings);

        yield return compileRequest;

        Debug.Log ("iniciando file...");

        AsyncCompileOperation compileRequestFile = domainFile.CompileAndLoadSourceAsync (sourceFile, ScriptSecurityMode.UseSettings);

        yield return compileRequestFile;
        if (compileRequest.IsSuccessful == false || compileRequestFile.IsSuccessful == false) {
            // Get all errors
            foreach (CompilationError error in compileRequest.CompileDomain.CompileResult.Errors) {
                if (error.IsError == true) {
                    Debug.LogError (error.ToString ());
                } else if (error.IsWarning == true) {
                    Debug.LogWarning (error.ToString ());
                }
            }
            foreach (CompilationError error in compileRequestFile.CompileDomain.CompileResult.Errors) {
                if (error.IsError == true) {
                    Debug.LogError (error.ToString ());
                } else if (error.IsWarning == true) {
                    Debug.LogWarning (error.ToString ());
                }
            }
        } else {
            type = compileRequest.CompiledType;
            typeFile = compileRequestFile.CompiledType;
            proxy = type.CreateInstance (this.gameObject);
            proxyFile = typeFile.CreateInstance (this.gameObject);
            foreach (Lister l in inputs) {
                proxy.Fields["_inputs"] = l.list;
                proxyFile.Fields["_inputs"] = l.list;
                proxy.Call (initBlock.name);
                proxyFile.Call (initBlock.name);
                if ((string) proxy.Fields["_output"] == (string) proxyFile.Fields["_output"]) {
                    _rightAnwser++;
                }
            }
        }
        LoadingCircle.UpdateLoad (false);
        CompareOutputs ();
    }

    private void CompareOutputs () {
        rightAnwsersPercentage = ((_rightAnwser / ((inputs.Count == 0) ? 1 : inputs.Count)) * 100);
        window.CheckSend ();
        _completed = (_rightAnwser == puzzle.inputs.Count);
        Debug.Log("completed:" + _completed);
    }

    private List<string> GetFiles (string path) {
        int i = 1;
        string filePath = GenerateNewFilePath (path, i);
        List<string> filesList = new List<string> ();
        while (BetterStreamingAssets.FileExists (filePath)) {
            filesList.Add (filePath);
            i++;
            filePath = GenerateNewFilePath (path, i);
        }
        return filesList;
    }

    private string GenerateNewFilePath (string path, int index) {
        string filePath = System.IO.Path.Combine (path, index + ".txt");
        return filePath;
    }

    private void printList (List<Lister> lists) {
        foreach (Lister list in lists) {
            foreach (int i in list.list) {
                Debug.Log (i);
            }
        }
    }
}