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
    public GameObject begin;
    public GameObject runner;
    public LeanWindow myWindow;
    private BlocoInicial initBlock;

    public void OpenWindow () {
        myWindow.TurnOn ();
    }

    private void Start () {
        initBlock = begin.GetComponentInChildren<BlocoInicial> ();
        myWindow.transform.Find("UI_Input/Panel/Buttons/Run Button").GetComponent<Runner> ().initBlock = initBlock;
    }
}