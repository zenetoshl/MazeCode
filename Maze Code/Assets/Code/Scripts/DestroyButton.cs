using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyButton : MonoBehaviour {

    public void OnMouseUpAsButton () {
        Compiler.instance.Uncompile();
        Destroy (this.transform.parent.transform.parent.gameObject);

    }
}