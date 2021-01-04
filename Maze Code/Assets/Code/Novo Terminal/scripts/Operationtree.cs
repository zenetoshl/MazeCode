using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Operationtree {
    public class Node {
        Operationtree.Node left;
        Operationtree.Node right;
        string value;
        //no interno
        public Node (string s1, string s2, string s3){
            Debug.Log(s1);
            left = OperationManager.IsBalanced(s1);
            Debug.Log(s2);
            value = s2;
            Debug.Log(s3);
            right = OperationManager.IsBalanced(s3);
        }
        //no folha
        public Node (string s){
            Debug.Log(s);
            value = s; //resolver value depois
            left = null;
            right = null;
            
        }
    }
}