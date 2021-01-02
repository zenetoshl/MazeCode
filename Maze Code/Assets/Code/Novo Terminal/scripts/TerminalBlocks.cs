using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

abstract public class TerminalBlocks : MonoBehaviour
{
    public Image ShadowError;
    public Image ShadowExec;
    public int angle = 0;
    private bool initialized = false;
    public int scopeId;
    private TerminalBlocks nextBlock = null;
    public TextMeshProUGUI uiText;
    public abstract IEnumerator RunBlock();
    public abstract void ToUI ();
    public abstract void SetNextBlock ();
    public abstract TerminalBlocks GetNextBlock ();
    public abstract void UpdateUI (bool isOk);
    public abstract bool Compile ();
    public abstract bool Reset ();
    public abstract void HidefromCamera ();

    public bool MarkError (bool b) {
        ShadowError.enabled = !b;
        return b;
    }
}
