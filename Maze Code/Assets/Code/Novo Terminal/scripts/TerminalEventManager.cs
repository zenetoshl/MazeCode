using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TerminalEventManager : MonoBehaviour
{
    static TerminalEventManager _instance;
    public static TerminalEventManager instance {
        get {
            if (!_instance) {
                //first try to find one in the scene
                _instance = FindObjectOfType<TerminalEventManager> ();

                if (!_instance) {
                    //if that fails, make a new one
                    GameObject go = new GameObject ("_VariablesManager");
                    _instance = go.AddComponent<TerminalEventManager> ();

                    if (!_instance) {
                        //if that still fails, we have a big problem;
                        Debug.LogError ("Fatal Error: could not create TerminalEventManager");
                    }
                }
            }

            return _instance;
        }
    }

    public UnityEvent resetEvent;
}
