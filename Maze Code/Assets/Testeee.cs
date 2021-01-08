using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testeee : MonoBehaviour
{
    private void Start() {
        Operationtree.Node node = OperationManager.IsBalanced("(111 - 234) - 43 * (1 + 2220) + 3 - (2 + 3)");
        Debug.Log(node.ResolveOperation("int"));
    }
}
