using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarLister : MonoBehaviour
{
    public Transform parent;
    public VarItemUI prefabListItem;
    public WindowPad pad;

    public void ListVars(List<string> varnames){
        foreach(Transform child in parent){
            Destroy(child.gameObject);
        }
        foreach(string name in varnames){
            VarItemUI varItem = Instantiate(prefabListItem, parent);
            varItem.Initialize(name, pad);
        }
    }
}
