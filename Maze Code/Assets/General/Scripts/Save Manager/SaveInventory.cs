using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveInventory : MonoBehaviour {
    [SerializeField] public PlayerInventory inventory;
    [System.Serializable]
    public class Counts{
        [SerializeField] public List<int> saveCounts = new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0};

        public Counts (){
            saveCounts = new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0};
        }
    }
    
    public static Counts counts = new Counts();
    public static bool loaded = false;

    public Counts SaveScriptables () {
        for (int i = 0; i < inventory.myInventory.Count; i++) {
            counts.saveCounts[i] = inventory.myInventory[i].numberHeld;
            Debug.Log("save " + counts.saveCounts[i]);
        }
        return counts;
    }

    public void LoadScriptables (List<int> c) {
        Debug.Log("oie");
        if(inventory == null) return;
        Debug.Log("aaaaaaaa");
        for (int i = 0; i < c.Count; i++) {
           inventory.myInventory[i].numberHeld = c[i];
           Debug.Log("load " + c[i]);
        }
    }

    

    public Counts ResetScriptables () {
        for (int i = 0; i < inventory.myInventory.Count; i++) {
            // Zera inventário
            inventory.myInventory[i].numberHeld = 0;
            counts.saveCounts[i] = 0;
        }
        return counts;
    }
}