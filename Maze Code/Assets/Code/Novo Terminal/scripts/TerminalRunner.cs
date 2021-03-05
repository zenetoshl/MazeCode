using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalRunner : MonoBehaviour
{
    public TerminalBlocks init;
    
    public IEnumerator StartCode(){
        yield return StartCoroutine(init.RunBlock());
        TerminalEventManager.instance.resetEvent.Invoke();
    }
    public void RunInit(){
        StartCoroutine(StartCode());
    }
}
