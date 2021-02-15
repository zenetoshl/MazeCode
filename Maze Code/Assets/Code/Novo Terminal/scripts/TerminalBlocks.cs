using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

abstract public class TerminalBlocks : MonoBehaviour {
    public Image ShadowError;
    public Image ShadowExec;
    public int angle = 0;
    private bool initialized = false;
    public int scopeId;
    public TerminalBlocks nextBlock = null;
    public TextMeshProUGUI uiText;
    public GameObject windowGO;
    public LeanWindow window = null;

    public abstract IEnumerator RunBlock ();
    public abstract void ToUI ();
    public abstract void SetNextBlock (TerminalBlocks block, ConnectionPoint.ConnectionDirection cd);
    public abstract TerminalBlocks GetNextBlock ();
    public abstract void UpdateUI (bool isOk);
    public abstract bool Compile ();
    public abstract bool Reset ();
    public abstract void HidefromCamera ();

    public bool MarkError (bool b) {
        ShadowError.enabled = !b;
        return b;
    }

    public bool MarkExec (bool b) {
        ShadowExec.enabled = !b;
        return b;
    }

    private void Start () {
        Debug.Log("oi");
        if (windowGO == null) return;

        GameObject terminal = GameObject.Find ("/Terminal");
        Debug.Log("oi");
        GameObject go = Instantiate (windowGO, terminal.transform);
        Debug.Log("oi");
        window = go.transform.GetComponent<LeanWindow> ();
        Debug.Log("oi");
    }

    public void TurnOn () {
        if (window == null) return;

        window.TurnOn ();
    }
}