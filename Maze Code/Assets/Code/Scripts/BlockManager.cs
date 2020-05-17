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
                    Destroy(bloco.transform.parent.gameObject);
                }
            }
        } 
    }   
}
