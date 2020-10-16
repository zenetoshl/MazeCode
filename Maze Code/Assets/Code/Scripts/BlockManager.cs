using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public static bool CheckDisconnectedBlocks(){
        Bloco[] blockList = GameObject.FindObjectsOfType<Bloco>();
        bool b = true;
        foreach (Bloco block in blockList)
        {
            EntryPoint ep = block.transform.GetComponentInChildren<EntryPoint>();
            if(ep != null){
                if(ep.isEmpty){
                    MarkErrorAll(block);
                    b = false;
                }
            }
        }
        
        if(!b){
            ErrorLogManager.instance.CreateError("Bloco(s) desconectado(s) do fluxo do programa");
        }

        return b;
    }

    public static void MarkErrorAll (Bloco block) {
        List<Connection> conns = ConnectionManager.FindNextNodes (block.GetComponent<RectTransform>(), 0);
        foreach (Connection c in conns) {
           MarkErrorAll(c.target[1].GetComponent<Bloco>());
        }
        block.MarkError(false);
    }
  
}
