using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

abstract public class Bloco : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    public Image ShadowError;
    public abstract string ToCode();
    public abstract void UpdateUI(bool isOk);
    public abstract bool Compile();
    public abstract void ToUI();
    public static bool changed;
    private int cont = 0;

    private void Update() {
        if(changed){
            if(cont <= 2){
                if(uiText.text != "---")
                    ToUI();
                cont++;
            } else{
                Bloco.changed = false;
                cont = 0;
            }
        }
    }

    public bool MarkError(bool b){
        ShadowError.enabled = !b;
        return b;
    }
}
