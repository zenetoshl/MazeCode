using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class WindowPad : MonoBehaviour {

    public abstract void InsertToOperation (string charPut);

    public abstract void Clear ();

    public abstract void EraseAtIndex ();

    public abstract string[] InsertAt (string[] arr, string item, int pos);

    public abstract string[] ReplaceAt (string[] arr, string item, int i);
}