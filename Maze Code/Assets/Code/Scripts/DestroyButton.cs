using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyButton : MonoBehaviour {

    public void OnMouseUpAsButton () {
        Destroy (this.transform.parent.transform.parent.gameObject);

    }
}