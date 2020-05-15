using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject terminal;
    public GameObject invent;
    public GameObject menu;

    public static bool changed;
    public static bool isOpened;
    // Start is called before the first frame update
    private void OpenTerminal(){
        invent.SetActive(false);
        menu.SetActive(false);
    }

    // Update is called once per frame
    private void closeTerminal(){
        invent.SetActive(true);
        menu.SetActive(true);
    }

    private void Update() {
        if(changed){
            changed = false;
            if(isOpened){
                OpenTerminal();
            } else {
                closeTerminal();
            }
        }
    }
}
