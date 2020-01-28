using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testeColisao : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Mesh lineMesh = new Mesh();
        this.gameObject.GetComponent<LineRenderer>().BakeMesh(lineMesh, true);
        this.gameObject.GetComponent<MeshCollider>().sharedMesh = lineMesh;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("colidiu msm doido");
    }
}
