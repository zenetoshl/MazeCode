using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextInputInstantiator : MonoBehaviour {
    public static GameObject prefab; 
    public GameObject _prefab;
    // Start is called before the first frame update
    public static void InstantiateText (Transform newParent) {
        GameObject instanced = Instantiate (prefab, new Vector3 (0, 0, 0), Quaternion.identity);
        instanced.transform.SetParent (newParent, false);
    }

    private static void ClearList(Transform transform){
        foreach (Transform t in transform)
        {
            string s = t.Find("Text Area/Text").GetComponent<TextMeshProUGUI>().text;
            s = s.Substring (0, s.Length - 1);
            if(s != "")
                Destroy(t.gameObject);
        }
        
    }

    public static List<int> ToList(Transform transform){
        List<int> list = new List<int>();
        foreach (Transform t in transform)
        {
            string s = t.Find("Text Area/Text").GetComponent<TextMeshProUGUI>().text;
            s = s.Substring (0, s.Length - 1);
            if(s != ""){
                int i = Convert.ToInt32(s);
                list.Add(i);
            }
        }
        return list;
    }

    public void Clear(){
        ClearList(this.transform);
    }

    private void Start () {
        prefab = _prefab;
    }
}