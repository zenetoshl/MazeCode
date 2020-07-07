using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public GameObject terminal;
    public GameObject invent;
    public GameObject menu;

    public static bool changed;
    public static bool isOpened;
    public static UIManager ui;

    private void Start() {
        ui = this;
    }
    // Start is called before the first frame update
    private void OpenTerminal () {
        invent.SetActive (false);
        menu.SetActive (false);
    }

    // Update is called once per frame
    private void CloseTerminal () {
        invent.SetActive (true);
        menu.SetActive (true);
    }

    public static void ChangeWindowStatus (bool b) {
        isOpened = b;
        if (isOpened) {
            ui.OpenTerminal ();
        } else {
            ui.CloseTerminal ();
        }
    }
}