using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testeee : MonoBehaviour
{
    private void Start() {
        string result = OperationManager.IsBalanced("(111 - (1 + 3) - 234) - 43 * (1 + 2220) + 3 - (2 + 3)", "int");
        result = OperationManager.IsBalanced("(111.5 - (1 + 3) - 234) - 43 * (1 + 2220.3) + 3 - (2 + 3.23)", "double");
        Debug.Log(result);
    }
}
