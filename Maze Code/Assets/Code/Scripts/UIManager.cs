﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public GameObject terminal;
    public GameObject invent;
    public GameObject menu;
    public GameObject buttons;
    public GameObject runWindow;

    public static bool isOpened;
    public static UIManager ui;

    private void Start() {
        ui = this;
    }
    // Start is called before the first frame update
    private void ToggleTerminal (bool b) {
        invent.SetActive (b);
        menu.SetActive (b);
        buttons.SetActive (b);
    }

    private void RunMode(bool b){
        invent.SetActive (!b);
        runWindow.SetActive (b);
    }

    public static void ChangeWindowStatus (bool b) {
        ui.ToggleTerminal(!b);
    }

    public static void ToggleRunMode(bool b){
        ui.RunMode(b);
    }
}