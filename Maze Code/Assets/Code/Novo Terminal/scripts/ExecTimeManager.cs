using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExecTimeManager : MonoBehaviour {
    static ExecTimeManager _instance;
    public static ExecTimeManager instance {
        get {
            if (!_instance) {
                //first try to find one in the scene
                _instance = FindObjectOfType<ExecTimeManager> ();

                if (!_instance) {
                    //if that fails, make a new one
                    GameObject go = new GameObject ("_VariablesManager");
                    _instance = go.AddComponent<ExecTimeManager> ();

                    if (!_instance) {
                        //if that still fails, we have a big problem;
                        Debug.LogError ("Fatal Error: could not create ExecTimeManager");
                    }
                }
            }

            return _instance;
        }
    }
    public const float maxTime = 1.0f;
    public const float minTime = .1f;

    public float execTime = .5f;

    private void Start() {
        TerminalEventManager.instance.resetEvent.AddListener(Reset);
    }

    public void MaxExecTime(){
        execTime = maxTime;
    }

    public void MinExecTime(){
        execTime = minTime;
    }

    public void FasterExecTime(){
        if(execTime == minTime) return;
        execTime = execTime - .1f;
        if(execTime <= minTime) execTime = minTime;
    }

    public void SlowerExecTime(){
        if(execTime == maxTime) return;
        execTime = execTime + .1f;
        if(execTime >= maxTime) execTime = maxTime;
    }

    public void Reset(){
        execTime = .5f;
    }
}
