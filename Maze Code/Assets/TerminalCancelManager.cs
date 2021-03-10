using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalCancelManager : MonoBehaviour
{
    static TerminalCancelManager _instance;
    public static TerminalCancelManager instance {
        get {
            if (!_instance) {
                //first try to find one in the scene
                _instance = FindObjectOfType<TerminalCancelManager> ();

                if (!_instance) {
                    //if that fails, make a new one
                    GameObject go = new GameObject ("_VariablesManager");
                    _instance = go.AddComponent<TerminalCancelManager> ();

                    if (!_instance) {
                        //if that still fails, we have a big problem;
                        Debug.LogError ("Fatal Error: could not create TerminalCancelManager");
                    }
                }
            }

            return _instance;
        }
    }

    public bool cancel = true;

    public void CancelRun(){
        cancel = true;
    }

    public void OnStart(){
        cancel = false;
    }
}
