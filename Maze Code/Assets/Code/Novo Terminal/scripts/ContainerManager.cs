using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerManager : MonoBehaviour {
    public static bool isActive = true;
    public static bool changed = false;
    public GameObject container = null;

    private void Update () {
        if (changed) {
            container.SetActive (isActive);
            changed = false;
        }

    }
}