using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class ToggleManager : MonoBehaviour
{
    public GameObject dropdown;
    public GameObject textInput;
    public Toggle toggle;
    public TMP_Dropdown TMPdropdown;
    public TMP_InputField TMPinput;
    public TextMeshProUGUI tmpUGUI;

    private string lastName;
    private string lastValue;
    private bool lastToggle;
    private bool changed = false; 

    private void Start() {
        UpdateText();
        SaveConfig();
    }

    public void Toggle(){
        bool b = toggle.isOn;
        dropdown.SetActive(b);
        textInput.SetActive(!b);
        TMPinput.interactable = !b;
        TMPdropdown.interactable = b;    
    }

    public string GetActiveText(){
        if(TMPdropdown.interactable){
            return tmpUGUI.text;
        } else {
            return TMPinput.text;
        }
    }

    public void SaveConfig(){
        lastName = tmpUGUI.text;
        lastValue = TMPinput.text;
        lastToggle = toggle.isOn;
    }

    private int FindByText(string name){
        for(int i = 0; i <= TMPdropdown.options.Count - 1; i++){
            if (TMPdropdown.options[i].text == name){
                return i;
            }
        }
        return 0;
    }

    public void ResetConfig(){
        TMPdropdown.value = FindByText(lastName);
        TMPinput.text = lastValue;
        toggle.isOn = lastToggle;
    }

    private void Update()
    {
        if ((!TMPdropdown.interactable && changed)){
            changed = false;
        }
        if (VariableManager.changed || (TMPdropdown.interactable && !changed))
        {
            changed = true;
            UpdateText();
        }
    }

    private void UpdateText(){
            TMPdropdown.options.Clear();
            foreach (string option in VariableManager.ListNames(VariableManager.StructureType.Variable))
            {
                TMPdropdown.options.Add(new TMP_Dropdown.OptionData(option));
            }
            tmpUGUI.text = TMPdropdown.options[TMPdropdown.value].text;
            SaveConfig();
    }

    public bool Compile(List<string> scope){
        if(lastToggle){
            foreach(string str in scope){
                Debug.Log(tmpUGUI.text);
                if(str == tmpUGUI.text){
                    return true;
                }
            }
            return false;
        } else {
            return ( TMPinput.text != "" &&TMPinput.text != null );
        }
    }

}
