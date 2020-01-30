using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;

public class OpenUI : MonoBehaviour
{
    public LeanWindow thiswindow;
    // Start is called before the first frame update
    private void OnMouseUpAsButton()
    {
        if (!ClickController.isClickingOnObject)
        {
            thiswindow.TurnOn();
        }
    }
}
