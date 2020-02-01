using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class ToggleManager : MonoBehaviour
{
    public GameObject dropdown;
    public GameObject textInput;
    private TMP_Dropdown TMPdropdown;
    private TMP_InputField TMPinput;

    private void Start() {
        TMPdropdown = dropdown.GetComponent<TMP_Dropdown>();
        TMPinput = textInput.GetComponent<TMP_InputField>();
    }

    public void toggle(){
        dropdown.SetActive(!TMPdropdown.interactable);
        textInput.SetActive(!TMPinput.interactable);
        TMPinput.interactable = !TMPinput.interactable;
        TMPdropdown.interactable = !TMPdropdown.interactable;    
    }
}
