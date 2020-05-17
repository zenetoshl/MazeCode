using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Num_Var_Vet_Mat : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject varVetMat;
    public GameObject txtInput;
    public Toggle toggle;
    private Var_Vet_Mat vvm;
    private TMP_InputField TMPinput;

    private bool lastToggle;
    private string lastValue;

    private void Start() {
        vvm = varVetMat.GetComponent<Var_Vet_Mat>();
        TMPinput = txtInput.GetComponentInChildren<TMP_InputField>();
        SaveConfig();
        lastToggle = true;
    }

    public void Toggle(){
        bool b = toggle.isOn;
        varVetMat.SetActive(b);
        txtInput.SetActive(!b);
        TMPinput.interactable = !b;
        Debug.Log(b);
    }

    public string GetActiveText(){
        if(!TMPinput.interactable){
            return vvm.GetText();
        } else {
            return TMPinput.text;
        }
    }

    public void ResetConfig(){
        vvm.ResetConfig();
        toggle.isOn = lastToggle;
        TMPinput.text = lastValue;
    }

    public string GetName(){
        return lastToggle ? vvm.GetName() : TMPinput.text;
    }

    public void SaveConfig(){
        vvm.SaveConfig();
        lastValue = TMPinput.text;
        lastToggle = toggle.isOn;
    }

    public bool GetToggle(){
        return lastToggle;
    }

    public bool Compile(List<string> scope){
        if(toggle.isOn){
            return vvm.Compile(scope);
        } else return (TMPinput.text != "" && TMPinput.text != null);
    }
}
