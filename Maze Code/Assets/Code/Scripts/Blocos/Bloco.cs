using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

abstract public class Bloco : MonoBehaviour {
    public TextMeshProUGUI uiText;
    public Image ShadowError;
    public abstract string ToCode ();
    public abstract void UpdateUI (bool isOk);
    public abstract bool Compile ();
    public abstract void ToUI ();
    public static bool changed = false;
    private int cont = 0;
    private bool initialized = false;

    private void Update () {
        if (changed) {
            if (cont <= 2) {
                if (!initialized) {
                    if (this.uiText.text != "---") {
                        initialized = true;
                        ToUI ();
                    }
                }
                cont++;
            } else {
                Bloco.changed = false;
                cont = 0;
            }
        }
    }

    public bool MarkError (bool b) {
        ShadowError.enabled = !b;
        return b;
    }
}