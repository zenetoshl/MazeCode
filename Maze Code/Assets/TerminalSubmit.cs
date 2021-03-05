using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalSubmit : MonoBehaviour
{
    public string correctOutput;
    public TerminalBlocks init;
    public CodeToMaze exit;

    public IEnumerator StartCode(){
        yield return StartCoroutine(init.RunBlock());
        if(correctOutput == IOManager.instance.output){
            exit.ReturnToMaze();
        }
        TerminalEventManager.instance.resetEvent.Invoke();
    }
    public void RunInit(){
        StartCoroutine(StartCode());
    }
}
