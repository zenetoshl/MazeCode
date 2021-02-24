using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lean.Gui;
public class RunReadWindow : MonoBehaviour
{
    static RunReadWindow _instance;
    public static RunReadWindow instance {
        get {
            if (!_instance) {
                //first try to find one in the scene
                _instance = FindObjectOfType<RunReadWindow> ();

                if (!_instance) {
                    //if that fails, make a new one
                    GameObject go = new GameObject ("_VariablesManager");
                    _instance = go.AddComponent<RunReadWindow> ();

                    if (!_instance) {
                        //if that still fails, we have a big problem;
                        Debug.LogError ("Fatal Error: could not create RunReadWindow");
                    }
                }
            }

            return _instance;
        }
    }
    public TMP_InputField readText;
    public TextMeshProUGUI varName;
    // Start is called before the first frame update
    public void OnConfirm(){
        IOManager.instance.Read(readText.text);
        readText.text = "";
    }

    public void OnOpen(){
        varName.text = IOManager.instance.varName;
    }

    public void TurnOn(){
        this.transform.GetComponent<LeanWindow>().TurnOn();
    }
}
