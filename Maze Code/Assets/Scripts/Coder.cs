using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using RoslynCSharp;
using RoslynCSharp.Compiler;
using TMPro;
using UnityEngine;

public class Coder : MonoBehaviour {
    private TextMeshProUGUI inputText;
    private TextMeshProUGUI outputText;
    public LeanWindow prefab;
    public GameObject begin;
    public GameObject runner;
    private LeanWindow myWindow;
    private BlocoInicial initBlock;

    public void OpenWindow () {
        myWindow.TurnOn ();
    }

    private void Start () {
        GameObject terminal = GameObject.Find ("Terminal");
        myWindow = Instantiate (prefab, new Vector3 (Screen.width / 2, Screen.height / 2, 0), Quaternion.identity);
        myWindow.transform.SetParent (terminal.transform, true);
        initBlock = begin.GetComponentInChildren<BlocoInicial> ();
        myWindow.transform.Find("UI_Input/Panel/Buttons/Run Button").GetComponent<Runner> ().initBlock = initBlock;
    }
}