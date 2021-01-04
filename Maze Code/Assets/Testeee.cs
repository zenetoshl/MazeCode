using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testeee : MonoBehaviour
{
    private void Start() {
        OperationManager.IsBalanced("(1 + 2220) ++ 3 - (2 + 3)");
        OperationManager.IsBalanced("111 - 234 - 43 * (1 + 2220) + 3 - (2 + 3)");
        OperationManager.IsBalanced("(1 + 2220 * (233 - 3) + 1) + 3 - (2 + 3)");
        OperationManager.IsBalanced("1 + 2 + 3 + 4");
    }
}
