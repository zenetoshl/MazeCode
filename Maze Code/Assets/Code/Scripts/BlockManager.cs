using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public void ClearBlocks(){
        Bloco[] blockList = GameObject.FindObjectsOfType<Bloco>();
        foreach (Bloco bloco in blockList)
        {
            EntryPoint ep = bloco.transform.GetComponentInChildren<EntryPoint>();
            if(ep != null){
                if(ep.isEmpty){
                    DestroyAll(bloco.GetComponent<RectTransform> ());
                }
            }
        } 
    }

    public static void DestroyAll (RectTransform transform) {
        List<Connection> conns = ConnectionManager.FindNextNodes (transform, 0);
        foreach (Connection c in conns) {
           DestroyAll(c.target[1]);
        }
        Destroy(transform.parent.gameObject);
    }
  
}
