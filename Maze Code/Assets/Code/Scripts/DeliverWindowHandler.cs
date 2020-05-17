using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeliverWindowHandler : MonoBehaviour {
    public TextMeshProUGUI percent;
    public TextMeshProUGUI bodyText;
    public Image circle;
    public Image button;
    public LeanWindow window;

    public Color[] colors;
    public string[] bodies;
    public string[] titles;


    public void CheckSend(){
        int i = GetIndex();
        Debug.Log(i);
        circle.color = colors[i];
        button.color = colors[i];
        bodyText.text = titles[i] + "\n\n" + bodies[i];
        percent.text = CodeSender.rightAnwsersPercentage + "%";
        window.TurnOn();
    }

    private int GetIndex(){
        return ((CodeSender.rightAnwsersPercentage > 50) ? ((CodeSender.rightAnwsersPercentage == 100) ? 0 : 1) : 2);
    }

    public void BackToMaze(){
        SceneManager.LoadScene ("Labirinto");
    }
}