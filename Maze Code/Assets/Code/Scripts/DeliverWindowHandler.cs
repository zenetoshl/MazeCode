using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeliverWindowHandler : MonoBehaviour {
    public Text percent;
    public Text bodyText;
    public Image circle;
    public LeanWindow window;

    public Color[] colors;
    public string[] bodies;
    public string[] titles;

    public void CheckSend(){
        int i = GetIndex();
        Debug.Log(i);
        circle.color = colors[i];
        bodyText.text = titles[i] + " " + bodies[i];
        percent.text = CodeSender.rightAnwsersPercentage + "%";
        window.TurnOn();
    }

    private int GetIndex(){
        return ((CodeSender.rightAnwsersPercentage > 50) ? ((CodeSender.rightAnwsersPercentage == 100) ? 0 : 1) : 2);
    }
}