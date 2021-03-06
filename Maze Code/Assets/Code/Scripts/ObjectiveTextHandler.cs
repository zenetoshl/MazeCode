﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectiveTextHandler : MonoBehaviour {

    public Text text;
    // Start is called before the first frame update
    void Start () {
        BetterStreamingAssets.Initialize ();
        string filePath = System.IO.Path.Combine ("term", "obj");
        filePath = System.IO.Path.Combine (filePath, SceneManager.GetActiveScene().name + ".txt");
        Debug.Log(filePath);
        string newText = "";
        foreach (string item in BetterStreamingAssets.ReadAllLines (filePath)) {
            newText += item + "\n";
        }
        text.text = newText;
    }
}