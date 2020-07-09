using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;

public class InstantiateTerminal : MonoBehaviour
{
    public LeanWindow leanWindowPrefab;
    private LeanWindow myLeanWindow;
    // Start is called before the first frame update

    void Awake()
    {
        GameObject terminal = GameObject.Find("UI/Terminal") as GameObject;
        myLeanWindow = Instantiate(leanWindowPrefab, new Vector3(Screen.width / 2, Screen.height / 2, 0), Quaternion.identity);
        myLeanWindow.transform.SetParent(terminal.transform, true);
        myLeanWindow.GetComponent<BlockWindow>().myBlock = this.GetComponent<Bloco>();
    }

    // Update is called once per frame
    private void OnDestroy() {
        Destroy(myLeanWindow.gameObject);
        myLeanWindow = null;
    }

    public void TurnOn() {
        myLeanWindow.TurnOn();
    }

    public LeanWindow GetMyWindow(){
        return myLeanWindow;
    }
}
